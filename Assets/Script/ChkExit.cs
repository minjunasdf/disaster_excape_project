using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChkExit : MonoBehaviour
{
    public GameObject exitArea;
    public GameObject Area;


    void Start()
    {
        Area = GameObject.Find("Area");
    }

    public void ItExcaped()
    {
        Area.GetComponent<ExcapeAgent>().SomeoneHasExited();
        IWantToDie();
    }

    public void IWantToDie()
    {
        Destroy(this.gameObject);
    }
}
