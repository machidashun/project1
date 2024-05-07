using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Retry : MonoBehaviour
{
    float resettime;
    public static bool[] saveNumber = {false,false,false};
    //SavePoint savePoint;

    private void Awake()
    {
        if(saveNumber[2])
        {
            GameObject.FindWithTag("Player").GetComponent<PlayerMoveControl>().enabled = false;
            GameObject.FindWithTag("Player").gameObject.transform.position = GameObject.FindWithTag("SavePoint3").gameObject.transform.position;
            //GameObject.FindWithTag("Player").GetComponent<PlayerMoveControl>().enabled = true;
        }
        else if(saveNumber[1])
        {
            GameObject.FindWithTag("Player").gameObject.transform.position = GameObject.FindWithTag("SavePoint2").gameObject.transform.position;
        }
        else if(saveNumber[0])
        {
            GameObject.FindWithTag("Player").gameObject.transform.position = GameObject.FindWithTag("SavePoint1").gameObject.transform.position;
        }
    }



    void Start()
    {
        resettime = 0;
        GameObject.FindWithTag("Player").GetComponent<PlayerMoveControl>().enabled = true;
        /* for(int i = 0; i < saveNumber.Length;i++)
        {
            if(saveNumber[i])
            {

            }
        } */

        
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
        }

        if(Input.GetKeyUp(KeyCode.R))
        {
            resettime = 0;
            //Debug.Log(resettime);
        }
    }

    public void REtry()
    {
        Invoke("Retrytime",0.5f);
    }

    public void Retrytime()
    {
        CancelInvoke("Retrytime");

        /* if(Retry.saveNumber[2])
        {
           //SceneManager.LoadScene("Goal");
           SceneManager.LoadScene("SampleScene");
        }
        else if(Retry.saveNumber[1])
        {
            SceneManager.LoadScene("SampleScene");
        }
        else if(Retry.saveNumber[0])
        {
            SceneManager.LoadScene("SampleScene");
        }
        else
        {
        } */
            SceneManager.LoadScene("SampleScene");
    }
}