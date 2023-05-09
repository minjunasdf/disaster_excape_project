using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChkExit : MonoBehaviour
{
    public GameObject exitArea;
    public GameObject Area;
    // Start is called before the first frame update
    void Start()
    {
        exitArea = GameObject.Find("ExitArea");
        Area = GameObject.Find("Area");
    }

    private void OnTriggerEnter(Collider collision)
    {

        if (collision.GetComponent<Collider>().gameObject.CompareTag("Exit"))
        {
            Debug.Log("Exited");
            exitArea.GetComponent<Chkpeople>().PeopleHasExited();
            Area.GetComponent<ExcapeAgent>().SomeoneHasExited();
            Destroy(this.gameObject);
         }
    }
}
