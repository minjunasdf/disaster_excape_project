using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class CreateRescueNeeded : MonoBehaviour
{
    public GameObject RescueObject;
    //public GameObject[] Exit = new GameObject[4];   // Get Exit object
    public int peoplenum;
    int[] random_number;
    public GameObject[] SpawnPoint = new GameObject[90]; // Get check objects
    public GameObject[] Rooms = new GameObject[9]; // Get check objects
    public GameObject[] person = new GameObject[1000];


    public void Init()
    {
        int i = 0;
        while (i < peoplenum)
        {
            bool dab = true;
            while (dab)
            {
                int g = Random.Range(0, 90);
                for (int ag = 0; ag < i; ag++)
                {
                    if (g == random_number[ag])
                    {
                        dab = true;
                    }
                }
            }
            random_number[i] = Random.Range(0, 90);
            i++;
        }
        for (int j = 0; j < peoplenum; j++)
        {
            person[j] = Instantiate(RescueObject, SpawnPoint[random_number[j]].transform.position, Quaternion.identity);
        }
    }
}
