using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyControl : MonoBehaviour
{
    public float rotateSpeed;

    public Material sky;

    float rotationRepeatValue;

    void Update()
    {

        rotationRepeatValue = Mathf.Repeat(sky.GetFloat("_Rotation") + rotateSpeed , 360f);

        sky.SetFloat("_Rotation",rotationRepeatValue);
    }

}
