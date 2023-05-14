using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorDisaster : MonoBehaviour
{
    private GameObject Area;
    public GameObject DoorFire;
    public GameObject DoorCrash;
    private double riskRate;
    private double fireProb;
    public bool onFire;
    public bool isRisky;
    private double prob;

    void Start()
    {
        Area = GameObject.Find("Area");

    }

    void Update()
    {
        
        transform.Translate(Vector3.back);
        if (Area.GetComponent<ExcapeAgent>().disasterType % 2 == 0) // ÁöÁø
        {
            prob = Random.Range(0f, 1f);
            if (prob < riskRate)
            {
                isRisky = true;
                Instantiate(DoorCrash, this.transform.position, Quaternion.identity);
            }
        }
        transform.Translate(Vector3.forward);

        prob = Random.Range(0f, 1f);
        if (prob < fireProb)
        {
            onFire = true;
            Instantiate(DoorFire, this.transform.position, Quaternion.identity);
        }
    }

    public void Init()
    {
        if (Area.GetComponent<ExcapeAgent>().disasterType % 2 == 0)
        {
            riskRate = 10e-6;
        }
        fireProb = 0;
        onFire = false;
        riskRate = 0;
        isRisky = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Contains("room"))
        {
            //Debug.Log("asdf");
            if (other.GetComponent<RoomDisaster>().isRisky)
            {
                riskRate += 10e-7;
            }
            if (other.GetComponent<RoomDisaster>().onFire)
            {
                fireProb += 10e-7;
            }
        }
    }
}