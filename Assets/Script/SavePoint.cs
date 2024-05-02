using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    public bool[] saveNumber = {false,false,false};

    void Start()
    {
        //retry = GameObject.Find("ControlSystem").GetComponent<Retry>();
    }

    void OnTriggerStay(Collider hit)
    {
        if(hit.gameObject.tag == "Player")
        {
            for(int i = 0; i < saveNumber.Length; i++)
            {
                if(saveNumber[i])
                {
                    Retry.saveNumber[i] = true;
                }
            }
        }
    }
}
