using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChkExit : MonoBehaviour
{
    public int personIndex; // person�� �ε����̸鼭 �Ϸù�ȣ
    public int episodeMade;

    void Start()
    {

    }

    public void ItExcaped()
    {
        //Debug.Log("Exc: "+personIndex);
        GameObject.Find("Area").GetComponent<ExcapeAgent>().remainPeople -= 1;
        GameObject.Find("Area").GetComponent<ExcapeAgent>().SomeoneHasExited();
        IWantToDie();
    }

    public void IWantToDie()
    {
        //GameObject.Find("Area").GetComponent<CreateRescueNeeded>().person[personIndex].SetActive(false);
        this.gameObject.SetActive(false);
    }

    //public void Kill() { Destroy(this.gameObject); }
}
