using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDisaster : MonoBehaviour
{
    private GameObject Area;
    public GameObject RoomFire;
    public GameObject SpawnedFire;
    public double fireProb;
    public bool onFire;
    public bool isRisky;
    public bool isExit;
    private double prob;
    public GameObject[] DoorsThatAreNear = new GameObject[4];

    void Start()
    {
        Area = GameObject.Find("Area");
        SpawnedFire = Instantiate(RoomFire, this.transform.position, Quaternion.identity);
        isExit = false;
    }
    
    void Update()
    {
        for(int i = 0; i < 4; i++)
        {
            if (DoorsThatAreNear[i] != null && onFire == false && isExit == false)
            {
                if (DoorsThatAreNear[i].GetComponent<DoorDisaster>().onFire)
                {
                    fireProb += 10e-7;
                }
            }
            if (DoorsThatAreNear[i]!=null && isRisky==false&& isExit == false)
            {
                if (DoorsThatAreNear[i].GetComponent<DoorDisaster>().isRisky)
                {
                    isRisky = true;
                }
            }
        }
        if (onFire == false && Area.GetComponent<ExcapeAgent>().disasterType > 0)
        {
            prob = Random.Range(0f, 1f);
            if (prob < fireProb)
            {
                onFire = true;
                SpawnedFire.SetActive(true);
            }
        }
    }

    public void Init()
    {
        SpawnedFire.SetActive(false);
        fireProb = 0;
        isRisky = false;
        if (onFire && Area.GetComponent<ExcapeAgent>().disasterType > 0)
        {
            SpawnedFire.SetActive(true);
        }
    }
}
