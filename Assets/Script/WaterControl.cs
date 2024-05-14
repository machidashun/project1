using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WaterControl : MonoBehaviour
{
    public GameObject[] obj;
    private Vector3 movePos;
    public Rigidbody rb;
    Push push;
    void Start()
    {
        transform.parent = GameObject.Find("Stage").transform;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        /* Debug.Log(IsInvoking("Right"));
        Debug.Log(IsInvoking("Left"));
        Debug.Log(IsInvoking("Up"));
        Debug.Log(IsInvoking("Under")); */
        if (Input.GetKeyDown(KeyCode.G) && !Input.GetKeyDown(KeyCode.H))
        {
            Transform myTransform = this.transform;
            Vector3 pos = myTransform.position;

            //Instantiate(obj[0], new Vector3(pos.x, pos.y, pos.z), Quaternion.identity);
            GameObject createobj = Instantiate(obj[0],new Vector3(pos.x, pos.y, pos.z), Quaternion.identity);
            createobj.transform.localScale = transform.localScale;

            /* push = GameObject.FindWithTag("Push").GetComponent<Push>();
            
            if(IsInvoking("Right"))
            { 
                createobj.GetComponent<IceDummyControl>().Layersch();
                createobj.GetComponent<IceDummyControl>().InvokeRepeating("Right",0,push.speed);
            }
            else if(IsInvoking("Left"))
            {
                createobj.GetComponent<IceDummyControl>().Layersch();
                createobj.GetComponent<IceDummyControl>().InvokeRepeating("Left",0,push.speed);
            }
            else if(IsInvoking("Up"))
            {
                createobj.GetComponent<IceDummyControl>().Layersch();
                createobj.GetComponent<IceDummyControl>().InvokeRepeating("Up",0,push.speed);
            }
            else if(IsInvoking("Under"))
            {
                createobj.GetComponent<IceDummyControl>().Layersch();
                createobj.GetComponent<IceDummyControl>().InvokeRepeating("Under",0,push.speed);
            } */

            Destroy(gameObject);
        }

        if (Input.GetKeyDown(KeyCode.H) && !Input.GetKeyDown(KeyCode.G))
        {
            Transform myTransform = this.transform;
            Vector3 pos = myTransform.position;
            
            GameObject createobj = Instantiate(obj[1],new Vector3(pos.x, pos.y, pos.z), Quaternion.identity);
            createobj.transform.localScale = transform.localScale;

            //Instantiate(obj[1], new Vector3(pos.x, pos.y, pos.z), Quaternion.identity);
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

            GameObject createobj = Instantiate(obj[1],new Vector3(pos.x, pos.y, pos.z), Quaternion.identity);
            createobj.transform.localScale = transform.localScale;
            
            hit.gameObject.tag = "wood"; 
            hit.gameObject.layer = 13; 
            Destroy(hit.gameObject.transform.GetChild(0).gameObject);
            Destroy(gameObject);
        }

        if (hit.gameObject.tag == "Fireball")
        {
            Transform myTransform = this.transform;
            Vector3 pos = myTransform.position;

            GameObject createobj = Instantiate(obj[1],new Vector3(pos.x, pos.y, pos.z), Quaternion.identity);
            createobj.transform.localScale = transform.localScale;
            Destroy(hit.gameObject.transform.parent.gameObject);
            Destroy(gameObject);
        }

        if (hit.gameObject.tag == "Ground")
        {
            rb.useGravity = true;
            CancelInvoke("Right");
            CancelInvoke("Left");
            CancelInvoke("Up");
            CancelInvoke("Under");
        }
    }

    public void Move(Vector3 pos)//Pushオブジェクトの位置へ移動
    {
        transform.position = pos;
        //Vector3.Lerp(transform.position, pos, 0.3f);
    }

    public void Right()//→
    {
        rb.useGravity = false;
        movePos = transform.position;
        movePos.x += 0.05f;
        transform.position = movePos;
        
    }

    public void Left()//←
    {
        rb.useGravity = false;
        movePos = transform.position;
        movePos.x -= 0.05f;
        transform.position = movePos;
    }

    public void Up()//↑
    {
        rb.useGravity = false;
        movePos = transform.position;
        movePos.y += 0.05f;
        transform.position = movePos;
    }

    public void Under()//↓
    {
        rb.useGravity = false;
        movePos = transform.position;
        movePos.y -= 0.05f;
        transform.position = movePos;
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
