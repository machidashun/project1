using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Retry : MonoBehaviour
{
    float resettime;
    public static bool[] saveNumber = {false,false,false,false,false,false,false,false,false,false};

    private void Awake()
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

    public void REtry()
    {
        Invoke("Retrytime",0.5f);
    }

    public void Retrytime()
    {
        CancelInvoke("Retrytime");
        SceneManager.LoadScene("tset");
    }
}