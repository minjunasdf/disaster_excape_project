using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chkpeople : MonoBehaviour
{
    public int peoplenum;


    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("RescueNeeded"))
        {
            peoplenum++;
            //Debug.Log("123"+peoplenum);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("RescueNeeded")) peoplenum--;
    }
}
