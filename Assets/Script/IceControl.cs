using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class IceControl : MonoBehaviour
{
    public GameObject[] obj;
    public static bool changeFlag;

    void Start()
    {
        //changeFlag = true;
        obj = new GameObject[2];
        obj [0] = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/StageParts/WaterVapor.prefab");
        obj [1] = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/StageParts/Water.prefab");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && IceControl.changeFlag)
        {
            Transform myTransform = this.transform;
            Vector3 pos = myTransform.position;

            Instantiate(obj[0], new Vector3(pos.x, pos.y + 0.5f, pos.z), Quaternion.identity);
            Destroy(gameObject);
        }

        if (Input.GetKeyDown(KeyCode.H) && IceControl.changeFlag)
        {
            Transform myTransform = this.transform;
            Vector3 pos = myTransform.position;

            Instantiate(obj[1], new Vector3(pos.x, pos.y, pos.z), Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
