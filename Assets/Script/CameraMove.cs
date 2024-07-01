using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraMove : MonoBehaviour
{
        private GameObject player;
        private Vector3 Camera;
        [SerializeField] private CinemachineVirtualCamera _virtualCamera;
        CameraState state;
        public static float scale;
        public static bool boot;
        //m_Lens.OrthographicSize
	// Use this for initialization
	void Start () 
        {
                if(!CameraMove.boot)
                {
                        CameraMove.boot = true;
                        CameraMove.scale = 7.5f;
                }
                _virtualCamera.m_Lens.OrthographicSize = CameraMove.scale;
                //state = _virtualCamera.State;
	}

	void Update () 
        {
                //if(player)transform.position = player.transform.position + Camera;

                float dph = Input.GetAxis ("HorizontalD");
                float dpv = Input.GetAxis ("VerticalD");

               /*  if(dpv != 0)
                {
                        if(dpv >= 1)
                        {
                                Debug.Log("十字ボタン: 右");
                        }
                        else if(dpv < 0 )
                        {
                                Debug.Log("十字ボタン: 左");
                        }
                } */

                if(Time.timeScale != 0 && dph != 0)
                {
                        if(dph < 0 && CameraMove.scale + 0.1f < 10)
                        {
                                //Debug.Log("十字ボタン: 上");
                                CameraMove.scale += 0.1f;
                                _virtualCamera.m_Lens.OrthographicSize = CameraMove.scale;
                                
                        }
                        else if(dph >= 1 && CameraMove.scale -0.1f > 5)
                        {
                                //Debug.Log("十字ボタン: 下");
                                CameraMove.scale -= 0.1f;
                                _virtualCamera.m_Lens.OrthographicSize = CameraMove.scale;


                        }

                }
	}
}
