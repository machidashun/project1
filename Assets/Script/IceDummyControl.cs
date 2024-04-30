using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceDummyControl : MonoBehaviour
{
    int[] layers;

    void Start()
    {
        Invoke("Materialization",0.2f);
        layers = new int[2];
        layers[0] = LayerMask.NameToLayer("Ice");
        layers[1] = LayerMask.NameToLayer("Player");
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
