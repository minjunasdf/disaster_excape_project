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

    void Start()
    {
        Area = GameObject.Find("Area");
        if (Area.GetComponent<CreateRescueNeeded>().disasterType > 0)
        {
            fireProb = 10e-1;
        }
        fireProb = 0;
        onFire = false;
        isRisky = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.tag);
        if (other.CompareTag("door"))
        {
            Debug.Log("asdf");
            if (other.GetComponent<DoorDisaster>().onFire)
            {
                fireProb += 10e-5;
                prob = Random.Range(0f, 1f);
                if (prob < fireProb)
                {
                    onFire = true;
                    Instantiate(RoomFire, this.transform.position, Quaternion.identity);

                }
            }
            if (other.GetComponent<DoorDisaster>().isRisky) isRisky = true;
        }
    }
}
