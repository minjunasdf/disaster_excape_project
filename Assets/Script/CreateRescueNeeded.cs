using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class CreateRescueNeeded : MonoBehaviour
{
    public GameObject RescueObject;
    //public GameObject[] Exit = new GameObject[4];   // Get Exit object
    public int peoplenum;
    int[] random_number = new int[10];
    int i, g = 0;
    public GameObject[] SpawnPoint = new GameObject[90]; // Get check objects
    public GameObject[] Rooms = new GameObject[9]; // Get check objects
    public GameObject[] person = new GameObject[1000];


    public void Init()
    {
        while (i < peoplenum)
        {
            bool dab = true;
            while (dab)
            {
                g = Random.Range(0, 90);
                dab = false;
                for (int ag = 0; ag < i; ag++)
                {
                    if (g == random_number[ag] || this.GetComponent<ExcapeAgent>().exit == g / 10)
                    {
                        dab = true;
                    }
                }
            }
            random_number[i] = g;
            Debug.Log(g);
            i++;
        }

        for (int j = 0; j < peoplenum; j++)
        {
            person[j] = Instantiate(RescueObject, SpawnPoint[random_number[j]].transform.position, Quaternion.identity);
        }
    }
}
