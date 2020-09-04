using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Camera))]
public class OrbitCamera : MonoBehaviour
{
    [SerializeField]
    Transform focus = default;

   public Transform secondBall;

    [SerializeField, Range(1f, 20f)]
    float distance = 5f;


    [SerializeField, Min(0f)]
    float focusRadius = 1f;


    Vector3 focusPoint;
    float velocity = 0.05f;

    bool isPressed = false;


    private void Awake()
    {
        focusPoint = focus.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void LateUpdate()
    {
        //Vector3 focusPosition = focus.position;
        UpdateFocusPoint();

        Vector3 lookDirection = transform.forward;
        transform.localPosition = focusPoint - lookDirection * distance;
    }

    void UpdateFocusPoint()
    {
        Vector3 targetPoint = focus.position;

        if (focusRadius > 0f)
        {
            float distance = Vector3.Distance(targetPoint, focusPoint);
            if(distance > focusRadius)
            {
                focusPoint = Vector3.Lerp(targetPoint, focusPoint, focusRadius / distance);
            }
        }
        else
        {
            focusPoint = targetPoint;
        }

    }
    // Update is called once per frame
    void Update()
    {
        Vector3 direction = transform.forward;
        if (Input.GetKeyDown(KeyCode.W))
        {
            isPressed = true;
        }
        if (isPressed)
        {
            focus.position = new Vector3(focus.position.x , focus.position.y, focus.position.z + velocity);

        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            isPressed = false;
        }
        //çarpan toptan - çarpılan top
       // Vector3 v = focus.position - secondBall.position;
        
       // if(Math.Abs(v.x) < 1f && Math.Abs(v.y) < 1f && Math.Abs(v.z) < 1f)
      //  {
          //  Debug.Log("çarpışmaları gerek" + v.x + "  " + v.y + " " + v.z);

         //  secondBall.position  = new Vector3(secondBall.position.x, secondBall.position.y, secondBall.position.z + velocity);
        //}

       


    }

   

}
