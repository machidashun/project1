using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electricity : MonoBehaviour
{
    public GameObject[] obj;
    Retry retry;

    void Start()
    {
        retry = GameObject.Find("ControlSystem").GetComponent<Retry>();
    }

    void Update()
    {

    }

    void OnTriggerEnter(Collider hit)
    {
        if(gameObject.GetComponent<Electricity>().enabled)
        {
            if(hit.gameObject.tag == "Water")
            {
                Vector3 pos = hit.gameObject.transform.position;
                GameObject createobj = Instantiate(obj[0],new Vector3(pos.x, pos.y, pos.z), Quaternion.identity);
                createobj.transform.localScale = hit.gameObject.transform.localScale;
                //gameObject.GetComponent<Electricity>().enabled = false;
                Destroy(hit.gameObject);
            }
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == "Player")
        {
            Destroy(hit.gameObject);
            retry.REtry();
        }
    }

    /* void OnTriggerExit(Collider hit)
    {
        if(hit.gameObject.tag == "Electricity")
        {
            if(hit.gameObject.GetComponent<Electricity>().enabled)
            {
                Vector3 pos = hit.gameObject.transform.position;
                GameObject createobj = Instantiate(obj[1],new Vector3(pos.x, pos.y, pos.z), Quaternion.identity);
                createobj.transform.localScale = transform.localScale;
                Destroy(hit.gameObject);
            }

        }
    } */

}
