using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public GameObject prefab;
using System;

public class CreateRescueNeeded : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Random rand = new Random();
        int random_number=rand.Next(8);
        for (int i=0;i<5;i++)
        {
            switch random_number
            Instantiate(prefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
