using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WaterVaporControl : MonoBehaviour
{
    public GameObject[] obj;
    Transform myTransform;
    Vector3 pos;
    void Start()
    {
        myTransform = this.transform;
        pos = this.transform.position;
        if(!IsInvoking("Rise"))InvokeRepeating("Rise",0.5f,0.01f);
        //transform.parent = GameObject.Find("Stage").transform;
        
    }

    void Update()
    {
        if (Time.timeScale != 0 && Input.GetKeyDown ("joystick button 5") && !Input.GetKeyDown ("joystick button 4"))
        {
            Transform myTransform = this.transform;
            Vector3 pos = myTransform.position;
            GameObject createobj = Instantiate(obj[0],new Vector3(pos.x, pos.y, 0), Quaternion.identity);
            createobj.transform.localScale = transform.localScale;
            createobj.name = gameObject.name;
            Destroy(gameObject);
        }

        if (Time.timeScale != 0 && Input.GetKeyDown ("joystick button 4") && !Input.GetKeyDown ("joystick button 5"))
        {
            Transform myTransform = this.transform;
            Vector3 pos = myTransform.position;

            GameObject createobj = Instantiate(obj[1],new Vector3(pos.x, pos.y, 0), Quaternion.identity);
            createobj.transform.localScale = transform.localScale;
            //Instantiate(obj[1],new Vector3(pos.x, pos.y, 0), Quaternion.identity);
            createobj.name = gameObject.name;
            Destroy(gameObject);
        }
    }

    void Rise()
    {
        pos = this.transform.position;
        
        pos.y += 0.009f;
        myTransform.position = new Vector3(pos.x,pos.y,0);
        
    }

   void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.tag == "Ventilationfan")
        {
            Destroy(gameObject);
        }

        if (hit.gameObject.tag == "Ground" && hit.gameObject.GetComponent<StatusControl>().statu[1] == true)
        {
            CancelInvoke("Rise");
        }
    }
}
