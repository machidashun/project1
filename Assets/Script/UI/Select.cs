using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Video;

public class Select : MonoBehaviour
{
    public GameObject[] titlebutton;
    public GameObject[] stagebutton;
    public GameObject[] downstream;
    public GameObject[] middleclass;
    public GameObject[] upstream;
    public GameObject[] uiobj;
    public GameObject[] stageobj;
    public GameObject[] option;
    public GameObject[] videocanvas;
    public VideoPlayer[] video;
    public GameObject[] language;
    public Retry retry;
    public static string stage;
    public bool flag;
    float limit;
    float time;
    public static bool retryflag;
    public SoundControl soundControl;
    
    int i = 0;

    void Start()
    {
        limit = 0;
        time = 0;

        if(Select.stage == null)
        {
            Time.timeScale = 0;
        }

        if(Select.retryflag)
        {
            GameSelect();
            Select.retryflag = false;
        }

        i = 0;
        EventSystem.current.SetSelectedGameObject(titlebutton[0]);
        titlebutton[0].GetComponent<Button>().interactable = true;
    }

    void Update()
    {
        if(uiobj[7].activeSelf)
        {
            float dph = Input.GetAxis ("HorizontalD");
            
            time += Time.unscaledDeltaTime;
            if(dph >= 1  && limit + 0.2f < time)
            {
                soundControl.SetSE(0,4);
                limit = time;

                if(0 < i)
                {
                    i--;
                }
                else
                {
                    i = option.Length-1;
                }
                OptionSet();
            }
            else if(dph < 0 && limit + 0.2f < time)
            {
                soundControl.SetSE(0,4);
                limit = time;
                if( 2 > i)
                {
                    i++;
                }
                else
                {
                    i = 0;
                }
                OptionSet();
            }
        }

        if(uiobj[8].activeSelf)
        {
            float dph = Input.GetAxis ("HorizontalD");
            
            time += Time.unscaledDeltaTime;
            if(dph >= 1  && limit + 0.2f < time)
            {
                limit = time;

                if(0 < i)
                {
                    i--;
                }
                else
                {
                    i = language.Length-1;
                }
                LanguageSet();
            }
            else if(dph < 0 && limit + 0.2f < time)
            {
                limit = time;
                if( 1 > i)
                {
                    i++;
                }
                else
                {
                    i = 0;
                }
                LanguageSet();
            }
        }

        if(Input.GetKeyDown ("joystick button 7") && Select.stage != null)
        {
            OptionMenu();
        }

        if (Input.GetKeyDown ("joystick button 1")) //B
        {
            soundControl.SetSE(0,4);
            if(uiobj[0].activeSelf && uiobj[6].activeSelf)
            {
                Language();
                //GameSelect();
            }

            if(uiobj[9].activeSelf)
            {
                soundControl.ResetTime();
                StageRsect();
                GameSelect();
            }
        }

        if (Input.GetKeyDown ("joystick button 0"))//A
        {
            
            if(uiobj[6].activeSelf)
            {
                if(uiobj[2].activeSelf || uiobj[3].activeSelf || uiobj[4].activeSelf)
                {
                    ButtonRsect();
                    EventSystem.current.SetSelectedGameObject(stagebutton[0]);
                    stagebutton[0].GetComponent<Button>().interactable = true;
                    uiobj[2].SetActive(false);
                    uiobj[3].SetActive(false);
                    uiobj[4].SetActive(false);
                    GameSelect();
                }
            }

            if(uiobj[15].activeSelf && limit + 0.2f < time)
            {
                uiobj[15].SetActive(false);
                flag = false;
                OptionMenu();
            }
        }

        if (Input.GetKeyDown ("joystick button 4")) 
        {
            soundControl.SetSE(0,4);
            if(uiobj[1].activeSelf)//難易度選択
            {
                if(0 < i)
                {
                    i--;
                }
                else
                {
                    i = stagebutton.Length-1;
                }
            }
            
            if(uiobj[2].activeSelf)//下流
            {
                if(0 < i)
                {
                    i--;
                }
                else
                {
                    i = downstream.Length-1;
                }
                Debug.Log(i);
            }

            if(uiobj[3].activeSelf)//中流
            {
                if(0 < i)
                {
                    i--;
                }
                else
                {
                    i = middleclass.Length-1;
                }
                Debug.Log(i);
            }
            
            if(uiobj[4].activeSelf)//上流
            {
                if(0 < i)
                {
                    i--;
                }
                else
                {
                    i = upstream.Length-1;
                }
                Debug.Log(i);
            }

            ButtonSelect();
        }

        if (Input.GetKeyDown ("joystick button 5")) 
        {
            soundControl.SetSE(0,4);
            if(uiobj[1].activeSelf)
            {
                if(stagebutton.Length -1 > i)
                {
                    i++;
                }
                else
                {
                    i = 0;
                }
            }
            
            if(uiobj[2].activeSelf)//下流
            {
                if(downstream.Length -1 > i)
                {
                    i++;
                }
                else
                {
                    i = 0;
                }
            }

            if(uiobj[3].activeSelf)//中流
            {
                if(middleclass.Length -1 > i)
                {
                    i++;
                }
                else
                {
                    i = 0;
                }
            }
            
            if(uiobj[4].activeSelf)//上流
            {
                if(upstream.Length -1 > i)
                {
                    i++;
                }
                else
                {
                    i = 0;
                }
            }
            ButtonSelect();
        }
    }

