using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WaterControl : MonoBehaviour
{
    public GameObject[] obj;
    void Start()
    {
    
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && !Input.GetKeyDown(KeyCode.H))
        {
            Transform myTransform = this.transform;
            Vector3 pos = myTransform.position;

            Instantiate(obj[0], new Vector3(pos.x, pos.y, pos.z), Quaternion.identity);
            Destroy(gameObject);
        }

        if (Input.GetKeyDown(KeyCode.H) && !Input.GetKeyDown(KeyCode.G))
        {
            Transform myTransform = this.transform;
            Vector3 pos = myTransform.position;

            Instantiate(obj[1], new Vector3(pos.x, pos.y, pos.z), Quaternion.identity);
            Destroy(gameObject);
        }
    }

   void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.tag == "Oil")
        {
            Destroy(gameObject);
        }

        if (hit.gameObject.tag == "Fire")
        {
            Transform myTransform = this.transform;
            Vector3 pos = myTransform.position;

            Instantiate(obj[1], new Vector3(pos.x, pos.y , pos.z), Quaternion.identity);
            hit.gameObject.tag = "wood"; 
            hit.gameObject.layer = 13; 
            Destroy(hit.gameObject.transform.GetChild(0).gameObject);
            Destroy(gameObject);
        }
    }
}
