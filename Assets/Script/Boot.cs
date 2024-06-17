using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boot : MonoBehaviour
{
    CommonMechanism commonMechanism;
    void Start()
    {
        commonMechanism = transform.parent.gameObject.GetComponent<CommonMechanism>();
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

    /* void OnTriggerExit(Collider hit)
    {
        if(hit.gameObject.tag == "Player")
        {
            
        }
    } */

    void OnTriggerEnter(Collider hit)
    {
        if(hit.gameObject.tag == "Player" && commonMechanism.mode[0])
        {
           if(commonMechanism.xmove[0] || commonMechanism.xmove[1])
            {
                if(!commonMechanism.IsInvoking("MoveX"))commonMechanism.InvokeRepeating("MoveX",0,0.01f);                       
            }

            if(commonMechanism.ymove[0] || commonMechanism.ymove[1])
            {
                if(!commonMechanism.IsInvoking("MoveY"))commonMechanism.InvokeRepeating("MoveY",0,0.01f);                       
            }
        }
    }
}
