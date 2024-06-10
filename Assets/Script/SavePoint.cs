using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    public bool[] saveNumber = {false,false,false,false,false,false,false,false,false,false};

    void Start()
    {
        //retry = GameObject.Find("ControlSystem").GetComponent<Retry>();
    }

    void OnTriggerStay(Collider hit)
    {
        if(hit.gameObject.tag == "Player")
        {
            if(gameObject.tag == "SavePoint10")
            {
                Retry.saveNumber[9] = true; 
            }
            else if(gameObject.tag == "SavePoint9")
            {
                Retry.saveNumber[8] = true;
            }
            else if(gameObject.tag == "SavePoint8")
            {
                Retry.saveNumber[7] = true;
            }
            else if(gameObject.tag == "SavePoint7")
            {
                Debug.Log(12);
                Retry.saveNumber[6] = true; 
            }
            else if(gameObject.tag == "SavePoint6")
            {
                Retry.saveNumber[5] = true;
            }
            else if(gameObject.tag == "SavePoint5")
            {
                Retry.saveNumber[4] = true;
            }
            else if(gameObject.tag == "SavePoint4")
            {
                Retry.saveNumber[3] = true; 
            }
            else if(gameObject.tag == "SavePoint3")
            {
                Retry.saveNumber[2] = true;
            }
            else if(gameObject.tag == "SavePoint2")
            {
                Retry.saveNumber[1] = true;
            }
            else if(gameObject.tag == "SavePoint1")
            {
                Retry.saveNumber[0] = true;
            }
        }
    }
}
