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
    CharacterController ch; 
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
        Vector3 moveX = Camera.main.transform.right * Input.GetAxis("Horizontal") * moveSpeed;
             
        if(ch.isGrounded)
        {
            PlayersPos = moveX;
        }
        else
        {
            PlayersPos = moveX + new Vector3(0, PlayersPos.y, 0);
            PlayersPos.y -= 40f * Time.deltaTime;

            Transform myTransform = this.transform;
            Vector3 pos = myTransform.position;

            if(pos.y < -4)
            {
                Destroy(gameObject);
                retry.REtry();
            }

        }
 
        transform.LookAt(transform.position + moveX);
    }

    void Update()
    {
        
        if (ch.isGrounded && Input.GetKey(KeyCode.Space))
        {
            PlayersPos.y = jumpPower;
        }

       if(moveflag)ch.Move(PlayersPos * Time.deltaTime);

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

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == "Oil" || hit.gameObject.tag == "Fire" || hit.gameObject.tag == "Fireball" || hit.gameObject.tag == "Thorn" || hit.gameObject.tag == "Electricity" || hit.gameObject.tag == "ElectricityWater")
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

        if(hit.gameObject.tag == "Ice" && Input.GetKeyDown(KeyCode.Q) && Saltcount > 0)
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