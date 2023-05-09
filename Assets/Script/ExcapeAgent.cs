using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class ExcapeAgent : Agent
{
    public GameObject Area;
    public GameObject[] peopleArray;
    public int peopleNum, remainPeople;
    UnityEngine.AI.NavMeshAgent agent;

    //초기화 작업을 위해 한번 호출되는 메소드
    public override void Initialize()
    {
        Area = GameObject.Find("Area");
        peopleArray = this.GetComponent<CreateRescueNeeded>().person;
        remainPeople = this.GetComponent<CreateRescueNeeded>().peoplenum;
        peopleNum = this.GetComponent<CreateRescueNeeded>().peoplenum;
    }

    //에피소드(학습단위)가 시작할때마다 호출
    public override void OnEpisodeBegin() //끝
    {
        Area.GetComponent<CreateRescueNeeded>().Init();
        SetReward(2f);
    }
    

    //환경 정보를 관측 및 수집해 정책 결정을 위해 브레인에 전달하는 메소드
    public override void CollectObservations(VectorSensor sensor)
    {
        for(int i = 0; i<peopleNum; i++)
        {
            if (peopleArray[i] != null) sensor.AddObservation(peopleArray[i].GetComponent<WhereAmI>().position);
            else sensor.AddObservation(0); Debug.Log("");
        }

        for(int i=0;i<9;i++)
        {
            sensor.AddObservation(Area.GetComponent<CreateRescueNeeded>().Rooms[i].GetComponent<Chkpeople>().peoplenum);
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
        int objectNum = 0;
        int roomNum = 0;
        agent = peopleArray[objectNum].GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.SetDestination(Area.GetComponent<CreateRescueNeeded>().Rooms[roomNum].transform.position);
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