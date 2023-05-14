using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToSomewhere : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent agent;
    private GameObject Area;
    //Vector3[] coord = new[] { new Vector3(7, 1, 0), new Vector3(7, 1, 7), new Vector3(7, 1, -7), new Vector3(0, 1, 0), new Vector3(0, 1, 7), new Vector3(0, 1, -7), new Vector3(-7, 1, 0), new Vector3(-7, 1, 7) };
    public int Destination=0;     // Destination (room number)


    void Start()
    {
        Area = GameObject.Find("Area");
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }


    void Update()
    {
        if (Destination>=0 && Destination<9) {
            agent.SetDestination(Area.GetComponent<CreateRescueNeeded>().Rooms[Destination].transform.position);        // Destination 번호인 방으로 이동
        }
    }


    public void GetMoveCommand()
    {
        agent.SetDestination(Area.GetComponent<CreateRescueNeeded>().Rooms[Destination].transform.position);
    }
}