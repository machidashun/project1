using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create : MonoBehaviour
{
    public GameObject[] createObject;
    [Header("※同時に複数選択しないこと\n0 : 棘\n1 : 油\n2 : 水")]
    [SerializeField] private bool[] flag;
    [Header("※棘、油のみ有効\n0 : →\n1 : ←\n2 : ↑\n3 : ↓")]
    [SerializeField] private bool[] direction;
    [Header("\n0 : 生成間隔\n1 : 移動速度")]
    [SerializeField] private float[] count;
    GameObject createobj;
    private Vector3 movePos;
    private Rigidbody rb;

    public static int num;
    private int number;
    void Start()
    {
        Create.num += 1;
        number = Create.num;
        gameObject.transform.GetChild(0).gameObject.SetActive(false);

        if(flag[0])
        {
            InvokeRepeating("CreateObject",0,count[0]);
        }
        else if(flag[1])
        {
            InvokeRepeating("CreateObject",0,count[0]);
        }
        else if(flag[2])
        {
            InvokeRepeating("CreateObject",0,count[0]);
        }
        //InvokeRepeating
    }

    void CreateObject()
    {
        if(flag[0])
        {
            if(!createobj)
            {
                Vector3 pos = transform.position;

                if(direction[0])//→
                {
                    createobj = Instantiate(createObject[0],new Vector3(pos.x, pos.y, pos.z), Quaternion.Euler(0, 90, 0));
                	
                    rb = createobj.AddComponent<Rigidbody>();
                    createobj.AddComponent<DestroyControl>();
                    rb.useGravity = false;
                    
                    InvokeRepeating("Right",0,count[1]);
                }
                else if(direction[1])//←
                {
                    createobj = Instantiate(createObject[0],new Vector3(pos.x, pos.y, pos.z), Quaternion.Euler(0, -90, 0));
                	
                    rb = createobj.AddComponent<Rigidbody>();
                    createobj.AddComponent<DestroyControl>();
                    rb.useGravity = false;
                    
                    InvokeRepeating("Left",0,count[1]);
                }
                else if(direction[2])//↑
                {
                    createobj = Instantiate(createObject[0],new Vector3(pos.x, pos.y, pos.z), Quaternion.Euler(-90, 0, 90));
                	
                    rb = createobj.AddComponent<Rigidbody>();
                    createobj.AddComponent<DestroyControl>();
                    rb.useGravity = false;
                    
                    InvokeRepeating("Up",0,count[1]);
                }
                else if(direction[3])//↓
                {
                    createobj = Instantiate(createObject[0],new Vector3(pos.x, pos.y, pos.z), Quaternion.Euler(90, 0, 90));
                	
                    rb = createobj.AddComponent<Rigidbody>();
                    createobj.AddComponent<DestroyControl>();
                    rb.useGravity = false;
                    InvokeRepeating("Under",0,count[1]);
                }
                else
                {
                    createobj = Instantiate(createObject[0],new Vector3(pos.x, pos.y, pos.z), Quaternion.Euler(90, 0, 90));
                	
                    rb = createobj.AddComponent<Rigidbody>();
                    createobj.AddComponent<DestroyControl>();
                    rb.useGravity = false;
                }
                               
                //createobj.transform.localScale = transform.localScale;
            }

        }
        else if(flag[1])
        {
            if(!createobj)
            {
                Vector3 pos = transform.position;

                if(direction[0])//→
                {
                    createobj = Instantiate(createObject[1],new Vector3(pos.x, pos.y, pos.z), Quaternion.identity);
                	
                    rb = createobj.AddComponent<Rigidbody>();
                    createobj.AddComponent<DestroyControl>();
                    rb.useGravity = false;
                    
                    InvokeRepeating("Right",0,count[1]);
                }
                else if(direction[1])//←
                {
                    createobj = Instantiate(createObject[1],new Vector3(pos.x, pos.y, pos.z), Quaternion.identity);
                	
                    rb = createobj.GetComponent<Rigidbody>();
                    createobj.AddComponent<DestroyControl>();
                    rb.useGravity = false;
                    
                    InvokeRepeating("Left",0,count[1]);
                }
                else if(direction[2])//↑
                {
                    createobj = Instantiate(createObject[1],new Vector3(pos.x, pos.y, pos.z), Quaternion.identity);
                	
                    rb = createobj.GetComponent<Rigidbody>();
                    createobj.AddComponent<DestroyControl>();
                    rb.useGravity = false;
                    
                    InvokeRepeating("Up",0,count[1]);
                }
                else if(direction[3])//↓
                {
                    createobj = Instantiate(createObject[1],new Vector3(pos.x, pos.y, pos.z), Quaternion.identity);
                	
                    rb = createobj.GetComponent<Rigidbody>();
                    createobj.AddComponent<DestroyControl>();
                    rb.useGravity = false;
                    InvokeRepeating("Under",0,count[1]);
                }
                else
                {
                    createobj = Instantiate(createObject[1],new Vector3(pos.x, pos.y, pos.z), Quaternion.identity);
                	
                    rb = createobj.GetComponent<Rigidbody>();
                    createobj.AddComponent<DestroyControl>();
                    rb.useGravity = false;
                }
            }
        }
        else if(flag[2])
        {
            if(GameObject.Find("Create" + number))
            {
                if(!GameObject.Find("Create" + number).GetComponent<DestroyControl>() && GameObject.Find("Create" + number).tag == "Water")
                {
                    GameObject.Find("Create" + number).AddComponent<DestroyControl>();    
                }
            }
            else if(!createobj)
            {
                Vector3 pos = transform.position;
                if(direction[0])//→
                {
                    createobj = Instantiate(createObject[2],new Vector3(pos.x, pos.y, pos.z), Quaternion.identity);
                	
                    rb = createobj.GetComponent<Rigidbody>();
                    createobj.AddComponent<DestroyControl>();
                    rb.useGravity = false;
                    createobj.name = "Create" + number;
                    
                    InvokeRepeating("Right",0,count[1]);
                }
                else if(direction[1])//←
                {
                    createobj = Instantiate(createObject[2],new Vector3(pos.x, pos.y, pos.z), Quaternion.identity);
                	
                    rb = createobj.GetComponent<Rigidbody>();
                    createobj.AddComponent<DestroyControl>();
                    rb.useGravity = false;
                    createobj.name = "Create" + number;
                    
                    InvokeRepeating("Left",0,count[1]);
                }
                else if(direction[2])//↑
                {
                    createobj = Instantiate(createObject[2],new Vector3(pos.x, pos.y, pos.z), Quaternion.identity);
                	
                    rb = createobj.GetComponent<Rigidbody>();
                    createobj.AddComponent<DestroyControl>();
                    rb.useGravity = false;
                    createobj.name = "Create" + number;
                    
                    InvokeRepeating("Up",0,count[1]);
                }
                else if(direction[3])//↓
                {
                    createobj = Instantiate(createObject[2],new Vector3(pos.x, pos.y, pos.z), Quaternion.identity);
                	
                    rb = createobj.GetComponent<Rigidbody>();
                    createobj.AddComponent<DestroyControl>();
                    rb.useGravity = false;
                    createobj.name = "Create" + number;
                    InvokeRepeating("Under",0,count[1]);
                }
                else
                {
                    createobj = Instantiate(createObject[2],new Vector3(pos.x, pos.y, pos.z), Quaternion.identity);
                	
                    rb = createobj.GetComponent<Rigidbody>();
                    createobj.AddComponent<DestroyControl>();
                    rb.useGravity = false;
                    createobj.name = "Create" + number;
                }
            }
            /* if(GameObject.Find("Create" + number))
            {
                if(!GameObject.Find("Create" + number).GetComponent<DestroyControl>() && GameObject.Find("Create" + number).tag == "Water")
                {
                    GameObject.Find("Create" + number).AddComponent<DestroyControl>();    
                }
            }
            else if(!createobj)
            {
                Vector3 pos = transform.position;
                createobj = Instantiate(createObject[2],new Vector3(pos.x, pos.y, pos.z), Quaternion.identity);
                createobj.transform.localScale = transform.localScale;
                createobj.AddComponent<DestroyControl>();
                createobj.name = "Create" + number;
            } */
        }
    }

    /* void Falling()
    {
        rb.isKinematic = false;
    } */

    public void Right()//→
    {
        if(createobj)
        {
            movePos = createobj.transform.position;
            movePos.x += 0.05f;
            createobj.transform.position = movePos;
        }
        else
        {
            CancelInvoke("Right");
        }
        
    }

    public void Left()//←
    {
        if(createobj)
        {
            movePos = createobj.transform.position;
            movePos.x -= 0.05f;
            createobj.transform.position = movePos;
        }
        else
        {
            CancelInvoke("Left");
        }
    }

    public void Up()//↑
    {
        if(createobj)
        {
            movePos = createobj.transform.position;
            movePos.y += 0.05f;
            createobj.transform.position = movePos;
        }
        else
        {
            CancelInvoke("Up");
        }
    }

    public void Under()//↓
    {
        if(createobj)
        {
            movePos = createobj.transform.position;
            movePos.y -= 0.05f;
            createobj.transform.position = movePos;
        }
        else
        {
            CancelInvoke("Under");
        }
    }
}
