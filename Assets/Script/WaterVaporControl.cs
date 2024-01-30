using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WaterVaporControl : MonoBehaviour
{
    public GameObject[] obj;
    Transform myTransform;
    Vector3 pos;
    void Start()
    {
        myTransform = this.transform;
        pos = this.transform.position;
        InvokeRepeating("Rise",0,0.01f);
        obj = new GameObject[2];
        obj [0] = AssetDatabase.LoadAssetAtPath<GameObject> ("Assets/StageParts/Water.prefab");
        obj [1] = AssetDatabase.LoadAssetAtPath<GameObject> ("Assets/StageParts/Ice.prefab");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Transform myTransform = this.transform;
            Vector3 pos = myTransform.position;

            Instantiate(obj[0],new Vector3(pos.x, pos.y, 0), Quaternion.identity);
            Destroy(gameObject);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            Transform myTransform = this.transform;
            Vector3 pos = myTransform.position;

            Instantiate(obj[1],new Vector3(pos.x, pos.y, 0), Quaternion.identity);
            Destroy(gameObject);
        }
    }

    void Rise()
    {
        pos = this.transform.position;
        
        pos.y += 0.003f;
        myTransform.position = new Vector3(pos.x,pos.y,0);
        
    }

   void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.tag == "Ground")
        {
            CancelInvoke("Rise");
        }
    }
}
