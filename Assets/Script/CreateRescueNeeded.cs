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
  int tmpNum = 0;
  public GameObject[] SpawnPoint = new GameObject[90]; // Make Spawnpoint objects
  public GameObject[] Rooms = new GameObject[9]; // Get Room objects
  public GameObject[] person = new GameObject[100];
  float scaletmp;

  public void Init(int episodes)
  {
    tmpNum = 0;
    random_number = new int[totalPeopleNum];
    person = new GameObject[totalPeopleNum];
    for (int i = 0; i < totalPeopleNum; i++)
    {
      bool ongoing = true;
      while (ongoing)
      {
        tmpNum = Random.Range(0, 90);
        ongoing = false;
        if (this.GetComponent<ExcapeAgent>().exit == (int)(tmpNum / 10) || this.GetComponent<ExcapeAgent>().fire == (int)(tmpNum / 10)) ongoing = true;
        for (int j = 0; j < i; j++)
        {
          if (tmpNum == random_number[j] || this.GetComponent<ExcapeAgent>().exit == (int)(tmpNum / 10) || this.GetComponent<ExcapeAgent>().fire == (int)(tmpNum / 10))
          {
            ongoing = true;
            break;
          }
        }
      }
      random_number[i] = tmpNum;
    }

    for (int j = 0; j < totalPeopleNum; j++)
    {
      if (episodes == 1)
      {
        person[j] = Instantiate(RescueObject, SpawnPoint[random_number[j]].transform.position, Quaternion.identity);
        person[j].transform.SetParent(GameObject.Find("Parent").transform);
        person[j].name = "people" + j.ToString();
        person[j].GetComponent<ChkExit>().personIndex = j;
      }
      GameObject tmp = GameObject.Find("Parent").transform.GetChild(j).gameObject;
      tmp.SetActive(false);
      tmp.transform.position = SpawnPoint[random_number[j]].transform.position;
      tmp.GetComponent<ChkExit>().episodeMade = episodes;
      scaletmp = Random.Range(0.8f, 1.2f);
      tmp.transform.localScale = new Vector3(scaletmp, scaletmp, scaletmp);
      tmp.GetComponent<UnityEngine.AI.NavMeshAgent>().speed = Random.Range(3.0f, 4.0f);
      tmp.SetActive(true);
      person[j] = tmp;
    }
  }
}