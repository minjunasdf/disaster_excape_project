using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;


public class ExcapeAgent : Agent
{
    public int remainPeople, exit;

    //초기화 작업을 위해 한번 호출되는 메소드
    public override void Initialize()
    {

    }


    //에피소드(학습단위)가 시작할때마다 호출
    public override void OnEpisodeBegin()
    {
        exit = Random.Range(0, 8);
        for (int k= 0; k < this.GetComponent<CreateRescueNeeded>().totalPeopleNum;k++)
        {
            if (this.GetComponent<CreateRescueNeeded>().person[k] != null)
            {
                this.GetComponent<CreateRescueNeeded>().person[k].GetComponent<ChkExit>().IWantToDie();
            }
            else
            {
                this.GetComponent<CreateRescueNeeded>().person[k] = null;
            }
        }
        this.GetComponent<CreateRescueNeeded>().Init();
        remainPeople = this.GetComponent<CreateRescueNeeded>().totalPeopleNum;
        SetReward(2f);
    }
    

    //환경 정보를 관측 및 수집해 정책 결정을 위해 브레인에 전달하는 메소드
    public override void CollectObservations(VectorSensor sensor)
    {
        for(int i = 0; i<this.GetComponent<CreateRescueNeeded>().totalPeopleNum; i++) // 전체 사람 수만큼 반복
        {
            if (this.GetComponent<CreateRescueNeeded>().person[i] != null)
            {
                sensor.AddObservation(this.GetComponent<CreateRescueNeeded>().person[i].GetComponent<WhereAmI>().position); // 사람이 있는 방 번호
            }
            else
            {
                sensor.AddObservation(0);
            }
        }

        for(int i=0;i<9;i++)
        {
            sensor.AddObservation(this.GetComponent<CreateRescueNeeded>().Rooms[i].GetComponent<Chkpeople>().roomPeopleNum); 
        }
    }

    
    //브레인(정책)으로 부터 전달 받은 행동을 실행하는 메소드
    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        AddReward(-1f / MaxStep);
        MoveObject(actionBuffers.DiscreteActions);
    }
    
    void MoveObject(ActionSegment<int> act)
    {
        for(int j = 0; j<this.GetComponent<CreateRescueNeeded>().totalPeopleNum; j++)
        {
            if (this.GetComponent<CreateRescueNeeded>().person[j] != null)
            {
                this.GetComponent<CreateRescueNeeded>().person[j].GetComponent<MoveToSomewhere>().Destination = act[j];
            }
            else
            {
                this.GetComponent<CreateRescueNeeded>().person[j] = null;
            }
        }
    }


    public void SomeoneHasExited()
    {
        remainPeople--;
        if (remainPeople == 0)
        {
            EndEpisode();
        }
    }

    public void SomeoneHasDied()
    {
        remainPeople--;
        AddReward(-1.0f);
        if (remainPeople == 0)
        {
            EndEpisode();
        }
    }


    public override void Heuristic(in ActionBuffers actionsOut)
    {
        
    }
}