    void OptionMenu()
    {
        soundControl.SetSE(0,4);
        if(!flag)
        {
            i = 0;
            OptionSet();
            Time.timeScale = 0;
            flag = true;
            uiobj[7].SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            i = 0;
            flag = false;
            uiobj[7].SetActive(false);
            uiobj[15].SetActive(false);
            OptionSet();
        }
    }

    public void Language()
    {
        uiobj[0].SetActive(false);
        uiobj[8].SetActive(true);
        i = 0;
        LanguageSet();
    }

    void LanguageSet()
    {
        EventSystem.current.SetSelectedGameObject(language[i]);
        language[i].GetComponent<Button>().interactable = true;

        if(i == 0)
        {
            language[0].GetComponent<Button>().interactable = true;
            language[1].GetComponent<Button>().interactable = false;
        }
        else if(i == 1)
        {
            language[0].GetComponent<Button>().interactable = false;
            language[1].GetComponent<Button>().interactable = true;
        }
    }

    void OptionSet()
    {
        if(!uiobj[15].activeSelf)
        {
            EventSystem.current.SetSelectedGameObject(option[i]);
            option[i].GetComponent<Button>().interactable = true;

            if(i == 0)
            {
                option[0].GetComponent<Button>().interactable = true;
                option[1].GetComponent<Button>().interactable = false;
                option[2].GetComponent<Button>().interactable = false;
            }
            else if(i == 1)
            {
                option[0].GetComponent<Button>().interactable = false;
                option[1].GetComponent<Button>().interactable = true;
                option[2].GetComponent<Button>().interactable = false;
            }
            else if(i == 2)
            {
                option[0].GetComponent<Button>().interactable = false;
                option[1].GetComponent<Button>().interactable = false;
                option[2].GetComponent<Button>().interactable = true;
            }
        }
    }
    void VideoStop()
    {
        for(int j = 0; video.Length > j; j++)
        {
            video[j].Pause();
            video[j].time = 0;
            videocanvas[j].SetActive(false);
        }
    } 

    void VideoSelect()
    {
        if(uiobj[2].activeSelf)
        {
           if(downstream[0].GetComponent<Button>().interactable == true)
           {
                VideoStop();
                videocanvas[0].SetActive(true);
                video[0].Play();
           }
           else if(downstream[1].GetComponent<Button>().interactable == true)
           {
                VideoStop();
                videocanvas[1].SetActive(true);
                video[1].Play();
           }
           else if(downstream[2].GetComponent<Button>().interactable == true)
           {    
                VideoStop();
                videocanvas[2].SetActive(true);
                video[2].Play();
           }
        }

        if(uiobj[3].activeSelf)
        {
            if(middleclass[0].GetComponent<Button>().interactable == true)
           {
                VideoStop();
                videocanvas[3].SetActive(true);
                video[3].Play();
           }
           else if(middleclass[1].GetComponent<Button>().interactable == true)
           {
                VideoStop();
                videocanvas[4].SetActive(true);
                video[4].Play();
           }
           else if(middleclass[2].GetComponent<Button>().interactable == true)
           {    
                VideoStop();
                videocanvas[5].SetActive(true);
                video[5].Play();
           }
        }

        if(uiobj[4].activeSelf)
        {
            if(upstream[0].GetComponent<Button>().interactable == true)
           {
                VideoStop();
                videocanvas[6].SetActive(true);
                video[6].Play();
           }
           else if(upstream[1].GetComponent<Button>().interactable == true)
           {
                VideoStop();
                videocanvas[7].SetActive(true);
                video[7].Play();
           }
           else if(upstream[2].GetComponent<Button>().interactable == true)
           {    
                VideoStop();
                videocanvas[8].SetActive(true);
                video[8].Play();
           }
        }

    }

