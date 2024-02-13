using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bottomsystems : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SelectStage()
    {
        SceneManager.LoadScene("SelectStage");
    }

    public void Title()
    {
        SceneManager.LoadScene("Title");
    }
}
