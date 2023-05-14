using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;


public class ExcapeAgent : Agent
{
    public int remainPeople, exit, fire, episodes;
    public GameObject[] doors=new GameObject[12];
    public int disasterType; // 0�̸� ����, 1�̸� ȭ��, 2�� �Ѵ�
    //�ʱ�ȭ �۾��� ���� �ѹ� ȣ��Ǵ� �޼ҵ�
    public override void Initialize()
    {
        episodes = 0;
    }


    //���Ǽҵ�(�н�����)�� �����Ҷ����� ȣ��
    public override void OnEpisodeBegin()
    {
        episodes += 1;
        for (int i = 0; i < doors.Length;i++) {
            doors[i].GetComponent<DoorDisaster>().Init();
        }
        disasterType = (int)Random.Range(0, 3);
        if (disasterType > 0)
        {
            fire = Random.Range(0, 9);
        }
        else
        {
            fire = -1;
        }
        for (int i=0;i<this.GetComponent<CreateRescueNeeded>().Rooms.Length;i++)
        {
            if (disasterType > 0)
            {
                if (fire == i)
                {
                    this.GetComponent<CreateRescueNeeded>().Rooms[i].GetComponent<RoomDisaster>().onFire = true;
                }
                else
                {
                    this.GetComponent<CreateRescueNeeded>().Rooms[i].GetComponent<RoomDisaster>().onFire = false;
                }
            }
            this.GetComponent<CreateRescueNeeded>().Rooms[i].GetComponent<RoomDisaster>().Init();
        }
        exit = Random.Range(0, 9); // �� ���� ���� �ȵ�
        this.GetComponent<CreateRescueNeeded>().Init(episodes);
        remainPeople = this.GetComponent<CreateRescueNeeded>().totalPeopleNum;
        SetReward(2f);
    }
    

    //ȯ�� ������ ���� �� ������ ��å ������ ���� �극�ο� �����ϴ� �޼ҵ�
    public override void CollectObservations(VectorSensor sensor)
    {
        for(int i = 0; i<this.GetComponent<CreateRescueNeeded>().totalPeopleNum; i++) // ��ü ��� ����ŭ �ݺ�
        {
            if (this.GetComponent<CreateRescueNeeded>().person[i] != null)
            {
                sensor.AddObservation(this.GetComponent<CreateRescueNeeded>().person[i].GetComponent<WhereAmI>().position); // ����� �ִ� �� ��ȣ
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

    
    //�극��(��å)���� ���� ���� ���� �ൿ�� �����ϴ� �޼ҵ�
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
                this.GetComponent<CreateRescueNeeded>().person[j].GetComponent<MoveToSomewhere>().Destination = 0;//act[j];
            }
        }
    }


    public void SomeoneHasExited()
    {
        if (remainPeople == 0)
        {
            EndEpisode();
        }
    }

    public void SomeoneHasDied()
    {
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