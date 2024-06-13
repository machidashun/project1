using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Danger : MonoBehaviour
{
    public GameObject[] createObject;
    GameObject createobj;

    [Header("サイズ\n0 : X\n1 : Y\n2 : Z")]
    [SerializeField] private float[] scale;

    [Header("\n0 : 拡大速度")]
    [SerializeField] private float[] count;

    float time = 0f;
    float expansion;

    void Start()
    {
        time = 0f;
        expansion = scale[1];
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        InvokeRepeating("ScaleUp",0,count[0]);
    }

    void OnTriggerEnter(Collider hit)
    {
        if(hit.gameObject.tag == "Player" && !createobj)
        {
            createobj = Instantiate(createObject[0],new Vector3(gameObject.transform.GetChild(0).transform.position.x, gameObject.transform.GetChild(0).transform.position.y, gameObject.transform.GetChild(0).transform.position.z), Quaternion.identity);
            createobj.transform.localScale = new Vector3(scale[0], scale[1], scale[2]);
        }
    }

    void ScaleUp()
    {
        if(createobj)
        {
            time+=Time.deltaTime;
            if(time>=count[0])
            {
                time = 0f;
                Debug.Log(12);
                expansion += 0.015f;
                createobj.transform.localScale = new Vector3(scale[0], expansion, scale[2]);
            }
        }
    }
}
