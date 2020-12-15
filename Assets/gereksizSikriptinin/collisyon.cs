using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class collisyon : MonoBehaviour
{

    private Vector3 carpismaNok;
    
    public Transform yellowBall;
    private Vector3 yellowBallPos;
    
    private Vector3 lastPositionOfCue = Vector3.zero;
    public Transform point;
    private Vector3 velocity;
    private Vector3 directionOfball;
    public static bool isCollide = false;
    collisyon()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        yellowBallPos = yellowBall.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        lastPositionOfCue = point.position;
      //  Debug.Log("velocitisi" + velocity.x  + "   "+ velocity.y + "   " + velocity.z);
      
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "yellowBall")
        {
            velocity = point.position - lastPositionOfCue;    
            Debug.Log("sarı topa çarptı");
            directionOfball = (yellowBallPos - point.position) ;
            carpismaNok = point.position;
            isCollide = true;
            sariTop.velocity = velocity;
            sariTop.directionOfball = directionOfball;

        }
    }
}
