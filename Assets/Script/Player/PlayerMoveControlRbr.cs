using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
public class PlayerMoveControlRbr : MonoBehaviour
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
    public bool isGrounded;
    Retry retry;
    void Start()
    {
        isGrounded = true;
        moveflag = false;
        rb = GetComponent<Rigidbody>();
        //retry = GameObject.Find("ControlSystem").GetComponent<Retry>();
        rb.useGravity = false;
        Saltcount = 0;
        animator = GetComponent<Animator>();
        Invoke("Moveflagch",0.1f);
        
    }

    void FixedUpdate()
    {   
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward,new Vector3(1, 0, 1)).normalized;
        movepos = Camera.main.transform.right * Input.GetAxis("Horizontal") * moveSpeed;
        movepos = new Vector3(movepos.x,rb.velocity.y,0);
        rb.AddForce (new Vector3(0,-30,0), ForceMode.Acceleration);
        //Debug.Log(movepos);
        //rb.AddForce(new Vector3(0, -300, 0));
        
        //PlayersPos = movepos;
        rb.velocity = movepos;
        transform.LookAt(transform.position + new Vector3(movepos.x,0,0));
        //if(moveflag)rb.AddForce(movepos,ForceMode.Acceleration);
    }

    void Update()
    {
        
        if (isGrounded && Input.GetKey(KeyCode.Space) || isGrounded && Input.GetKeyDown("joystick button 0"))
        {
            isGrounded = false;
            Debug.Log(11);
            rb.AddForce(transform.up * jumpPower, ForceMode.Impulse);
        }

        //Debug.Log(movepos);
       
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

    void OnCollisionStay(Collision hit)
    {
        if(hit.gameObject.tag == "Ice" && Saltcount > 0)
        {
            if(Input.GetKeyDown(KeyCode.Q) || Input.GetKey("joystick button 2"))
            {
                Saltcount--;
                Debug.Log("Saltcount:" + Saltcount);
                hit.gameObject.GetComponent<IceControl>().changeFlag = false;
                hit.gameObject.layer = hit.gameObject.GetComponent<IceControl>().layers[2];
                Vector3 Gp = hit.gameObject.transform.position;
                Gp.y = Gp.y -1;

                GameObject createobj = Instantiate(hit.gameObject.GetComponent<IceControl>().obj[2],Gp,Quaternion.identity);
                createobj.transform.localScale = hit.gameObject.transform.localScale;
                createobj.transform.parent = hit.gameObject.transform;
            }
        }
    }

    void OnTriggerEnter(Collider hit)
    {
        if(hit.gameObject.tag == "Oil" || hit.gameObject.tag == "ElectricityWater" || hit.gameObject.tag == "Fireball" || hit.gameObject.tag == "Thorn")
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

        if(hit.gameObject.tag == "DummyGround")
        {
           transform.parent = hit.gameObject.transform;
            /* if(hit.gameObject.GetComponent<StatusControl>().statu[0] == true)
            {
                transform.parent = hit.gameObject.transform;
            } */
        }
    }

    void OnTriggerExit(Collider hit)
    {
        if(hit.gameObject.tag == "DummyGround")
        {

           transform.parent = null;
        /* if(hit.gameObject.GetComponent<StatusControl>().statu[0] == true)
            {
                transform.parent = null;
            } */
        }
    }

    void OnCollisionEnter(Collision hit)
    {
        if(hit.gameObject.tag == "Ground" || hit.gameObject.tag == "Ice" || hit.gameObject.tag == "DummyGround")
        {
            isGrounded = true;
        }
    }
}