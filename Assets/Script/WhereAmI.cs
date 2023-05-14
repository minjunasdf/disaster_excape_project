using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhereAmI : MonoBehaviour
{
    public int position;


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("room1")) position = 1;
        else if (other.CompareTag("room2")) position = 2;
        else if (other.CompareTag("room3")) position = 3;
        else if (other.CompareTag("room4")) position = 4;
        else if (other.CompareTag("room5")) position = 5;
        else if (other.CompareTag("room6")) position = 6;
        else if (other.CompareTag("room7")) position = 7;
        else if (other.CompareTag("room8")) position = 8;
        else if (other.CompareTag("room0")) position = 0;

        if(position == GameObject.Find("Area").GetComponent<ExcapeAgent>().exit)
        {
            //Debug.Log(this.GetComponent<ChkExit>().episodeMade+" "+GameObject.Find("Area").GetComponent<ExcapeAgent>().episodes);
            this.GetComponent<ChkExit>().ItExcaped();
        }
    }
}
