using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject[] obj;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

     void OnTriggerStay(Collider hit)
    { 	
        if(hit.gameObject.tag == "Wiring")
        {
            if(hit.gameObject.GetComponent<Wiring>().situation)
            {
                obj[0].SetActive(false);
            }
            else
            {
                obj[0].SetActive(true);
            }
            
        }
    }
}
