using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class IceControl : MonoBehaviour
{
    public GameObject[] obj;
    public static bool changeFlag;
    int[] layers;

    void Start()
    {
       layers = new int[2];
       layers[0] = LayerMask.NameToLayer("Ice");
       layers[1] = LayerMask.NameToLayer("Player");
       Physics.IgnoreLayerCollision(layers[0], layers[1],true);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G) && !Input.GetKeyDown(KeyCode.H) && IceControl.changeFlag)
        {
            Transform myTransform = this.transform;
            Vector3 pos = myTransform.position;

            Instantiate(obj[0], new Vector3(pos.x, pos.y, pos.z), Quaternion.identity);
            Destroy(transform.parent.gameObject);
        }

        if(Input.GetKeyDown(KeyCode.H) && !Input.GetKeyDown(KeyCode.G) && IceControl.changeFlag)
        {
            Transform myTransform = this.transform;
            Vector3 pos = myTransform.position;

            Instantiate(obj[1], new Vector3(pos.x, pos.y, pos.z), Quaternion.identity);
            Destroy(transform.parent.gameObject);
        }
    }

    /* void OnTriggerStay(Collider hit)
    {
        if(hit.gameObject.tag == "player")
        {
            Physics.IgnoreLayerCollision(layers[0], layers[1],true);
        }
    } */
}
