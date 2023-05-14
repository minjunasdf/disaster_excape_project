using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDisaster : MonoBehaviour
{
    private GameObject Area;
    public GameObject RoomFire;
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
        prob = Random.Range(0f, 1f);
        if (prob < fireProb)
        {
            onFire = true;
            Instantiate(RoomFire, transform.position, Quaternion.identity);
        }
    }

    public void Init()
    {
        fireProb = 0;
        if (onFire)
        {
            Instantiate(RoomFire, this.transform.position, Quaternion.identity);
        }
        isRisky = false;
    }
}
