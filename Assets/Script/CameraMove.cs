using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private GameObject player;
    private Vector3 Camera;
 
	// Use this for initialization
	void Start () {
        
        player = GameObject.Find("Muryotaisu");
        Camera = transform.position - player.transform.position;
 
	}

	void Update () {
        if(player)transform.position = player.transform.position + Camera;
	}
}
