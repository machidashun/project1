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
        if(hit.gameObject.tag == "Electricity" && !situation || hit.gameObject.tag == "Wiring" && !situation && hit.gameObject.GetComponent<Wiring>().situation)
        {
            situation = true;
            Change();
        }
        
        if(hit.gameObject.tag == "IceDummy" && situation || hit.gameObject.tag == "WaterVapor" && situation)
        {
            situation = false;
            Change();
        }

        if(hit.gameObject.tag == "Water" && situation && hit.gameObject.GetComponent<WaterControl>().electrification)
        {
            hit.gameObject.GetComponent<WaterControl>().electrification = false;
            Vector3 pos = hit.gameObject.transform.position;
            GameObject createobj = Instantiate(obj[1],new Vector3(pos.x, pos.y, pos.z), Quaternion.identity);
            createobj.transform.localScale = hit.gameObject.transform.localScale;
            createobj.name = hit.gameObject.name;
            //gameObject.GetComponent<Electricity>().enabled = false;
            Destroy(hit.gameObject);
        }
    }

    void OnTriggerExit(Collider hit)
    {
        if(hit.gameObject.tag == "Electricity" || hit.gameObject.tag == "Wiring" && situation)
        {
            situation = false;
            Change();   
        }
    }

    /* void OnBecameVisible()
    {
        gameObject.SetActive(true);
    }
    
    void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }     */
}
