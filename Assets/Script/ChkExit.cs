using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChkExit : MonoBehaviour
{
    public int personIndex; // person의 인덱스이면서 일련번호
    public int episodeMade;

    void Start()
    {

    }

    public void ItExcaped()
    {
        Debug.Log("Exc: "+personIndex);
        GameObject.Find("Area").GetComponent<ExcapeAgent>().SomeoneHasExited();
        IWantToDie();
    }

    public void IWantToDie()
    {
        GameObject.Find("Area").GetComponent<CreateRescueNeeded>().person[personIndex] = null;
        Destroy(this.gameObject);
    }

    //public void Kill() { Destroy(this.gameObject); }
}
