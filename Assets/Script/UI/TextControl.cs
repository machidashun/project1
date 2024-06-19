using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextControl : MonoBehaviour
{
    public Text textbox;
    public bool language;
    public static int count;
    public static int trainingcount;

    public GameObject trainingstage;
    Training training;
    public string[] japanesetext = 
    {"<color=#ff0000>CHEMIZUTRY(ケミズトリー)</color>にようこそ▼","このゲームは横スクロールでゴールを目指す\n<color=#ff0000>3Dアクションパズルゲーム</color>だよ▼"
    ,"<color=#ff0000><size=35>赤い帽子のおじさんのゲームっぽいもの</size></color><size=35>だと思ってくれていいよ。▼</size>","まずは操作方法から説明するね▼",
    "<color=#ff0000>左スティック</color>で移動\n<color=#ff0000>Aボタン</color>でジャンプできるよ▼","早速やってみて▼","この黄色のモヤモヤは<color=#ff0000>チェックポイント</color>だよ▼",
    "このゲームではダメージを受けても\nチェックポイントから<color=#ff0000>リスタート</color>できるよ▼","ちなみに<color=#ff0000>Yボタンを長押し</color>してもリスタート\nできるよ▼",
    "チェックポイントは<color=#ff0000>ステージの区切り</color>に\n設置してあるよ▼","区切りごとのチェックポイントに触れないと\n<color=#ff0000>前のチェックポイント</color>からリスタートか▼",
    "<color=#ff0000>スタート地点からリスタート</color>になるから\nチェックポイントは必ず触れておこう▼","ところでいま背負ってる機械\n実は<color=#ff0000>めちゃくちゃ精密機械</color>なんだよね▼",
    "めちゃくちゃ精密すぎてちょっとした\n<color=#ff0000>衝撃や火気・電気で爆発</color>しちゃうんだ▼","だからとげ・火・油・電気には\n触れないほうが身のためだよ▼",
    "じゃあ背負ってる機械はなんなのかって\n話なんだけど・・・▼","これは<color=#ff0000>変化システム</color>を司る機械なんだ▼","え？変化システムが何か？って？▼",
    "変化システムは水や氷、水蒸気を\n<color=#ff0000>自在に変化</color>することができるシステムだよ▼","変化システムを使うには<color=#ff0000>LBとRB</color>だよ▼",
    "変化の仕方は<color=#ff0000>右下の図</color>を参考にしてね▼","ついでに水、氷、水蒸気の\n<color=#ff0000>簡単な性質</color>について説明するね▼","水は空中にあると<color=#ff0000>落下</color>し\n水蒸気は<color=#ff0000>上昇</color>、氷は<color=#ff0000>固定</color>されるよ▼",
    "水や水蒸気は<color=#ff0000>上に乗れない</color>けど\n氷は<color=#ff0000>上に乗れる</color>よ▼","とりあえず今は\nこれだけ覚えておいてね▼",
    "油と換気扇の説明をするね▼","油に水と氷が触れると<color=#ff0000>爆散</color>し\n換気扇に水蒸気が触れると<color=#ff0000>消滅</color>するよ▼",
    "どちらも<color=#ff0000>オブジェクトごと消滅</color>するから\n位置管理に注意してね▼","火は<color=#ff0000>水で消火</color>してね▼","<color=#ff0000>消火に使用した水は水蒸気</color>になるよ▼",
    "電気は主に<color=#ff0000>ドアなどを開くため</color>に使うよ▼","電気に<color=#ff0000>水を通す</color>とドアが開くよ▼","<color=#ff0000>塩</color>があるね▼",
    "塩は<color=#ff0000>氷に使うアイテム</color>だよ▼","使用したい氷の上で<color=#ff0000>Xボタンを押す</color>ことで\nその<color=#ff0000>氷は水や水蒸気に変化しなくなる</color>よ▼",
    "所持した塩はここで確認できるよ▼","あと、塩は次のチェックポイントを通過すると\n<color=#ff0000>消えてしまう</color>ので使い切ろうね▼","大砲は水を入れると<color=#ff0000>3秒後に発射</color>されるよ▼",
    "発射された水は<color=#ff0000>壁に当たるまで</color>飛び続けるよ▼","発射中に氷や水蒸気に<color=#ff0000>変化すると停止</color>するよ▼","だけどほとんどのステージでは\n<color=#ff0000>詰むことが多い</color>からしないほうがいいよ▼",
    "右のモヤモヤはゴール\nこれに触れると<color=#ff0000>ステージクリア</color>だよ▼","・・・これで大体の説明はできたかな▼","これだけ理解出来たら十分だよ\n<color=#ff0000>CHEMIZUTRY(ケミズトリー)を楽しんでね</color>▼"};
    
    public string[] Englishtext = 
    {"Welcome to <color=#ff0000>CHEMIZUTRY</color>▼","This game is a side-scrolling\n<color=#ff0000>3D action puzzle game</color>▼","<size=35>You can think of it as something like</size> <color=#ff0000><size=35>the Red Hat Plumber game</size></color><size=35>▼</size>",
    "Let me start by explaining\nhow to operate it▼","<color=#ff0000>Left stick </color>to move\n<color=#ff0000>Press A</color> to jump▼","Try it▼","This yellow blur is a <color=#ff0000>checkpoint</color>▼",
    "In this game, even if you take damage...\nyou can <color=#ff0000>restart</color> from a checkpoint▼","By the way, you can also press and <color=#ff0000>hold\nthe Y button </color>to restart.",
    "Checkpoints are located at the\n<color=#ff0000>end of each stage</color>▼","After breaking through each stage\n<color=#ff0000>be sure to touch the checkpoint</color>▼","Otherwise, you will have to restart from\nthe <color=#ff0000>previous checkpoint or starting poin</color>▼",
    "By the way, the machine I'm carrying on\nmy backright now is actually a \n<color=#ff0000>very precise machine</color>▼","It's a little bit too precise.\nIt explodes on\n<color=#ff0000>impact, fire, or electricity</color>▼",
    "That's why it's better for you\nif you don't touch\nthorns, fire, oil, or electricity▼","Huh? So you want to ask me what\nthe machine on my back is?▼","This is a machine that controls the \n<color=#ff0000>“change system”</color>▼",
    "What? You look like you don't know \nwhat a change system is▼","“change system” is a system that \n<color=#ff0000>“can change”</color>\nwater, ice, and steam at will▼","To use the change system, \nit's <color=#ff0000>LB and RB</color> ▼",
    "Refer to the diagram at the \n<color=#ff0000>bottom right</color>\nto see how the change is made▼","And while I'm at it, let me explain\nsome <color=#ff0000>simple properties</color> of\nwater, ice, and vapor▼",
    "Water will <color=#ff0000>fall</color> when it's in the air,\nvapor will <color=#ff0000>rise</color>, ice will be<color=#ff0000> fixed</color> ▼","Water and vapor ,<color=#ff0000>can't ride on top</color>\nbut ice <color=#ff0000>can</color>▼",
    "In the meantime, please keep\nthis in mind at this stage▼","I'll explain the oil and\nthe ventilation fan.▼","If water and ice touch \nthe oil, it'll <color=#ff0000>explode</color>, and if\nwater vapor touches the ventilation fan,\nit'll <color=#ff0000>disappear</color>▼",
    "In both cases, the <color=#ff0000>entire object disappears</color>,\nso be careful to manage its location▼","<color=#ff0000>Fire</color> must be extinguished with water▼","By the way, the water used to extinguish\nthe fire will turn into <color=#ff0000>steam</color>▼",
    "Electricity is mainly used to\n<color=#ff0000>open doors</color> and such.▼","If you run <color=#ff0000>water through</color> the \nelectricity, the door will open.▼","There's <color=#ff0000>salt</color>▼","Salt is an<color=#ff0000> item used for ice</color>▼",
    "Press the<color=#ff0000> X button</color> on the ice you want to use,\nand that <color=#ff0000>ice will no longer \nturn into water or vapo</color>▼","You can check the salt in\nyour possession here▼",
    "Also, the salt disappears after the next\ncheckpoint, <color=#ff0000>so use it up</color>▼","The cannon will fire <color=#ff0000>three seconds</color>\nafter you fill it with water▼",
    "The water that's launched will keep\nflying until it<color=#ff0000> hits the wall</color>▼","It'll <color=#ff0000>stop if it turns to\nice or vapor </color>while it's firing▼",
    "But you shouldn't, because you'll get stuck\non <color=#ff0000> most stages</color>▼","The blur on the right is the goal\nWhen you touch it, the <color=#ff0000>stage is cleared</color>▼","...I think that pretty much explains it▼",
    "If you know all this\n<color=#ff0000>I hope you enjoy “CHEMIZUTRY”</color>▼"
    };

    void Start()
    {
        if(trainingstage)
        {
            training = GameObject.Find("ControlSystem").GetComponent<Training>();

            if(trainingstage.activeSelf)
            {
                if(language)
                {
                    textbox.text = japanesetext[TextControl.count];
                }
                else
                {
                    textbox.text = Englishtext[TextControl.count];
                }
            }
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (trainingstage.activeSelf && Time.timeScale == 0 && Input.GetKeyDown("joystick button 1")) {
            
            if(43 == TextControl.count && training.textbox.activeSelf)training.TextboxOff();
            if(language)
            {
                if(japanesetext.Length -1 > TextControl.count && training.textbox.activeSelf)
                {
                    TextControl.count += 1;
                    TextControl.trainingcount += 1;
                }

                if(TextControl.trainingcount == 6)
                {
                    training.TextboxOff();
                }
                else if(TextControl.trainingcount == 12)
                {
                    training.TextboxOff();
                }
                else if(TextControl.trainingcount == 15)
                {
                    training.TextboxOff();
                }
                else if(TextControl.trainingcount == 25)
                {
                    training.TextboxOff();
                }
                else if(TextControl.trainingcount == 28)
                {
                    training.TextboxOff();
                }
                else if(TextControl.trainingcount == 30)
                {
                    training.TextboxOff();
                }
                else if(TextControl.trainingcount == 32)
                {
                    training.TextboxOff();
                }
                else if(TextControl.trainingcount == 37)
                {
                    training.TextboxOff();
                }
                else if(TextControl.trainingcount == 41)
                {
                    training.TextboxOff();
                }
                else if(TextControl.trainingcount == 44)
                {
                    training.TextboxOff();
                }
                if(training.textbox.activeSelf)textbox.text = japanesetext[TextControl.count];
            }
            else
            {
                if(Englishtext.Length -1 > TextControl.count && training.textbox.activeSelf)
                {
                    TextControl.count += 1;
                    TextControl.trainingcount += 1;
                }

                if(TextControl.trainingcount == 6)
                {
                    training.TextboxOff();
                }
                else if(TextControl.trainingcount == 12)
                {
                    training.TextboxOff();
                }
                else if(TextControl.trainingcount == 15)
                {
                    training.TextboxOff();
                }
                else if(TextControl.trainingcount == 25)
                {
                    training.TextboxOff();
                }
                else if(TextControl.trainingcount == 28)
                {
                    training.TextboxOff();
                }
                else if(TextControl.trainingcount == 30)
                {
                    training.TextboxOff();
                }
                else if(TextControl.trainingcount == 32)
                {
                    training.TextboxOff();
                }
                else if(TextControl.trainingcount == 37)
                {
                    training.TextboxOff();
                }
                else if(TextControl.trainingcount == 41)
                {
                    training.TextboxOff();
                }
                else if(TextControl.trainingcount == 44)
                {
                    training.TextboxOff();
                }

                if(training.textbox.activeSelf)textbox.text = Englishtext[TextControl.count];
            }

        }
    }

    public void Textoff()
    {
        training.TextboxOff();
    }

}