    void ButtonSelect()
    {
        
        if(uiobj[1].activeSelf)
        {
            EventSystem.current.SetSelectedGameObject(stagebutton[i]);
            stagebutton[i].GetComponent<Button>().interactable = true;
            if(i > 1)stagebutton[i-1].GetComponent<Button>().interactable = false;
            if(i == stagebutton.Length-1)stagebutton[0].GetComponent<Button>().interactable = false;
            if(i < stagebutton.Length -1)stagebutton[i+1].GetComponent<Button>().interactable = false;
            if(i == 0)stagebutton[stagebutton.Length -1].GetComponent<Button>().interactable = false;
            if(i == 1)stagebutton[0].GetComponent<Button>().interactable = false;
        }

        if(uiobj[2].activeSelf)
        {
            EventSystem.current.SetSelectedGameObject(downstream[i]);
            downstream[i].GetComponent<Button>().interactable = true;
            if(i > 1)downstream[i-1].GetComponent<Button>().interactable = false;
            if(i == downstream.Length-1)downstream[0].GetComponent<Button>().interactable = false;
            if(i < downstream.Length -1)downstream[i+1].GetComponent<Button>().interactable = false;
            if(i == 0)downstream[downstream.Length -1].GetComponent<Button>().interactable = false;
            if(i == 1)downstream[0].GetComponent<Button>().interactable = false;
        }

        if(uiobj[3].activeSelf)
        {
            EventSystem.current.SetSelectedGameObject(middleclass[i]);
            middleclass[i].GetComponent<Button>().interactable = true;
            if(i > 1)middleclass[i-1].GetComponent<Button>().interactable = false;
            if(i == middleclass.Length-1)middleclass[0].GetComponent<Button>().interactable = false;
            if(i < middleclass.Length -1)middleclass[i+1].GetComponent<Button>().interactable = false;
            if(i == 0)middleclass[middleclass.Length -1].GetComponent<Button>().interactable = false;
            if(i == 1)middleclass[0].GetComponent<Button>().interactable = false;
        }

        if(uiobj[4].activeSelf)
        {
            EventSystem.current.SetSelectedGameObject(upstream[i]);
            upstream[i].GetComponent<Button>().interactable = true;
            if(i > 1)upstream[i-1].GetComponent<Button>().interactable = false;
            if(i == upstream.Length-1)upstream[0].GetComponent<Button>().interactable = false;
            if(i < upstream.Length -1)upstream[i+1].GetComponent<Button>().interactable = false;
            if(i == 0)upstream[upstream.Length -1].GetComponent<Button>().interactable = false;
            if(i == 1)upstream[0].GetComponent<Button>().interactable = false;
        }
        VideoSelect();
    }

    public void GameSelect()
    {
        uiobj[0].SetActive(false);
        uiobj[8].SetActive(false);
        uiobj[1].SetActive(true);

        for(int j = 0; Retry.saveNumber.Length > j; j++)
        {
            Retry.saveNumber[j] = false;
        }
        
        if(!IsInvoking("SetTraining"))Invoke("SetTraining",0.1f * Time.timeScale);
    }

    void SetTraining()
    {
        EventSystem.current.SetSelectedGameObject(stagebutton[0]);
        stagebutton[0].GetComponent<Button>().interactable = true;
    }

    public void downstreamSelect()
    {
        i = 0;
        uiobj[1].SetActive(false);
        uiobj[2].SetActive(true);
        ButtonRsect();
        EventSystem.current.SetSelectedGameObject(downstream[0]);
        downstream[0].GetComponent<Button>().interactable = true;
        VideoStop();
        VideoSelect();
    }

