using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject[] obj;
    SoundControl soundControl;
    bool flag;
    void Start()
    {
        soundControl = GameObject.Find("ControlSystem").GetComponent<SoundControl>();
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
                if(!flag)
                {
                    flag = true;
                    obj[0].SetActive(false);
                    soundControl.SetSE(0,5);
                }
            }
            else
            {
                if(flag)
                {
                    flag = false;
                }
                obj[0].SetActive(true);
            }
            
        }
    }
}
