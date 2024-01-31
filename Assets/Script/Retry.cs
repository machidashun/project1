using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Retry : MonoBehaviour
{
    float resettime;

    void Start()
    {
        resettime = 0;
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.R))
        {
            resettime += Time.deltaTime;
            if(resettime >= 1.5f)
            {
                Retrytime();
            }
            //REtry();
        }

        if(Input.GetKeyUp(KeyCode.R))
        {
            resettime = 0;
            Debug.Log(resettime);
        }
    }

    public void REtry()
    {
        Invoke("Retrytime",0.5f);
    }

    public void Retrytime()
    {
        CancelInvoke("Retrytime");
        SceneManager.LoadScene("SampleScene");
    }
}