    public void middleclassSelect()
    {
        i = 0;
        uiobj[1].SetActive(false);
        uiobj[3].SetActive(true);
        ButtonRsect();
        EventSystem.current.SetSelectedGameObject(middleclass[0]);
        middleclass[0].GetComponent<Button>().interactable = true;
        VideoStop();
        VideoSelect();
    }

    public void upstreamSelect()
    {
        i = 0;
        uiobj[1].SetActive(false);
        uiobj[4].SetActive(true);
        ButtonRsect();
        EventSystem.current.SetSelectedGameObject(upstream[0]);
        upstream[0].GetComponent<Button>().interactable = true;
        VideoStop();
        VideoSelect();
    }

    void ButtonRsect()
    {
        i = 0;
        for(int j = 0; stagebutton.Length > j; j++)
        {
            EventSystem.current.SetSelectedGameObject(stagebutton[j]);
            stagebutton[j].GetComponent<Button>().interactable = false;
        }

        for(int j = 0; downstream.Length > j; j++)
        {
            EventSystem.current.SetSelectedGameObject(downstream[j]);
            downstream[j].GetComponent<Button>().interactable = false;
        }

        for(int j = 0; middleclass.Length > j; j++)
        {
            EventSystem.current.SetSelectedGameObject(middleclass[j]);
            middleclass[j].GetComponent<Button>().interactable = false;
        }

        for(int j = 0; upstream.Length > j; j++)
        {
            EventSystem.current.SetSelectedGameObject(upstream[j]);
            upstream[j].GetComponent<Button>().interactable = false;
        }
    }   

    public void GameStart0_1()
    {
        UiRsect();
        stageobj[9].SetActive(true);
    
        Time.timeScale = 1;
        Select.stage = "0-1";
    }

    public void GameStart1_1()
    {
        UiRsect();
        stageobj[0].SetActive(true);
        Select.stage = "1-1";
        Time.timeScale = 1;
    }

    public void GameStart1_2()
    {
        UiRsect();
        stageobj[1].SetActive(true);
        Select.stage = "1-2";
        Time.timeScale = 1;
    }

    public void GameStart1_3()
    {
        UiRsect();
        stageobj[2].SetActive(true);
        Select.stage = "1-3";
        Time.timeScale = 1;
    }

    public void GameStart2_1()
    {
        UiRsect();
        stageobj[3].SetActive(true);
        Select.stage = "2-1";
        Time.timeScale = 1;
    }

    public void GameStart2_2()
    {
        UiRsect();
        stageobj[4].SetActive(true);
        Select.stage = "2-2";
        Time.timeScale = 1;
    }

    public void GameStart2_3()
    {
        UiRsect();
        stageobj[5].SetActive(true);
        Select.stage = "2-3";
        Time.timeScale = 1;
    }

    public void GameStart3_1()
    {
        UiRsect();
        stageobj[6].SetActive(true);
        Select.stage = "3-1";
        Time.timeScale = 1;
    }

    public void GameStart3_2()
    {
        UiRsect();
        stageobj[7].SetActive(true);
        Select.stage = "3-2";
        Time.timeScale = 1;
    }

    public void GameStart3_3()
    {
        UiRsect();
        stageobj[8].SetActive(true);
        Select.stage = "3-3";
        Time.timeScale = 1;
    }

    void UiRsect()
    {
        for(int j = 0; uiobj.Length > j; j++)
        {
            if(j != 5)
            {
                uiobj[j].SetActive(false);
            }
        }
    }

    public void StageRsect()
    {
        for(int j = 0; stageobj.Length > j; j++)
        {
            stageobj[j].SetActive(false);
        }
        Select.stage = null;
        Select.retryflag = true;
        retry.REtry();
    }

    public void Advancedkg()
    {
        uiobj[10].SetActive(true);
    }

    public void Beginnerkg()
    {
        uiobj[11].SetActive(true);
    }

    public void Intermediatekg()
    {
        uiobj[12].SetActive(true);
    }

    public void Superclasskg()
    {
        uiobj[13].SetActive(true);
    }

    public void Tutorialkg()
    {
        uiobj[14].SetActive(true);
    }

    public void OpenOption()
    {
        soundControl.i = 1;
        soundControl.SetSlider();
        limit = time;
        uiobj[15].SetActive(true);
        EventSystem.current.SetSelectedGameObject(option[i]);
        option[i].GetComponent<Button>().interactable = false;
    }
}