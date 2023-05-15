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
                    fireProb += 10e-7;
                }
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

    }

    public void Init()
    {
        SpawnedFire.SetActive(false);
        SpawnedCrash.SetActive(false);
        fireProb = 0;
        riskRate = 0;
        onFire = false;
        isRisky = false;
    }
}