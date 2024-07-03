using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
public class SoundControl : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;

    [SerializeField] Slider BGMSlider;
    [SerializeField] Slider SESlider;
    [SerializeField] GameObject[] image;
    [SerializeField] AudioSource[] bgm;
    [SerializeField] AudioSource[] se;
    float limit;
    float time;
    public static float stocktime;
    public int i;

    public Select select;
    Color color;
    public static float[] volumes = {5f,5f};//BGM,SE
    private void Start()
    {
        audioMixer.GetFloat("BGM", out float bgmVolume);
        BGMSlider.value = SoundControl.volumes[0];
        audioMixer.GetFloat("SE", out float seVolume);
        SESlider.value = SoundControl.volumes[1];
        SetBGM();
    }

    void Update()
    {
        
        if(select.uiobj[15].activeSelf)
        {
            if(Input.GetKeyDown ("joystick button 5")) 
            {
                SetSE(0,4);
                if(i < 1)
                {
                    i++;
                }
                else
                {
                    i--;
                }
                SetSlider();
            }

            if(Input.GetKeyDown ("joystick button 4")) 
            {
                SetSE(0,4);
                if(i > 0 )
                {
                    i--;
                }
                else
                {
                    i++;
                }
                SetSlider();
            }
        }
    }

    void SetBgmSlider()
    {
        EventSystem.current.SetSelectedGameObject(BGMSlider.gameObject);
    }

    void SetSeSlider()
    {
        Debug.Log(22);
        EventSystem.current.SetSelectedGameObject(SESlider.gameObject);
    }


    public void SetSlider()
    {
        if(i == 1)
        {
            BGMSlider.interactable = true;
            SESlider.interactable = false;
            image[0].GetComponent<Image>().color = new Color(image[0].GetComponent<Image>().color.r,image[0].GetComponent<Image>().color.g ,image[0].GetComponent<Image>().color.b , 1);
            image[1].GetComponent<Image>().color = new Color(image[1].GetComponent<Image>().color.r,image[1].GetComponent<Image>().color.g ,image[1].GetComponent<Image>().color.b , 0.5f);
            //BGMSlider.Select();
            if(!IsInvoking("SetBgmSlider"))Invoke("SetBgmSlider",0.1f * Time.timeScale);
        }
        else
        {
            BGMSlider.interactable = false;
            image[0].GetComponent<Image>().color = new Color(image[0].GetComponent<Image>().color.r,image[0].GetComponent<Image>().color.g ,image[0].GetComponent<Image>().color.b , 0.5f);
            image[1].GetComponent<Image>().color = new Color(image[1].GetComponent<Image>().color.r,image[1].GetComponent<Image>().color.g ,image[1].GetComponent<Image>().color.b , 1);
            Debug.Log(image[1].GetComponent<Image>().color);
            SESlider.interactable = true;
            if(!IsInvoking("SetSeSlider"))Invoke("SetSeSlider",0.1f * Time.timeScale);
        }
    }

    public void SetBGM()
    {        
        if(select.uiobj[0].activeSelf)
        {
            Debug.Log(12);
            if(select.uiobj[6].activeSelf && bgm[0].isPlaying == false)bgm[0].Play();
        }
        else
        {
            bgm[0].Stop();
        }

        if(select.uiobj[1].activeSelf || select.uiobj[2].activeSelf || select.uiobj[3].activeSelf || select.uiobj[4].activeSelf || select.uiobj[8].activeSelf)
        {
            if(select.uiobj[6].activeSelf && bgm[1].isPlaying == false)bgm[1].Play();
        }
        else
        {
            bgm[1].Stop();
        }

        if(select.stageobj[0].activeSelf || select.stageobj[1].activeSelf || select.stageobj[2].activeSelf || select.stageobj[9].activeSelf)
        {
            bgm[2].time = SoundControl.stocktime;
            if(bgm[2].isPlaying == false)bgm[2].Play();
        }
        else
        {
            bgm[2].Stop();
        }

        if(select.stageobj[3].activeSelf || select.stageobj[4].activeSelf || select.stageobj[5].activeSelf)
        {
            bgm[3].time = SoundControl.stocktime;
            if(bgm[3].isPlaying == false)bgm[3].Play();
        }
        else
        {
            bgm[3].Stop();
        }

        if(select.stageobj[6].activeSelf || select.stageobj[7].activeSelf || select.stageobj[8].activeSelf)
        {
            bgm[4].time = SoundControl.stocktime;
            if(bgm[4].isPlaying == false)bgm[4].Play();
        }
        else
        {
            bgm[4].Stop();
        }

        /* if(select.stageobj[10].activeSelf)
        {
            bgm[6].time = SoundControl.stocktime;
            if(bgm[6].isPlaying == false)bgm[6].Play();
        }
        else
        {
            bgm[6].Stop();
        } */

    }

    public void SetSE(int flag, int num)
    {
        if(flag == 1)
        {
           if(se[num].isPlaying == true)se[num].Stop();
        }
        else
        {
            if(se[num].isPlaying == false)se[num].Play();
        }
    }

    public void ResetTime()
    {
        SoundControl.stocktime = 0;
    }

    public void SetTime()
    {
        if(select.stageobj[0].activeSelf || select.stageobj[1].activeSelf || select.stageobj[2].activeSelf || select.stageobj[9].activeSelf)
        {
            SoundControl.stocktime = bgm[2].time;
        }

        if(select.stageobj[3].activeSelf || select.stageobj[4].activeSelf || select.stageobj[5].activeSelf)
        {
            SoundControl.stocktime = bgm[3].time;
        }

        if(select.stageobj[6].activeSelf || select.stageobj[7].activeSelf || select.stageobj[8].activeSelf)
        {
            SoundControl.stocktime = bgm[4].time;
        }

        if(select.stageobj[10].activeSelf)
        {
            SoundControl.stocktime = bgm[6].time;
        }
        
    }

    public void SetVolumeBGM(float volume)
    {
        if(BGMSlider.value == 0)
        {
            SoundControl.volumes[0] = -80f;
            audioMixer.SetFloat("BGM", SoundControl.volumes[0]);
        }
        else
        {
            SoundControl.volumes[0] = BGMSlider.value;
            audioMixer.SetFloat("BGM", SoundControl.volumes[0]);
        }

    }

    public void SetVolumeSE(float volume)
    {
        if(SESlider.value == 0)
        {
            SoundControl.volumes[1] = -80f;
            audioMixer.SetFloat("SE", SoundControl.volumes[1]);
        }
        else
        {
            SoundControl.volumes[1] = SESlider.value;
            audioMixer.SetFloat("SE", SoundControl.volumes[1]);
        }
    }
}
