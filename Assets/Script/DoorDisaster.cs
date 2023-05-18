using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorDisaster : MonoBehaviour
{
    private GameObject Area;
    public GameObject DoorFire;
    public GameObject DoorCrash;
    public GameObject SpawnedFire;
    public GameObject SpawnedCrash;
    public double riskRate;
    public double fireProb;
    public bool onFire;
    public bool isRisky;
    private bool exitDoor;
    private double prob;
    public GameObject[] RoomsThatAreNear = new GameObject[2];

    void Start()
    {
        Area = GameObject.Find("Area");
        SpawnedFire = Instantiate(DoorFire, this.transform.position, Quaternion.identity);
        SpawnedCrash = Instantiate(DoorCrash, this.transform.position, Quaternion.identity);
    }

    void Update()
    {
        for(int i = 0; i < 2; i++)
        {
            if (RoomsThatAreNear[i] != null && onFire == false)
            {
                if (RoomsThatAreNear[i].GetComponent<RoomDisaster>().onFire)
                {
                    fireProb += 5*10e-6;
                }
            }
            if (RoomsThatAreNear[i] != null && isRisky == false)
            {
                if (RoomsThatAreNear[i].GetComponent<RoomDisaster>().isRisky)
                {
                    riskRate += 10e-6;
                }
            }
            if(RoomsThatAreNear[i].GetComponent<RoomDisaster>().isExit)
            {
                exitDoor = true;
            }
        }

        if(onFire == false && Area.GetComponent<ExcapeAgent>().disasterType > 0)
        {
            prob = Random.Range(0f, 1f);
            if(prob < fireProb)
            {
                onFire = true;
                SpawnedFire.SetActive(true);
            }
        }
        if(isRisky == false && Area.GetComponent<ExcapeAgent>().disasterType % 2 == 0 && exitDoor==false)
        {
            prob=Random.Range(0f, 1f);
            if(prob<riskRate)
            {
                isRisky= true;
                SpawnedCrash.SetActive(true);
            }
        }

    }

    public void Init()
    {
        SpawnedFire.SetActive(false);
        SpawnedCrash.SetActive(false);
        fireProb = 0;
        if (Area.GetComponent<ExcapeAgent>().disasterType ==0 || Area.GetComponent<ExcapeAgent>().disasterType==2)
        {
            riskRate = 10e-4;
        }
        else
        {
            riskRate = 0;
        }
        onFire = false;
        isRisky = false;
        exitDoor= false;
    }
}
