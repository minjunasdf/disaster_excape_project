using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;


public class ExcapeAgent : Agent
{
    public int remainPeople, exit, fire, episodes;
    public GameObject[] doors=new GameObject[12];
    public int disasterType; // 0이면 지진, 1이면 화재, 2면 둘다
    //초기화 작업을 위해 한번 호출되는 메소드
    public override void Initialize()
    {
        episodes = 0;
    }

    //에피소드(학습단위)가 시작할때마다 호출
    public override void OnEpisodeBegin()
    {
        Debug.Log("----------------------------------------");
        episodes += 1;
        for (int i = 0; i < doors.Length;i++) {
            doors[i].GetComponent<DoorDisaster>().Init();
        }
        disasterType = (int)Random.Range(0, 3);
        exit = Random.Range(0, 9); // 끝 숫자 포함 안됨
        if (disasterType > 0)
        {
            fire = Random.Range(0, 9);
            while(exit == fire)
            {
                fire = Random.Range(0, 9);
            }
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
            if(exit == i)
            {
                this.GetComponent<CreateRescueNeeded>().Rooms[i].GetComponent<RoomDisaster>().isExit = true;
            }
            else
            {
                this.GetComponent<CreateRescueNeeded>().Rooms[i].GetComponent<RoomDisaster>().isExit = false;
            }
            this.GetComponent<CreateRescueNeeded>().Rooms[i].GetComponent<RoomDisaster>().Init();
        }
        this.GetComponent<CreateRescueNeeded>().Init(episodes);
        remainPeople = this.GetComponent<CreateRescueNeeded>().totalPeopleNum;
        SetReward(1f);
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
        for (int i=0;i<9;i++)
        {
            sensor.AddObservation(this.GetComponent<CreateRescueNeeded>().Rooms[i].GetComponent<Chkpeople>().roomPeopleNum);
        }
        sensor.AddObservation(exit);
        sensor.AddObservation(disasterType);
        for (int i=0;i<9;i++)
        {
            sensor.AddObservation(this.GetComponent<CreateRescueNeeded>().Rooms[i].GetComponent<RoomDisaster>().onFire);
        }
        for (int i=0;i<12;i++)
        {
            sensor.AddObservation(doors[i].GetComponent<DoorDisaster>().onFire);
            sensor.AddObservation(doors[i].GetComponent<DoorDisaster>().isRisky);
        }
    }

    //브레인(정책)으로 부터 전달 받은 행동을 실행하는 메소드
    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        AddReward(-0.0001f); // 최대 1까지 까이게
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
        }
    }

    public void SomeoneHasExited()
    {
        AddReward(0.4f); 
        if (remainPeople == 0)
        {
            Invoke("EndEpisode", 0.1f);
        }
    }

    public void SomeoneHasDied()
    {
        AddReward(-0.4f); // 최대 2까지 까이게
        if (remainPeople == 0)
        {
            Invoke("EndEpisode", 0.1f);
        }
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        
    }
}