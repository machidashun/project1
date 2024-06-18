using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonMechanism : MonoBehaviour
{
    [Header("0 : →\n1 : ←\n2 : 繰り返す")]
    public bool[] xmove;

    [Header("0 : 右上限\n1 : 左上限\n2 : 移動速度")]
    [SerializeField] private float[] xrange;

    [Header("0 : ↑\n1 : ↓\n2 : 繰り返す")]
    public bool[] ymove;

    [Header("0 : ↑上限\n1 : ↓上限\n2 : 移動速度")]
    [SerializeField] private float[] yrange;

    private Vector3 movePos;

    [Header("※項番1,2は一部オブジェクトのみ有効\n未選択の場合は無条件に起動\nギミック起動条件\n0 : playerが接近\n1 : playerと接触\n2 : playerが離れた")]
    public bool[] mode;

    void Start()
    {
        if(!mode[0] && !mode[1] && !mode[2])
        {
            if(xmove[0] || xmove[1])
            {
                if(!IsInvoking("MoveX"))InvokeRepeating("MoveX",0,0.01f);                       
            }

            if(ymove[0] || ymove[1])
            {
                if(!IsInvoking("MoveY"))InvokeRepeating("MoveY",0,0.01f);                       
            }
        }


        movePos = transform.position;
    }

    void MoveX()
    {
        if(xmove[0])
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(movePos.x + xrange[0],movePos.y,transform.position.z), xrange[2]);
            
            if(xmove[2] && movePos.x + xrange[0] <= transform.position.x + 1f)
            {
                xmove[0] = false;
                xmove[1] = true;
            }
        }
        else if(xmove[1])
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(movePos.x - xrange[1],movePos.y,transform.position.z), xrange[2]);
            
            if(xmove[2] && movePos.x - xrange[1]  >= transform.position.x - 1f)
            {
                xmove[0] = true;
                xmove[1] = false;
            }
        }
        
    }

    void MoveY()
    {
        if(ymove[0])
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(movePos.x,movePos.y + yrange[0],transform.position.z), yrange[2]);
            
            if(ymove[2] && movePos.y + yrange[0] <= transform.position.y + 1f)
            {
                ymove[0] = false;
                ymove[1] = true;
            }
        }
        else if(ymove[1])
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(movePos.x,movePos.y - yrange[1],transform.position.z), yrange[2]);
            
            if(ymove[2] && movePos.y - yrange[1]  >= transform.position.y - 1f)
            {
                ymove[0] = true;
                ymove[1] = false;
            }
        }
        
    }

    void OnTriggerExit(Collider hit)
    {
        if(hit.gameObject.tag == "Player" && mode[2])
        {
            if(xmove[0] || xmove[1])
            {
                if(!IsInvoking("MoveX"))InvokeRepeating("MoveX",0,0.01f);                       
            }

            if(ymove[0] || ymove[1])
            {
                if(IsInvoking("MoveY"))InvokeRepeating("MoveY",0,0.01f);                       
            }
        }
    }

    void OnTriggerEnter(Collider hit)
    {
        if(hit.gameObject.tag == "Player" && mode[1])
        {
           if(xmove[0] || xmove[1])
            {
                if(!IsInvoking("MoveX"))InvokeRepeating("MoveX",0,0.01f);                       
            }

            if(ymove[0] || ymove[1])
            {
                if(IsInvoking("MoveY"))InvokeRepeating("MoveY",0,0.01f);                       
            }
        }
    }
}
