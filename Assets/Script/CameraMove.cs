using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private GameObject player;
    private Vector3 Camera;
 
	// Use this for initialization
	void Start () 
        {
        
        player = GameObject.Find("Muryotaisu");
        
                if(Retry.saveNumber[2])
                {
                        transform.position = new Vector3(GameObject.FindWithTag("SavePoint3").gameObject.transform.position.x,GameObject.FindWithTag("SavePoint3").gameObject.transform.position.y,transform.position.z);
                }
                else if(Retry.saveNumber[1])
                {
                        transform.position = new Vector3(GameObject.FindWithTag("SavePoint2").gameObject.transform.position.x,GameObject.FindWithTag("SavePoint2").gameObject.transform.position.y,transform.position.z);
                }
                else if(Retry.saveNumber[0])
                {
                        transform.position = new Vector3(GameObject.FindWithTag("SavePoint1").gameObject.transform.position.x,GameObject.FindWithTag("SavePoint1").gameObject.transform.position.y,transform.position.z);
                }

                Camera = transform.position - player.transform.position;
        
	}

	void Update () {
        if(player)transform.position = player.transform.position + Camera;
	}
}
