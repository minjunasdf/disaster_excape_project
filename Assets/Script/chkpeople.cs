using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chkpeople : MonoBehaviour
{
    public int peoplenum;
    Vector3[] roompos = new Vector3[9];
    float[] pos = new float[3];
    float roomsize = 3.5f;

    // Start is called before the first frame update
    void Start()
    {
        pos[0]=7f;
        pos[1]=0f;
        pos[2]=-7f;
        for(int i = 0; i < 9; i++)
        {
            roompos[i] = new Vector3(pos[i / 3], 1, pos[(10-i) % 3]);
        }
    }

    // Update is called once per frame
    public void PeopleHasExited()
    {
        peoplenum--;
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "RescueNeeded")
        {
            peoplenum++;
            //Debug.Log("123"+peoplenum);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "RescueNeeded") peoplenum--;
    }
}