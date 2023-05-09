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

    //�ʱ�ȭ �۾��� ���� �ѹ� ȣ��Ǵ� �޼ҵ�
    public override void Initialize()
    {
        Area = GameObject.Find("Area");
        peopleArray = this.GetComponent<CreateRescueNeeded>().person;
        remainPeople = this.GetComponent<CreateRescueNeeded>().peoplenum;
        peopleNum = this.GetComponent<CreateRescueNeeded>().peoplenum;
    }

    //���Ǽҵ�(�н�����)�� �����Ҷ����� ȣ��
    public override void OnEpisodeBegin() //��
    {
        Area.GetComponent<CreateRescueNeeded>().Init();
        SetReward(2f);
    }
    

    //ȯ�� ������ ���� �� ������ ��å ������ ���� �극�ο� �����ϴ� �޼ҵ�
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

    
    //�극��(��å)���� ���� ���� ���� �ൿ�� �����ϴ� �޼ҵ�
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