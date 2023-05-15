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
        for(int i = 0; i < 10; i++)  // totalpeoplenum
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
                        break;
                    }
                }
            }
            //Debug.Log(g);
            random_number[i] = g;
        }

        for (int j = 0; j < 10; j++) // totalpeoplenum
        {
            if (episodes == 1)
            {
                person[j] = Instantiate(RescueObject, SpawnPoint[random_number[j]].transform.position, Quaternion.identity);
                person[j].transform.SetParent(GameObject.Find("Parent").transform);
                person[j].name = "people"+j.ToString();
                person[j].GetComponent<ChkExit>().personIndex = j;
            }
            GameObject tmp = GameObject.Find("Parent").transform.GetChild(j).gameObject;
            tmp.SetActive(false);
            tmp.transform.position = SpawnPoint[random_number[j]].transform.position;
            tmp.GetComponent<ChkExit>().episodeMade = episodes;
            scaletmp = Random.Range(0.8f, 1.2f);
            tmp.transform.localScale = new Vector3(scaletmp,scaletmp,scaletmp);
            tmp.GetComponent<UnityEngine.AI.NavMeshAgent>().speed = Random.Range(3.0f, 4.0f);
            tmp.SetActive(true);
            person[j] = tmp;
        }
    }
}
