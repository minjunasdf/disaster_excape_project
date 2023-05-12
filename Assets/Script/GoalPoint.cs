using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GoalPoint : MonoBehaviour
{
    // Start is called before the first frame update
    int goalPosition;

    // Update is called once per frame
    void Update()
    {
        goalPosition = GameObject.Find("Area").GetComponent<ExcapeAgent>().exit;

        switch (goalPosition)
        {
            case 0:
                this.transform.localPosition = new Vector3(-7, 1, 7);
                break;
            case 1:
                this.transform.localPosition = new Vector3(0, 1, 7);
                break;
            case 2:
                this.transform.localPosition = new Vector3(7, 1, 7);
                break;
            case 3:
                this.transform.localPosition = new Vector3(-7, 1, 0);
                break;
            case 4:
                this.transform.localPosition = new Vector3(0, 1, 0);
                break;
            case 5:
                this.transform.localPosition = new Vector3(7, 1, 0);
                break;
            case 6:
                this.transform.localPosition = new Vector3(-7, 1, -7);
                break;
            case 7:
                this.transform.localPosition = new Vector3(0, 1, -7);
                break;
            case 8:
                this.transform.localPosition = new Vector3(7, 1, -7);
                break;
        }
    }
}
