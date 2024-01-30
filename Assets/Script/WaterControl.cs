using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WaterControl : MonoBehaviour
{
    public GameObject[] obj;
    void Start()
    {
        obj = new GameObject[2];
        obj [0] = AssetDatabase.LoadAssetAtPath<GameObject> ("Assets/StageParts/Ice.prefab");
        obj [1] = AssetDatabase.LoadAssetAtPath<GameObject> ("Assets/StageParts/WaterVapor.prefab");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Transform myTransform = this.transform;
            Vector3 pos = myTransform.position;

            Instantiate(obj[0], new Vector3(pos.x, pos.y, pos.z), Quaternion.identity);
            Destroy(gameObject);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            Transform myTransform = this.transform;
            Vector3 pos = myTransform.position;

            Instantiate(obj[1], new Vector3(pos.x, pos.y + 0.5f, pos.z), Quaternion.identity);
            Destroy(gameObject);
        }
    }

   void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.tag == "Oil")
        {
            Destroy(gameObject);
        }

        if (hit.gameObject.tag == "Fire")
        {
            Transform myTransform = this.transform;
            Vector3 pos = myTransform.position;

            Instantiate(obj[1], new Vector3(pos.x, pos.y + 0.5f, pos.z), Quaternion.identity);
            
            Destroy(gameObject);
        }
    }
}
