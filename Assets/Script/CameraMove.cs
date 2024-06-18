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
        //m_Lens.OrthographicSize
	// Use this for initialization
	void Start () 
        {
                state = _virtualCamera.State;
                
                /* player = GameObject.FindWithTag("Player");

                if(Retry.saveNumber[9])
                {
                        transform.position = new Vector3(GameObject.FindWithTag("SavePoint10").gameObject.transform.position.x,GameObject.FindWithTag("SavePoint10").gameObject.transform.position.y,transform.position.z);
                }
                else if(Retry.saveNumber[8])
                {
                        transform.position = new Vector3(GameObject.FindWithTag("SavePoint9").gameObject.transform.position.x,GameObject.FindWithTag("SavePoint9").gameObject.transform.position.y,transform.position.z);
                }
                else if(Retry.saveNumber[7])
                {
                        transform.position = new Vector3(GameObject.FindWithTag("SavePoint8").gameObject.transform.position.x,GameObject.FindWithTag("SavePoint8").gameObject.transform.position.y,transform.position.z);
                }
                else if(Retry.saveNumber[6])
                {
                        transform.position = new Vector3(GameObject.FindWithTag("SavePoint7").gameObject.transform.position.x,GameObject.FindWithTag("SavePoint7").gameObject.transform.position.y,transform.position.z);
                }
                else if(Retry.saveNumber[5])
                {
                        transform.position = new Vector3(GameObject.FindWithTag("SavePoint6").gameObject.transform.position.x,GameObject.FindWithTag("SavePoint6").gameObject.transform.position.y,transform.position.z);
                }
                else if(Retry.saveNumber[4])
                {
                        transform.position = new Vector3(GameObject.FindWithTag("SavePoint5").gameObject.transform.position.x,GameObject.FindWithTag("SavePoint5").gameObject.transform.position.y,transform.position.z);
                }
                else if(Retry.saveNumber[3])
                {
                        transform.position = new Vector3(GameObject.FindWithTag("SavePoint4").gameObject.transform.position.x,GameObject.FindWithTag("SavePoint4").gameObject.transform.position.y,transform.position.z);
                }
                else if(Retry.saveNumber[2])
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

                Camera = transform.position - player.transform.position; */
        
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

                if(dph != 0)
                {
                        if(dph >= 1 && _virtualCamera.m_Lens.OrthographicSize + 0.1f < 10)
                        {
                                //Debug.Log("十字ボタン: 上");
                                _virtualCamera.m_Lens.OrthographicSize += 0.1f;
                                
                        }
                        else if(dph < 0 && _virtualCamera.m_Lens.OrthographicSize -0.1f > 5)
                        {
                                //Debug.Log("十字ボタン: 下");
                                _virtualCamera.m_Lens.OrthographicSize -= 0.1f;
                                Debug.Log(_virtualCamera.m_Lens.OrthographicSize);
                        }

                }
	}
}
