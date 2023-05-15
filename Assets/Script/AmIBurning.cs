using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmIBurning : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("fire"))
        {
            Debug.Log("FIRE"+this.GetComponent<ChkExit>().personIndex+" "+this.GetComponent<ChkExit>().episodeMade);
            GameObject.Find("Area").GetComponent<ExcapeAgent>().remainPeople -= 1;
            GameObject.Find("Area").GetComponent<ExcapeAgent>().SomeoneHasDied();
            this.GetComponent<ChkExit>().IWantToDie();
        }
    }
}
