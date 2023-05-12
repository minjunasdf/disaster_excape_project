using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChkExit : MonoBehaviour
{
    public GameObject Area;
    public int personIndex; // person�� �ε����̸鼭 �Ϸù�ȣ

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
        Area.GetComponent<CreateRescueNeeded>().person[personIndex]=null;
    }
}
