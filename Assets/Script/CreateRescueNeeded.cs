using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class CreateRescueNeeded : MonoBehaviour
{
    public GameObject RescueObject;
    //public GameObject[] Exit = new GameObject[4];   // Get Exit object
    public int totalPeopleNum;
    int[] random_number = new int[10];
    int i, g = 0;
    public GameObject[] SpawnPoint = new GameObject[90]; // Make Spawnpoint objects
    public GameObject[] Rooms = new GameObject[9]; // Get Room objects
    public GameObject[] person = new GameObject[1000];
    public int disasterType; // 0이면 지진, 1이면 화재, 2면 둘다

    public void Init()
    {
        disasterType = (int)Random.Range(0, 3);
        i = 0; g = 0;
        random_number = new int[10];
        while (i < totalPeopleNum)
        {
            bool dab = true;
            while (dab)
            {
                g = Random.Range(0, 89);
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
            i++;
        }

        for (int j = 0; j < totalPeopleNum; j++)
        {
            person[j] = Instantiate(RescueObject, SpawnPoint[random_number[j]].transform.position, Quaternion.identity);
            person[j].GetComponent<ChkExit>().personIndex = j;
        }
    }
}
