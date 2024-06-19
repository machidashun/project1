using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Select : MonoBehaviour
{
    public GameObject[] titlebutton;
    public GameObject[] stagebutton;
    public GameObject[] downstream;
    public GameObject[] middleclass;
    public GameObject[] upstream;
    public GameObject[] uiobj;
    public GameObject[] stageobj;
    int i = 0;

    void Start()
    {
        i = 0;
        EventSystem.current.SetSelectedGameObject(titlebutton[0]);
        titlebutton[0].GetComponent<Button>().interactable = true;
    }

    void Update()
    {
        if (Input.GetKeyDown ("joystick button 4")) 
        {
            if(0 < i)
            {
                i--;
            }
            else
            {
                i = stagebutton.Length-1;
            }

            ButtonSelect();
        }

        if (Input.GetKeyDown ("joystick button 5")) 
        {
            if(stagebutton.Length -1 > i)
            {
                i++;
            }
            else
            {
                i = 0;
            }

            ButtonSelect();
        }
    }

    void ButtonSelect()
    {
        EventSystem.current.SetSelectedGameObject(stagebutton[i]);
        stagebutton[i].GetComponent<Button>().interactable = true;
        if(i > 1)stagebutton[i-1].GetComponent<Button>().interactable = false;
        if(i == stagebutton.Length-1)stagebutton[0].GetComponent<Button>().interactable = false;
        if(i < stagebutton.Length -1)stagebutton[i+1].GetComponent<Button>().interactable = false;
        if(i == 0)stagebutton[stagebutton.Length -1].GetComponent<Button>().interactable = false;
        if(i == 1)stagebutton[0].GetComponent<Button>().interactable = false;
    }

    public void GameSelect()
    {
        uiobj[0].SetActive(false);
        uiobj[1].SetActive(true);
        EventSystem.current.SetSelectedGameObject(stagebutton[0]);
        stagebutton[0].GetComponent<Button>().interactable = true;
    }

    public void GameStart()
    {
        //obj[0].SetActive(false);
    }
}
