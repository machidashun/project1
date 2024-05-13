using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wiring : MonoBehaviour
{
    public GameObject[] obj;
    public bool situation = false;

    void Start()
    {
        situation = false;
    }

    void Update()
    {
        
    }

    void Change()
    {
        if(situation)
        {
            obj[0].SetActive(true);
        }
        else
        {
            obj[0].SetActive(false);
        }
    }

    void OnTriggerStay(Collider hit)
    { 	
        if(hit.gameObject.tag == "Electricity" && !situation)
        {
            situation = true;
            Change();
        }

        /* if(hit.gameObject.tag == "Electricity" && hit.gameObject == false)
        {
    
        } */

        if(hit.gameObject.tag == "IceDummy" && situation || hit.gameObject.tag == "WaterVapor" && situation)
        {
            situation = false;
            Change();
        }
    }

    void OnTriggerExit(Collider hit)
    {
        if(hit.gameObject.tag == "Electricity")
        {
            situation = false;
            Change();   
        }
    }
}
