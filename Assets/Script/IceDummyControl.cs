using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceDummyControl : MonoBehaviour
{
    int[] layers;

    void Start()
    {
        //Debug.Log(12);
        Invoke("Materialization",0.5f);
        layers = new int[2];
        layers[0] = LayerMask.NameToLayer("Ice");
        layers[1] = LayerMask.NameToLayer("Player");
        transform.parent = GameObject.Find("Stage").transform;
    }
    
    void OnTriggerStay(Collider hit)
    {
        if(hit.gameObject.tag == "Player")
        {
            Debug.Log(12);
            CancelInvoke("Materialization");
        }
    }

    void OnTriggerExit(Collider hit)
    {
        if(hit.gameObject.tag == "Player")
        {
            Physics.IgnoreLayerCollision(layers[0], layers[1],false);
        }
    }

    void Materialization()
    {   
        Physics.IgnoreLayerCollision(layers[0], layers[1],false);
    }
}
