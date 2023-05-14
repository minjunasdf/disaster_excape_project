using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChkExit : MonoBehaviour
{
    private GameObject Area;
    public int personIndex; // person�� �ε����̸鼭 �Ϸù�ȣ

    void Start()
    {
        Area = GameObject.Find("Area");
    }

    public void ItExcaped()
    {
        Debug.Log("Exc: "+personIndex);
        Area.GetComponent<ExcapeAgent>().SomeoneHasExited();
        IWantToDie();
    }

    public void IWantToDie()
    {
        Area.GetComponent<CreateRescueNeeded>().person[personIndex] = null;
        Destroy(this.gameObject);
    }

    //public void Kill() { Destroy(this.gameObject); }
}
