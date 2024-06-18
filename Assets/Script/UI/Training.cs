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
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        textControl = GameObject.Find("ControlSystem").GetComponent<TextControl>();
        
        if(!Training.boot)
        {
            Debug.Log(12);
            Training.boot = true;
            textbox.SetActive(true);
        }
        
    }

    // Update is called once per frame
    void Update()
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
        else if(!textbox.activeSelf && Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }

    }

    public void TextboxON()
    {
        TextControl.count += 1;
        textbox.SetActive(true);
        
        if(textControl.language)
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
        if(textControl.language)
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
