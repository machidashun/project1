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

    float expansion;
    void Start()
    {
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
            expansion += 0.0065f;
            createobj.transform.localScale = new Vector3(scale[0], expansion, scale[2]);
        }
    }
}
