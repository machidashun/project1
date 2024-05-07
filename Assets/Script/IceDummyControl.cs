using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceDummyControl : MonoBehaviour
{
    int[] layers;
    //private Vector3 Pos;
    private Vector3 movePos;
    
    void Start()
    {
        //Debug.Log(12);
        Invoke("Materialization",0.5f);
        layers = new int[2];
        layers[0] = LayerMask.NameToLayer("Ice");
        layers[1] = LayerMask.NameToLayer("Player");
        transform.parent = GameObject.Find("Stage").transform;
    }
    
    void OnTriggerStay(Collider hit)
    {
        if(hit.gameObject.tag == "Player")
        {
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

    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "Ground")
        {
            CancelInvoke("Right");
            CancelInvoke("Left");
            CancelInvoke("Up");
            CancelInvoke("Under");
        }
    }

    void Materialization()
    {   
        Physics.IgnoreLayerCollision(layers[0], layers[1],false);
    }

    public void Move(Vector3 pos)//Pushオブジェクトの位置へ移動
    {
        //transform.position = pos;
        //Vector3.Lerp(transform.position, pos, 1);
    }

    public void Right()//→
    {
        movePos = transform.position;
        movePos.x += 0.05f;
        transform.position = movePos;
    }

    public void Left()//←
    {
        movePos = transform.position;
        movePos.x -= 0.05f;
        transform.position = movePos;
    }

    public void Up()//↑
    {
        movePos = transform.position;
        movePos.y += 0.05f;
        transform.position = movePos;
    }

    public void Under()//↓
    {
        movePos = transform.position;
        movePos.y -= 0.05f;
        transform.position = movePos;
    }
}
