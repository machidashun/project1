using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class IceControl : MonoBehaviour
{
    public GameObject[] obj;
    public bool changeFlag;
    //public int[] layers;
    Push push;
    WaterControl waterControl;
    void Start()
    {
        changeFlag = true;
        /* layers = new int[3];
        layers[0] = LayerMask.NameToLayer("Ice");
        layers[1] = LayerMask.NameToLayer("Player");
        layers[2] = LayerMask.NameToLayer("icethatdoesn'tmelt");
        Physics.IgnoreLayerCollision(layers[0], layers[1],true); */
        if(GameObject.FindWithTag("Push")) push = GameObject.FindWithTag("Push").GetComponent<Push>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G) && !Input.GetKeyDown(KeyCode.H) && changeFlag && !Input.GetKeyDown ("joystick button 5") && !Input.GetKeyDown ("joystick button 4") || Input.GetKeyDown ("joystick button 5") && !Input.GetKeyDown ("joystick button 4") && changeFlag && !Input.GetKeyDown(KeyCode.G) && !Input.GetKeyDown(KeyCode.H))
        {
            Transform myTransform = this.transform;
            Vector3 pos = myTransform.position;

            GameObject createobj = Instantiate(obj[0],new Vector3(pos.x, pos.y, pos.z), Quaternion.identity);
            createobj.transform.localScale = transform.parent.transform.localScale;
            createobj.name = transform.parent.gameObject.name;
            //Instantiate(obj[0], new Vector3(pos.x, pos.y, pos.z), Quaternion.identity);
            Destroy(transform.parent.gameObject);
        }

        if(Input.GetKeyDown(KeyCode.H) && !Input.GetKeyDown(KeyCode.G) && changeFlag  && !Input.GetKeyDown ("joystick button 5") && !Input.GetKeyDown ("joystick button 4") || Input.GetKeyDown ("joystick button 4") && !Input.GetKeyDown ("joystick button 5") && changeFlag && !Input.GetKeyDown(KeyCode.G) && !Input.GetKeyDown(KeyCode.H))
        {
            Transform myTransform = this.transform;
            Vector3 pos = myTransform.position;

            GameObject createobj = Instantiate(obj[1],new Vector3(pos.x, pos.y, pos.z), Quaternion.identity);
            createobj.transform.localScale = transform.parent.transform.localScale;
            createobj.name = transform.parent.gameObject.name;
            /* waterControl = createobj.GetComponent<WaterControl>();

            if(transform.parent.gameObject.GetComponent<IceDummyControl>().IsInvoking("Right"))
            {
                waterControl.InvokeRepeating("Right",0,push.speed);
            }
            else if(transform.parent.gameObject.GetComponent<IceDummyControl>().IsInvoking("Left"))
            {
                waterControl.InvokeRepeating("Left",0,push.speed);
            }
            else if(transform.parent.gameObject.GetComponent<IceDummyControl>().IsInvoking("Up"))
            {
                waterControl.InvokeRepeating("Up",0,push.speed);
            }
            else if(transform.parent.gameObject.GetComponent<IceDummyControl>().IsInvoking("Under"))
            {
                waterControl.InvokeRepeating("Under",0,push.speed);
            } */
            //Instantiate(obj[1], new Vector3(pos.x, pos.y, pos.z), Quaternion.identity);
            Destroy(transform.parent.gameObject);
        }
    }

}
