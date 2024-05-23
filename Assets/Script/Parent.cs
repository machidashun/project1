using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parent : MonoBehaviour
{

    public GameObject player;
    void Start()
    {
        if(!IsInvoking("Move"))InvokeRepeating("Move",0,0.01f);
    }

    void OnTriggerEnter(Collider hit)
    {
        if(hit.gameObject.tag == "Ground" && hit.gameObject.GetComponent<StatusControl>().statu[0] == true)
        {
            transform.parent = hit.gameObject.transform;
        }
    }

    void OnTriggerExit(Collider hit)
    {
        if(hit.gameObject.tag == "Ground" && hit.gameObject.GetComponent<StatusControl>().statu[0] == true)
        {
            //transform.parent = null;
        }
    }

    void Move()
    {
        if(player) transform.position = player.transform.position;
    }
}
