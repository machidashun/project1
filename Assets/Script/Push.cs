using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour
{

    [Header("※同時に複数選択しないこと\n0 : →\n1 : ←\n2 : ↑\n3 : ↓")]
    [SerializeField] private bool[] direction;
    [Header("射出速度")]
    public float speed;

    void Start()
    {   

    }

    void OnCollisionEnter(Collision hit)
    {
        if(hit.gameObject.tag == "Water")
        {
            hit.gameObject.GetComponent<WaterControl>().Move(transform.position);

            if(gameObject.GetComponent<CapsuleCollider/* MeshCollider */>().enabled)
            {
                Invoke("MeshON",0.5f);
                gameObject.GetComponent<CapsuleCollider/* MeshCollider */>().enabled = false;
            }

            if(direction[0])
            {
                hit.gameObject.GetComponent<WaterControl>().CancelInvoke("Right");
                hit.gameObject.GetComponent<WaterControl>().CancelInvoke("Left");
                hit.gameObject.GetComponent<WaterControl>().CancelInvoke("Up");
                hit.gameObject.GetComponent<WaterControl>().CancelInvoke("Under");
                hit.gameObject.GetComponent<WaterControl>().InvokeRepeating("Right",0,speed);
            }
            else if(direction[1])
            {
                hit.gameObject.GetComponent<WaterControl>().CancelInvoke("Right");
                hit.gameObject.GetComponent<WaterControl>().CancelInvoke("Left");
                hit.gameObject.GetComponent<WaterControl>().CancelInvoke("Up");
                hit.gameObject.GetComponent<WaterControl>().CancelInvoke("Under");
                hit.gameObject.GetComponent<WaterControl>().InvokeRepeating("Left",0,speed);
            }
            else if(direction[2])
            {
                hit.gameObject.GetComponent<WaterControl>().CancelInvoke("Right");
                hit.gameObject.GetComponent<WaterControl>().CancelInvoke("Left");
                hit.gameObject.GetComponent<WaterControl>().CancelInvoke("Up");
                hit.gameObject.GetComponent<WaterControl>().CancelInvoke("Under");
                hit.gameObject.GetComponent<WaterControl>().InvokeRepeating("Up",0,speed);
            }
            else if(direction[3])
            {
                hit.gameObject.GetComponent<WaterControl>().CancelInvoke("Right");
                hit.gameObject.GetComponent<WaterControl>().CancelInvoke("Left");
                hit.gameObject.GetComponent<WaterControl>().CancelInvoke("Up");
                hit.gameObject.GetComponent<WaterControl>().CancelInvoke("Under");
                hit.gameObject.GetComponent<WaterControl>().InvokeRepeating("Under",0,speed);
            }
        }
    }

    void OnTriggerEnter(Collider hit)
    {
        if(hit.gameObject.tag == "IceDummy")
        {
            hit.gameObject.GetComponent<IceDummyControl>().Move(transform.position);

            if(gameObject.GetComponent<CapsuleCollider/* MeshCollider */>().enabled)
            {
                Invoke("MeshON",0.5f);
                gameObject.GetComponent<CapsuleCollider/* MeshCollider */>().enabled = false;
            }

            if(direction[0])
            {
                hit.gameObject.GetComponent<IceDummyControl>().CancelInvoke("Right");
                hit.gameObject.GetComponent<IceDummyControl>().CancelInvoke("Left");
                hit.gameObject.GetComponent<IceDummyControl>().CancelInvoke("Up");
                hit.gameObject.GetComponent<IceDummyControl>().CancelInvoke("Under");
                hit.gameObject.GetComponent<IceDummyControl>().InvokeRepeating("Right",0,speed);
            }
            else if(direction[1])
            {
                hit.gameObject.GetComponent<IceDummyControl>().CancelInvoke("Right");
                hit.gameObject.GetComponent<IceDummyControl>().CancelInvoke("Left");
                hit.gameObject.GetComponent<IceDummyControl>().CancelInvoke("Up");
                hit.gameObject.GetComponent<IceDummyControl>().CancelInvoke("Under");
                hit.gameObject.GetComponent<IceDummyControl>().InvokeRepeating("Left",0,speed);
            }
            else if(direction[2])
            {
                hit.gameObject.GetComponent<IceDummyControl>().CancelInvoke("Right");
                hit.gameObject.GetComponent<IceDummyControl>().CancelInvoke("Left");
                hit.gameObject.GetComponent<IceDummyControl>().CancelInvoke("Up");
                hit.gameObject.GetComponent<IceDummyControl>().CancelInvoke("Under");
                hit.gameObject.GetComponent<IceDummyControl>().InvokeRepeating("Up",0,speed);
            }
            else if(direction[3])
            {
                hit.gameObject.GetComponent<IceDummyControl>().CancelInvoke("Right");
                hit.gameObject.GetComponent<IceDummyControl>().CancelInvoke("Left");
                hit.gameObject.GetComponent<IceDummyControl>().CancelInvoke("Up");
                hit.gameObject.GetComponent<IceDummyControl>().CancelInvoke("Under");
                hit.gameObject.GetComponent<IceDummyControl>().InvokeRepeating("Under",0,speed);
            }
        }
    }

    void MeshON()
    {
        CancelInvoke("MeshON");
        gameObject.GetComponent<CapsuleCollider/* MeshCollider */>().enabled = true;
    }
}
