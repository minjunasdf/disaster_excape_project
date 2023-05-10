using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class ExcapeAgent : Agent
{
    public GameObject Area;
    public GameObject[] peopleArray;
    public int peopleNum, remainPeople;

    //초기화 작업을 위해 한번 호출되는 메소드
    public override void Initialize()
    {
        Area = GameObject.Find("Area");
        peopleArray = this.GetComponent<CreateRescueNeeded>().person;
        peopleNum = this.GetComponent<CreateRescueNeeded>().peoplenum;
    }

    //에피소드(학습단위)가 시작할때마다 호출
    public override void OnEpisodeBegin() //끝
    {
        for(int k= 0; k < peopleNum;k++)
        {
            if (peopleArray[k] != null)
            {
                peopleArray[k].GetComponent<ChkExit>().IWantToDie();
                Debug.Log("gllg1");
            }
            else
            {
                peopleArray[k] = null;
                Debug.Log("gllg2");
            }
        }
        Area.GetComponent<CreateRescueNeeded>().Init();
        remainPeople = peopleNum;
        SetReward(2f);
    }
    

    //환경 정보를 관측 및 수집해 정책 결정을 위해 브레인에 전달하는 메소드
    public override void CollectObservations(VectorSensor sensor)
    {
        for(int igd = 0; igd<peopleNum; igd++)
        {
            if (peopleArray[igd] != null)
            {
                sensor.AddObservation(peopleArray[igd].GetComponent<WhereAmI>().position);
                Debug.Log(peopleArray[igd].GetComponent<WhereAmI>().position);
            }
            else
            {
                sensor.AddObservation(0);
                Debug.Log("0");
            }
        }

        for(int i=0;i<9;i++)
        {
            sensor.AddObservation(Area.GetComponent<CreateRescueNeeded>().Rooms[i].GetComponent<Chkpeople>().peoplenum);
            Debug.Log(Area.GetComponent<CreateRescueNeeded>().Rooms[i].GetComponent<Chkpeople>().peoplenum);
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
        for(int j = 0; j<peopleNum; j++)
        {
            peopleArray[j].GetComponent<MoveToSomewhere>().Destination = act[j];
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

    public override void Heuristic(in ActionBuffers actionsOut)
    {

    }
}