using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceDummyControl : MonoBehaviour
{
    public int[] layers;
    //private Vector3 Pos;
    private Vector3 movePos;
    
    void Start()
    {

        Invoke("Materialization",0.2f);
       /*  layers = new int[2];
        layers[0] = LayerMask.NameToLayer("Ice");
        layers[1] = LayerMask.NameToLayer("Player"); */
        //transform.parent = GameObject.Find("Stage").transform;
    }
    
    /* void OnTriggerStay(Collider hit)
    {
        if(hit.gameObject.tag == "Player")
        {
            CancelInvoke("Materialization");
        }
    } */

    void OnTriggerExit(Collider hit)
    {
        if(hit.gameObject.tag == "Player")
        {
            gameObject.transform.GetChild(0).GetComponent<BoxCollider>().isTrigger = false;
            /*
            Physics.IgnoreLayerCollision(layers[0], layers[1],false);
            CancelInvoke("Right");
            CancelInvoke("Left");
            CancelInvoke("Up");
            CancelInvoke("Under"); */
        }
    }

    void OnTriggerEnter(Collider hit)
    {
        if(hit.gameObject.tag == "Player")
        {
            CancelInvoke("Materialization");
        }
        
        /* if (hit.gameObject.tag == "Ground")
        {
            Materialization();
            CancelInvoke("Right");
            CancelInvoke("Left");
            CancelInvoke("Up");
            CancelInvoke("Under");
        } */
    }

    void Materialization()
    {   
        gameObject.transform.GetChild(0).GetComponent<BoxCollider>().isTrigger = false;
        //Physics.IgnoreLayerCollision(layers[0], layers[1],false);
    }

    public void Move(Vector3 pos)//Pushオブジェクトの位置へ移動
    {
        //transform.position = pos;
        //Vector3.Lerp(transform.position, pos, 1);
    }

    public void Layersch()
    {
        //Physics.IgnoreLayerCollision(layers[0], layers[1],true);
    }

    public void Right()//→
    {
        Layersch();
        movePos = transform.position;
        movePos.x += 0.05f;
        transform.position = movePos;
    }

    public void Left()//←
    {
        Layersch();
        movePos = transform.position;
        movePos.x -= 0.05f;
        transform.position = movePos;
    }

    public void Up()//↑
    {
        Layersch();
        movePos = transform.position;
        movePos.y += 0.05f;
        transform.position = movePos;
    }

    public void Under()//↓
    {
        Layersch();
        movePos = transform.position;
        movePos.y -= 0.05f;
        transform.position = movePos;
    }
}
