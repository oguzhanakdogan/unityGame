using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class sariTop : MonoBehaviour
{
    public Transform yellowBall;

    // Start is called before the first frame update
    private bool isCollide = false;
    private Vector3 lastPositionofBall = Vector3.zero;
    public static Vector3 velocity;
    public static Vector3 directionOfball;
    private Vector3 yellowBallPos;
    public Transform point;
//about cue
    public static bool isMove = false; 

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (collisyon.isCollide)
        {
            //isMove = true;
            Move();

            Rotate();
        }

        
    }

    private void OnCollisionEnter(Collision other)
    {
       

        if (other.transform.tag == "wall")
        {
            //collisyon.isCollide = false;
          
            Vector3 contactPoint = other.contacts[0].point;
            Debug.Log("duvara çarptı x ise ="+ contactPoint.x + " y" + contactPoint.y + " z" + contactPoint.z+
                      "top koordintları: x =" + yellowBall.position.x + " y =" + yellowBall.position.y + "z" + yellowBall.position.z);
            Vector3 distance = new Vector3(contactPoint.x - yellowBall.position.x, contactPoint.y - yellowBall.position.y,
                contactPoint.z - yellowBall.position.z);
            if ( (int)Math.Abs(distance.x*10) > 1)
            {
                directionOfball.x = directionOfball.x * -1;
            }
            else if ((int)Math.Abs(distance.y*10) > 1)
            {
                directionOfball.y= directionOfball.z * -1;

            }
            else if ((int)Math.Abs(distance.z*10) > 1)
            {
                directionOfball.z = directionOfball.z * -1;

            }

            isMove = true;
        }
    }

    private void Move()
    {
        
        
        yellowBall.position += directionOfball/20f;
        
    }

    void Rotate()
    {
       
        yellowBall.transform.Rotate(3*velocity.y* (point.position.z - yellowBall.position.z)+
                                    3*velocity.z *(point.position.y - yellowBall.position.y),
            3*velocity.x*(point.position.z - yellowBall.position.z) + 
            3*velocity.z * (point.position.x - yellowBall.position.x),
            3* velocity.x *(point.position.y - yellowBall.position.y) + 
            3*velocity.y *(point.position.x - yellowBall.position.x));
    }

    void Bound()
    {
        
    }
    
}
