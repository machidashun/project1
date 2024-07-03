using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalPoint : MonoBehaviour
{
    public Select select;
    SoundControl soundControl;
    
    void Start()
    {
        soundControl = GameObject.Find("ControlSystem").GetComponent<SoundControl>();
    }
    void OnTriggerStay(Collider hit)
    {
        if(hit.gameObject.tag == "Player" && !select.uiobj[9].activeSelf)
        {
            soundControl.SetSE(0,1);
            Time.timeScale = 0;
            select.uiobj[9].SetActive(true);
        }
    }
}
