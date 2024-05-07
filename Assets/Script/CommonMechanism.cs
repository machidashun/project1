using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonMechanism : MonoBehaviour
{
    [Header("0 : →\n1 : ←\n2 : 繰り返す")]
    [SerializeField] private bool[] xmove;

    [Header("0 : 右上限\n1 : 左上限\n2 : 移動速度")]
    [SerializeField] private float[] xrange;

    private Vector3 movePos;
    void Start()
    {
        if(xmove[0] || xmove[1])
        {
            if(!IsInvoking("MoveX"))InvokeRepeating("MoveX",0,0.01f);                       
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
            Debug.Log(movePos.x+ xrange[0]);
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
}
