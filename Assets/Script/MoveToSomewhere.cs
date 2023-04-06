using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToSomewhere : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent agent;
    Vector3[] coord = new[] { new Vector3(7, 1, 0), new Vector3(7, 1, 7), new Vector3(7, 1, -7), new Vector3(0, 1, 0), new Vector3(0, 1, 7), new Vector3(0, 1, -7), new Vector3(-7, 1, 0), new Vector3(-7, 1, 7) };

    public GameObject target;   // change this to edit destination
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.SetDestination(target.transform.position);
    }


    void Update()
    {
        
    }
    public void GetMoveCommand(int n)
    {

    }
}