using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCue : MonoBehaviour
{

    public Transform cue;

    [SerializeField] private GameObject frontPoint;
    [SerializeField] private GameObject endPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse Y") < 0)
        {
            //Code for action on mouse moving left
            Vector3 subOfPoints = new Vector3( 0.1f *(frontPoint.transform.position.x - endPoint.transform.position.x), 
                0.1f *(frontPoint.transform.position.y - endPoint.transform.position.y),
                0.1f *(frontPoint.transform.position.z - endPoint.transform.position.z));
            cue.position = (cue.position - subOfPoints);
            //cue.position = new Vector3(cue.position.x, cue.position.y , cue.position.z+0.9f);
            
        }
        if (Input.GetAxis("Mouse Y") > 0)
        {
            //Code for action on mouse moving right
            Vector3 subOfPoints = new Vector3( 0.1f *(frontPoint.transform.position.x - endPoint.transform.position.x), 
                0.1f *(frontPoint.transform.position.y - endPoint.transform.position.y),
                0.1f *(frontPoint.transform.position.z - endPoint.transform.position.z));
            cue.position =  (cue.position + subOfPoints);
            //cue.position = new Vector3(cue.position.x, cue.position.y, cue.position.z - 0.009f);

        }

    }
}
