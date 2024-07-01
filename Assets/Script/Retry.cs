using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Retry : MonoBehaviour
{
    float resettime;
    public static bool[] saveNumber = {false,false,false,false,false,false,false,false,false,false};
    public Select select;
    public SoundControl soundControl;
    private void Awake()
    {
        RetryStage();
        RetryPos();
    }



    void Start()
    {
        resettime = 0;
    }

    void Update()
    {
        if(Time.timeScale != 0 && Input.GetKey("joystick button 3"))
        {
            resettime += Time.deltaTime;
            if(resettime >= 1.5f)
            {
                Retrytime();
            }
        }
  
        if(Time.timeScale != 0 && Input.GetKeyUp("joystick button 3"))
        {
            resettime = 0;
        }
    }

    public void RetryStage()
    {
        if(Select.stage == "0-1")
        {
            Time.timeScale = 1;
            select.uiobj[6].SetActive(false);
            select.stageobj[9].SetActive(true);
            select.Tutorialkg();
        }
        else if(Select.stage == "1-1")
        {
            Time.timeScale = 1;
            select.uiobj[6].SetActive(false);
            select.stageobj[0].SetActive(true);
            select.Intermediatekg();
        }
        else if(Select.stage == "1-2")
        {
            Time.timeScale = 1;
            select.uiobj[6].SetActive(false);
            select.stageobj[1].SetActive(true);
            select.Intermediatekg();
        }
        else if(Select.stage == "1-3")
        {
            Time.timeScale = 1;
            select.uiobj[6].SetActive(false);
            select.stageobj[2].SetActive(true);
            select.Intermediatekg();
        }
        else if(Select.stage == "2-1")
        {
            Time.timeScale = 1;
            select.uiobj[6].SetActive(false);
            select.stageobj[3].SetActive(true);
            select.Beginnerkg();
        }
        else if(Select.stage == "2-2")
        {
            Time.timeScale = 1;
            select.uiobj[6].SetActive(false);
            select.stageobj[4].SetActive(true);
            select.Beginnerkg();
        }
        else if(Select.stage == "2-3")
        {
            Time.timeScale = 1;
            select.uiobj[6].SetActive(false);
            select.stageobj[5].SetActive(true);
            select.Beginnerkg();
        }
        else if(Select.stage == "3-1")
        {
            Time.timeScale = 1;
            select.uiobj[6].SetActive(false);
            select.stageobj[6].SetActive(true);
            select.Advancedkg();
        }
        else if(Select.stage == "3-2")
        {
            Time.timeScale = 1;
            select.uiobj[6].SetActive(false);
            select.stageobj[7].SetActive(true);
            select.Advancedkg();
        }
        else if(Select.stage == "3-3")
        {
            Time.timeScale = 1;
            select.uiobj[6].SetActive(false);
            select.stageobj[8].SetActive(true);
            select.Advancedkg();
        }
        Time.timeScale = 1;
    }

    public void RetryPos()
    {
        if(saveNumber[9])
        {
            GameObject.FindWithTag("Player").gameObject.transform.position = GameObject.FindWithTag("SavePoint10").gameObject.transform.position;
        }
        else if(saveNumber[8])
        {
            GameObject.FindWithTag("Player").gameObject.transform.position = GameObject.FindWithTag("SavePoint9").gameObject.transform.position;
        }
        else if(saveNumber[7])
        {
            GameObject.FindWithTag("Player").gameObject.transform.position = GameObject.FindWithTag("SavePoint8").gameObject.transform.position;
        }
        else if(saveNumber[6])
        {
            GameObject.FindWithTag("Player").gameObject.transform.position = GameObject.FindWithTag("SavePoint7").gameObject.transform.position;
        }
        else if(saveNumber[5])
        {
            GameObject.FindWithTag("Player").gameObject.transform.position = GameObject.FindWithTag("SavePoint6").gameObject.transform.position;
        }
        else if(saveNumber[4])
        {
            GameObject.FindWithTag("Player").gameObject.transform.position = GameObject.FindWithTag("SavePoint5").gameObject.transform.position;
        }
        else if(saveNumber[3])
        {
            GameObject.FindWithTag("Player").gameObject.transform.position = GameObject.FindWithTag("SavePoint4").gameObject.transform.position;
        }
        else if(saveNumber[2])
        {
            GameObject.FindWithTag("Player").gameObject.transform.position = GameObject.FindWithTag("SavePoint3").gameObject.transform.position;
        }
        else if(saveNumber[1])
        {
            GameObject.FindWithTag("Player").gameObject.transform.position = GameObject.FindWithTag("SavePoint2").gameObject.transform.position;
        }else if(saveNumber[0])
        {
            GameObject.FindWithTag("Player").gameObject.transform.position = GameObject.FindWithTag("SavePoint1").gameObject.transform.position;
        }
    }

    public void REtry()
    {
        Invoke("Retrytime",0/* 0.5f */);
    }

    public void Retrytime()
    {
        CancelInvoke("Retrytime");
        soundControl.SetTime();
        SceneManager.LoadScene("tset");
    }
}