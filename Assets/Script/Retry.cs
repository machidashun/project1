using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Retry : MonoBehaviour
{

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            REtry();
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