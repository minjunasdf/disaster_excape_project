using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmIBurning : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("fire"))
        {
            GameObject.Find("Area").GetComponent<ExcapeAgent>().SomeoneHasDied();
            this.GetComponent<ChkExit>().IWantToDie();
        }
    }
}
