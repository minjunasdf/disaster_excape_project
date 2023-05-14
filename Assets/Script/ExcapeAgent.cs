using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;


public class ExcapeAgent : Agent
{
    public int remainPeople, exit;

    //�ʱ�ȭ �۾��� ���� �ѹ� ȣ��Ǵ� �޼ҵ�
    public override void Initialize()
    {

    }


    //���Ǽҵ�(�н�����)�� �����Ҷ����� ȣ��
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