using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Danger : MonoBehaviour
{
    public GameObject[] createObject;
    GameObject createobj;

    [Header("サイズ\n0 : X\n1 : Y\n2 : Z")]
    [SerializeField] private float[] scale;

    [Header("※同時に複数選択しないこと\n拡大方向\n0 : ⇄\n1 : ↑↓")]
    [SerializeField] private bool[] direction;

    [Header("\n0 : 拡大速度\n1 : 拡大率")]
    [SerializeField] private float[] expansion;

    float time = 0f;

    void Start()
    {
        time = 0f;
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

    void FixedUpdate() 
    {
        if(createobj)
        {
            if(direction[0])//⇄
            {
                Right();
            }
            else if(direction[1])//↑↓
            {
                Up();
            }

            time+=Time.fixedDeltaTime;

            if(time>=expansion[0])
            {
                time = 0f;
            }
        }
    }

    void OnTriggerEnter(Collider hit)
    {
        if(hit.gameObject.tag == "Player" && !createobj)
        {
            createobj = Instantiate(createObject[0],new Vector3(gameObject.transform.GetChild(0).transform.position.x, gameObject.transform.GetChild(0).transform.position.y, gameObject.transform.GetChild(0).transform.position.z), Quaternion.identity);
            createobj.transform.localScale = new Vector3(scale[0], scale[1], scale[2]);
        }
    }

    void Right()
    {
        Debug.Log(12);
        scale[0] += expansion[1];
        createobj.transform.localScale = new Vector3(scale[0], scale[1], scale[2]);
    }

    void Up()
    {
        Debug.Log(12);
        scale[1] += expansion[1];
        createobj.transform.localScale = new Vector3(scale[0], scale[1], scale[2]);
    }
}
