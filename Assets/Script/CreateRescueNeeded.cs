using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;

public class CreateRescueNeeded : MonoBehaviour
{
    public GameObject RescueObject;

    void Start()
    {
        int random_number;
        Vector3[] coord = new[] { new Vector3(7, 1, 7), new Vector3(7, 1, -7), new Vector3(0, 1, 0), new Vector3(0, 1, 7), new Vector3(0, 1, -7), new Vector3(-7, 1, 0), new Vector3(-7, 1, 7), new Vector3(-7, 1, -7) };

        for (int i=0;i<5;i++)
        {
            random_number = Random.Range(0,8);
            Vector3 random_coord = new Vector3(Random.Range(-2f, 2f), 0f, Random.Range(-2f, 2f));
            Instantiate(RescueObject, coord[random_number]+random_coord, Quaternion.identity);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
