using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chkExit : MonoBehaviour
{
    public GameObject exitArea;
    // Start is called before the first frame update
    void Start()
    {
        exitArea = GameObject.Find("ExitArea");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.gameObject.CompareTag("Exit"))
        {
            Debug.Log("Exited");
            exitArea.GetComponent<chkpeople>().PeopleHasExited();
            Destroy(this.gameObject);
        }
    }
}
