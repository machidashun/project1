using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    public bool[] saveNumber = {false,false,false,false,false,false,false,false,false,false};
    SoundControl soundControl;
    void Start()
    {
        soundControl = GameObject.Find("ControlSystem").GetComponent<SoundControl>();
        //retry = GameObject.Find("ControlSystem").GetComponent<Retry>();
    }

    void OnTriggerStay(Collider hit)
    {
        if(hit.gameObject.tag == "Player")
        {
            if(!saveNumber[0])
            {
                soundControl.SetSE(0,3);
                saveNumber[0] = true;
            }
            else if(!saveNumber[1])
            {
                soundControl.SetSE(0,3);
                saveNumber[1] = true;
            }
            else if(!saveNumber[2])
            {
                soundControl.SetSE(0,3);
                saveNumber[2] = true;
            }
            else if(!saveNumber[3])
            {
                soundControl.SetSE(0,3);
                saveNumber[3] = true;
            }
            else if(!saveNumber[4])
            {
                soundControl.SetSE(0,3);
                saveNumber[4] = true;
            }
            else if(!saveNumber[5])
            {
                soundControl.SetSE(0,3);
                saveNumber[5] = true;
            }
            else if(!saveNumber[6])
            {
                soundControl.SetSE(0,3);
                saveNumber[6] = true;
            }
            else if(!saveNumber[7])
            {
                soundControl.SetSE(0,3);
                saveNumber[7] = true;
            }
            else if(!saveNumber[8])
            {
                soundControl.SetSE(0,3);
                saveNumber[8] = true;
            }
            else if(!saveNumber[9])
            {
                soundControl.SetSE(0,3);
                saveNumber[9] = true;
            }



            if(gameObject.tag == "SavePoint10")
            {
                Retry.saveNumber[9] = true; 
            }
            else if(gameObject.tag == "SavePoint9")
            {
                Retry.saveNumber[8] = true;
            }
            else if(gameObject.tag == "SavePoint8")
            {
                Retry.saveNumber[7] = true;
            }
            else if(gameObject.tag == "SavePoint7")
            {
                Retry.saveNumber[6] = true; 
            }
            else if(gameObject.tag == "SavePoint6")
            {
                Retry.saveNumber[5] = true;
            }
            else if(gameObject.tag == "SavePoint5")
            {
                Retry.saveNumber[4] = true;
            }
            else if(gameObject.tag == "SavePoint4")
            {
                Retry.saveNumber[3] = true; 
            }
            else if(gameObject.tag == "SavePoint3")
            {
                Retry.saveNumber[2] = true;
            }
            else if(gameObject.tag == "SavePoint2")
            {
                Retry.saveNumber[1] = true;
            }
            else if(gameObject.tag == "SavePoint1")
            {
                Retry.saveNumber[0] = true;
            }
        }
    }
}
