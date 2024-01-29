using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    Transform myTransform;
    float expscale = 0.7f;
    void Start()
    {
        myTransform = transform;
        InvokeRepeating("ExpandingON",Random.Range(1,3),Random.Range(0.5f,1f));
        //localScale = new Vector3(2, 1, 1);
        
    }

    void ExpandingON()
    {
       
        if(expscale + 0.1f < 2)
        {
            expscale += 0.1f;
            myTransform.localScale = new Vector3(expscale,expscale,expscale);
        }
        else
        {
            expscale = 2;
            CancelInvoke("ExpandingON");
            myTransform.localScale = new Vector3(expscale,expscale,expscale);
        }
        //14:50
    }
}
