using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControl : MonoBehaviour
{
    private Animator animator;

    public float speed = 2; // Walking speed
    public float jumpSpeed = 2; // Jump speed
    public float gravity = 1; //gravity

    public float rotas = 5; // Speed of rotation

    public float startKocchi = 2; // Distance to camera for Kocchiflag firing <●><●>

    float second; // Time Measurement

    //int key = 0;
    string state;
    string prevState;

    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;
    
    public int Saltcount;
    // Start is called before the first frame update
    void Start()
    {
        IceControl.changeFlag = true;
        Saltcount = 0;
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && Saltcount > 0)
        {
            Saltcount--;
            Debug.Log("Saltcount:" + Saltcount);
            IceControl.changeFlag = false;
        }

        second += Time.deltaTime;
        if (second >= 15)
        {
            IdleBanimation();
        } else {
            Idleanimation();
        }
        

        /* if (Input.GetKey("down") || Input.GetKey("s"))
        {
            Walkanimation();
            Move();
            float angleDiff = Mathf.DeltaAngle(transform.localEulerAngles.y, 180);
            if (angleDiff == 0)
            {
                controller.Move (this.gameObject.transform.forward * speed * Time.deltaTime);
            } else if (angleDiff < -1f)
            {
                transform.Rotate(0, rotas * -1, 0);
            } else if (angleDiff > 1f)
            {
                transform.Rotate(0, rotas * 1, 0);
            } else {
                transform.rotation = Quaternion.Euler(0.0f, 180, 0.0f);
            }
        } 
        
        if (Input.GetKey("up") || Input.GetKey("w")) 
        {
            Walkanimation();
            Move();
            float angleDiff = Mathf.DeltaAngle(transform.localEulerAngles.y, 0);
            if (angleDiff == 0) 
            {
                controller.Move (this.gameObject.transform.forward * speed * Time.deltaTime);
            } else if (angleDiff < -1f) 
            {
                transform.Rotate( 0,rotas * -1, 0);
            } else if (angleDiff > 1f) 
            {
                transform.Rotate( 0,rotas * 1, 0);
            } else 
            {
                transform.rotation = Quaternion.identity;
            }
        }
        */

        if (Input.GetKey("left") || Input.GetKey("a"))
        {
            Walkanimation();
            Move();
            float angleDiff = Mathf.DeltaAngle(transform.localEulerAngles.y, -90);
            if (angleDiff == 0)
            {
                controller.Move (this.gameObject.transform.forward * speed * Time.deltaTime);
            } else if (angleDiff < -1f) 
            {
                transform.Rotate( 0,rotas * -1, 0);
            } else if (angleDiff > 1f) 
            {
                transform.Rotate( 0,rotas * 1, 0);
            } else 
            {
                transform.rotation = Quaternion.Euler(0.0f, -90, 0.0f);
            }
        }

        if (Input.GetKey("right") || Input.GetKey("d")) 
        {
            Walkanimation();
            Move();
            float angleDiff = Mathf.DeltaAngle(transform.localEulerAngles.y, 90);
            //Debug.Log($"left: {angleDiff}");
            if (angleDiff == 0) 
            {
                controller.Move (this.gameObject.transform.forward * speed * Time.deltaTime);
            } else if (angleDiff < -1f) 
            {
                transform.Rotate( 0,rotas * -1, 0);
            } else if (angleDiff > 1f) 
            {
                transform.Rotate( 0,rotas * 1, 0);
            } else 
            {
                transform.rotation = Quaternion.Euler(0.0f, 90, 0.0f);
            }
        }

        if (controller.isGrounded && Input.GetKeyDown("space"))
        {
            Jumpanimation();
            Move();
            moveDirection.y = jumpSpeed;
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

    void Move()
    {
        Transform mypos = this.transform;
        Vector3 Apos = mypos.position; 

        Transform campos = Camera.main.transform;
        Vector3 Bpos = campos.position;         
    }

    void Jumpanimation()
    {
        if (controller.isGrounded)
        {
            
            animator.SetBool("jumpFlag", true);
            animator.SetBool("walkFlag", false);
            animator.SetBool("idleFlag", false);
        }
    }

    void Walkanimation()
    {
        if (controller.isGrounded)
        {
            animator.SetBool("jumpFlag", false);
            animator.SetBool("walkFlag", true);
            animator.SetBool("idleFlag", false);
        }
    }

    void IdleBanimation()
    {
        if (controller.isGrounded)
        {
            animator.SetBool("jumpFlag", false);
            animator.SetBool("walkFlag", false);
            animator.SetBool("idleFlag", false);
            //animator.SetTrigger("idleBFlag");
            second = 0;
        }
    }

    void Idleanimation()
    {
        if (controller.isGrounded)
        {
            animator.SetBool("jumpFlag", false);
            animator.SetBool("walkFlag", false);
            animator.SetBool("idleFlag", true);
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Oil")
        {
            Destroy(gameObject);
        }

        if (hit.gameObject.tag == "Salt")
        {
            Destroy(hit.gameObject);
            Saltcount++;
            Debug.Log("Saltcount:" + Saltcount);
        }
    }
}