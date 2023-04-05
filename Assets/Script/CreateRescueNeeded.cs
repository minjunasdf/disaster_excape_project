using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;
public class CreateRescueNeeded : MonoBehaviour
{
    public GameObject RescueObject;
    public GameObject[] Rooms = new GameObject[9]; //방 받아오는 변수
    public GameObject[] person = new GameObject[5];

    void Start()
    {
        int random_number;
        int i;
        Vector3[] coord = new Vector3[] {new Vector3(7,1,0), //방 위치 반영되도록 변경!
                                         new Vector3(7, 1, 7),
                                         new Vector3(7, 1, -7),
                                        new Vector3(0, 1, 0),
                                        new Vector3(0, 1, 7), 
                                        new Vector3(0, 1, -7), 
                                        new Vector3(-7, 1, 0), 
                                        new Vector3(-7, 1, 7), 
                                        new Vector3(-7, 1, -7) };

        for (i=0;i<5;i++)
        {
            random_number = Random.Range(0,9);
            Vector3 random_coord = new Vector3(Random.Range(-2f, 2f), 0f, Random.Range(-2f, 2f));
            person[i] = Instantiate(RescueObject, coord[random_number] + random_coord, Quaternion.identity);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
