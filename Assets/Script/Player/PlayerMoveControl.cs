using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
public class PlayerMoveControl : MonoBehaviour
{
    public  float moveSpeed;
    public  float jumpPower;
    private Vector3 PlayersPos;
    Vector3 movepos;
    CharacterController ch; 
    public Rigidbody rb;
    public Animator animator;
    public bool moveflag = false;
    public int Saltcount;
    Retry retry;

    void Start()
    {
        moveflag = false;
        ch = GetComponent<CharacterController>();
        retry = GameObject.Find("ControlSystem").GetComponent<Retry>();
        Saltcount = 0;
        animator = GetComponent<Animator>();
        Invoke("Moveflagch",0.1f);
        
    }

    void FixedUpdate()
    {   
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward,new Vector3(1, 0, 1)).normalized;
        movepos = Camera.main.transform.right * Input.GetAxis("Horizontal") * moveSpeed;
        
        if(ch.enabled)
        {
            if(ch.isGrounded)
            {
                PlayersPos = movepos;
            }
            else
            {
                PlayersPos = movepos + new Vector3(0, PlayersPos.y, 0);
                PlayersPos.y -= 40f * Time.deltaTime;

                Transform myTransform = this.transform;
                Vector3 pos = myTransform.position;

            }
        }
        else
        {
        }
        transform.LookAt(transform.position + movepos);
    }

    void Update()
    {
        if(ch.enabled)Debug.Log(1);
        /* if(Input.GetAxis("Horizontal") == 0)
        {
            Debug.Log(Input.GetAxis("Horizontal"));
        } */
        
        if (ch.enabled && ch.isGrounded && Input.GetKey(KeyCode.Space) || Input.GetKey ("joystick button 0") && ch.enabled && ch.isGrounded)
        {
            PlayersPos.y = jumpPower;
        }
        
        if(ch.enabled && moveflag)ch.Move(PlayersPos * Time.deltaTime);
    }

    void Animation()
    {
       /*  if(ch.velocity.magnitude > 3 && ch.isGrounded)
        {
            animator.SetFloat("move",ch.velocity.magnitude);
        }
        else
        {
            animator.SetFloat("move",0);
        } */
    }

    void Moveflagch()
    {
        moveflag = true;
    }

    void OnTriggerEnter(Collider hit)
    {
        if(hit.gameObject.tag == "Oil" || hit.gameObject.tag == "ElectricityWater")
        {
            Destroy(gameObject);
            retry.REtry();
        }

        if(hit.gameObject.tag == "Ground")
        {
            if(hit.gameObject.GetComponent<StatusControl>().statu[0] == true)
            {
                //transform.parent = hit.gameObject.transform;
            }
        }
    }

    void OnTriggerExit(Collider hit)
    {
        if(hit.gameObject.tag == "Ground")
        {
            if(hit.gameObject.GetComponent<StatusControl>().statu[0] == true)
            {
                //transform.parent = null;
            }
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == "Oil" || hit.gameObject.tag == "Fire" || hit.gameObject.tag == "Fireball" || hit.gameObject.tag == "Thorn")
        {
            Destroy(gameObject);
            retry.REtry();
        }
        
        if (hit.gameObject.tag == "Salt")
        {
            Destroy(hit.gameObject);
            Saltcount++;
            Debug.Log("Saltcount:" + Saltcount);
        }

        if(hit.gameObject.tag == "Ice" && Input.GetKeyDown(KeyCode.Q) && Saltcount > 0 || hit.gameObject.tag == "Ice" && Input.GetKeyDown ("joystick button 2") && Saltcount > 0)
        {
            Saltcount--;
            Debug.Log("Saltcount:" + Saltcount);
            hit.gameObject.GetComponent<IceControl>().changeFlag = false;
            hit.gameObject.layer = hit.gameObject.GetComponent<IceControl>().layers[2];
            Vector3 Gp = hit.gameObject.transform.position;
            Gp.y = 0;

            GameObject createobj = Instantiate(hit.gameObject.GetComponent<IceControl>().obj[2],Gp,Quaternion.identity);
            createobj.transform.localScale = hit.gameObject.transform.localScale;

            //Instantiate(hit.gameObject.GetComponent<IceControl>().obj[2],Gp,Quaternion.identity);//プレハブを呼び出す
            //hit.gameObject.GetComponent<Renderer>().material.color = Color.blue;
        }
    }
}