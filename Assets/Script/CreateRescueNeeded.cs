using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class CreateRescueNeeded : MonoBehaviour
{
    public GameObject RescueObject;
    //public GameObject[] Exit = new GameObject[4];   // Get Exit object
    public int peoplenum;
    public GameObject[] Rooms = new GameObject[9]; // Get check objects
    public GameObject[] person = new GameObject[1000];

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init()
    {
        int random_number;
        int i;
        for (i = 0; i < peoplenum; i++)
        {
            random_number = Random.Range(1, 9);
            Vector3 random_coord = new Vector3(Random.Range(-2f, 2f), 0f, Random.Range(-2f, 2f));
            person[i] = Instantiate(RescueObject, Rooms[random_number].transform.position + random_coord, Quaternion.identity);
        }
    }
}
