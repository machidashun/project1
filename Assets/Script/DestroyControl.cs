using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyControl : MonoBehaviour
{
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision hit)
    {
        if(hit.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
