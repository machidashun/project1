using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    public bool[] saveNumber = {false,false,false};

    void Start()
    {
        //retry = GameObject.Find("ControlSystem").GetComponent<Retry>();
    }

    void OnTriggerStay(Collider hit)
    {
        if(hit.gameObject.tag == "Player")
        {
            if(gameObject.tag == "SavePoint3")
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
