using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDisaster : MonoBehaviour
{
    private GameObject Area;
    public GameObject RoomFire;
    public GameObject SpawnedFire;
    private double fireProb;
    public bool onFire;
    public bool isRisky;
    private double prob;
    public GameObject[] DoorsThatAreNear = new GameObject[4];

    void Start()
    {
        Area = GameObject.Find("Area");
    }
    
    void Update()
    {
        for(int i = 0; i < 4; i++)
        {
            if (DoorsThatAreNear[i] != null && onFire == false)
            {
                if (DoorsThatAreNear[i].GetComponent<DoorDisaster>().onFire)
                {
                    fireProb += 10e-5;
                }
            }
        }
        if (onFire == false)
        {
            prob = Random.Range(0f, 1f);
            if (prob < fireProb)
            {
                onFire = true;
                SpawnedFire = Instantiate(RoomFire, transform.position, Quaternion.identity);
            }
        }
        
    }

    public void Init()
    {
        Destroy(SpawnedFire);
        fireProb = 0;
        if (onFire)
        {
            SpawnedFire=Instantiate(RoomFire, this.transform.position, Quaternion.identity);
        }
        isRisky = false;
    }
}
