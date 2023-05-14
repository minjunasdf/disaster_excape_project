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
    int g = 0;
    public GameObject[] SpawnPoint = new GameObject[90]; // Make Spawnpoint objects
    public GameObject[] Rooms = new GameObject[9]; // Get Room objects
    public GameObject[] person = new GameObject[100];
    float scaletmp;

    public void Init(int episodes)
    {
        g = 0;
        random_number = new int[totalPeopleNum];
        person = new GameObject[totalPeopleNum];
        for(int i = 0; i < totalPeopleNum; i++)
        {
            bool dab = true;
            while (dab)
            {
                g = Random.Range(0, 90);
                dab = false;
                if (this.GetComponent<ExcapeAgent>().exit == (int)(g / 10) || this.GetComponent<ExcapeAgent>().fire == (int)(g / 10)) dab = true;
                for (int ag = 0; ag < i; ag++)
                {
                    if (g == random_number[ag] || this.GetComponent<ExcapeAgent>().exit == (int)(g / 10) || this.GetComponent<ExcapeAgent>().fire == (int)(g / 10))
                    {
                        dab = true;
                    }
                }
            }
            Debug.Log(g);
            random_number[i] = g;
        }

        for (int j = 0; j < totalPeopleNum; j++)
        {
            person[j] = Instantiate(RescueObject, SpawnPoint[random_number[j]].transform.position, Quaternion.identity);
            person[j].GetComponent<ChkExit>().personIndex = j;
            person[j].GetComponent<ChkExit>().episodeMade = episodes;
            scaletmp = Random.Range(0.8f, 1.2f);
            person[j].transform.localScale = new Vector3(scaletmp,scaletmp,scaletmp);
            person[j].GetComponent<UnityEngine.AI.NavMeshAgent>().speed = Random.Range(3.0f, 4.0f);
        }
    }
}
