using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Training : MonoBehaviour
{
    public GameObject textbox;
    private GameObject player;
    public static bool[] flag = {false,false,false,false,false,false,false,false,false,false};
    TextControl textControl;
    public static bool boot;
    public Select select;
    public void Start()
    {
        player = GameObject.FindWithTag("Player");
        textControl = GameObject.Find("ControlSystem").GetComponent<TextControl>();
        
        if(!Training.boot && textControl.trainingstage.activeSelf)
        {
            if(TextControl.language)
            {
                textControl.textbox.text = textControl.japanesetext[0];
            }
            else
            {
                textControl.textbox.text = textControl.Englishtext[0];
            }
            
            Training.boot = true;
            textbox.SetActive(true);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(textControl.trainingstage.activeSelf)
        {
            if(player && player.transform.position.x >= 4 && !flag[0])
            {
                flag[0] = true;
                TextboxON();
            }
            else if(player && player.transform.position.x >= 20.5 && !flag[1])
            {
                flag[1] = true;
                TextboxON();
            }
            else if(player && player.transform.position.x >= 60 && !flag[2])
            {
                flag[2] = true;
                TextboxON();
            }
            else if(player && player.transform.position.x >= 122 && !flag[3])
            {
                flag[3] = true;
                TextboxON();
            }
            else if(player && player.transform.position.x >= 151 && !flag[4])
            {
                flag[4] = true;
                TextboxON();
            }
            else if(player && player.transform.position.x >= 177 && !flag[5])
            {
                flag[5] = true;
                TextboxON();
            }
            else if(player && player.transform.position.x >= 200 && !flag[6])
            {
                flag[6] = true;
                TextboxON();
            }
            else if(player && player.transform.position.x >= 237 && !flag[7])
            {
                flag[7] = true;
                TextboxON();
            }
            else if(player && player.transform.position.x >= 264 && !flag[8])
            {
                flag[8] = true;
                TextboxON();
            }

            if(textbox.activeSelf && Time.timeScale == 1)
            {
                Time.timeScale = 0;
            }
            else if(!textbox.activeSelf && Time.timeScale == 0 && !select.flag)
            {
                //Debug.Log(12);
                Time.timeScale = 1;
            }

        }
        
    }

    public void FlagReset()
    {
        for(int j = 0; flag.Length > j; j++)
        {
            flag[j] = false;
        }
        TextControl.count = 0;
        TextControl.trainingcount = 0;
        Training.boot = false;
    }


    public void TextboxON()
    {
        TextControl.count += 1;
        textbox.SetActive(true);
        
        if(TextControl.language)
        {
            textControl.textbox.text = textControl.japanesetext[TextControl.count];
        }
        else
        {
            textControl.textbox.text = textControl.Englishtext[TextControl.count];
        }

        
    }

    public void TextboxOff()
    {
        TextControl.count -= 1;
        if(TextControl.language)
        {
            textControl.textbox.text = textControl.japanesetext[TextControl.count];
        }
        else
        {
            textControl.textbox.text = textControl.Englishtext[TextControl.count];
        }
        textbox.SetActive(false);
    }

}
