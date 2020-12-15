using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Inventory.Scripts;
using UnityEngine;
using UnityEngine.UIElements;
[RequireComponent(typeof(PlayerMotor))]

public class ThirdPersonScript : MonoBehaviour
{

    public CharacterController controller;
    public Transform cam;
    public CinemachineFreeLook CinemachineFreeLook;
    private float speed = 6f;
    public Interactible focus;
    private Camera _camera;
    // Update is called once per frame
    public PlayerMotor Motor;

    private bool isMoveToTarget = false;
    private void Start()
    {
        CinemachineCore.GetInputAxis = GetAxisCustom;
       // controller.GetComponent<Rigidbody>().useGravity = true;
       _camera = cam.GetComponent<Camera>();
       Motor = GetComponent<PlayerMotor>();
    }

    void Update()
    {
        controller.Move(Vector3.up * (-0.1f));
        CinemachineFreeLook.m_Follow = controller.transform;
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        if (direction.magnitude > 0.1f)
        {
            float targetAngel = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y ;
            transform.rotation = Quaternion.Euler(0f, targetAngel, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngel, 0f) * Vector3.forward;
            controller.Move(moveDir * speed * Time.deltaTime ); 
                
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
              Interactible interactible =   hit.collider.GetComponent<Interactible>();
              if (interactible != null)
              {
                  SetFocus(interactible);
              }
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (ChangeItemMaganer.slot != null)
            {
                
                Debug.Log("Bu itemi yok mu etmek istiyorsun yeğen (thirdPersonScript!)");
            }
            RemoveFocus();
            isMoveToTarget = false;
        }


        if (isMoveToTarget)
        {
            controller.Move(transform.forward * speed * Time.deltaTime );
        }
    }

    void RemoveFocus()
    {
        if (focus != null)
        {
            focus.isFocus = false;
            focus.OndeFocuded();
        }

        focus = null;
        Motor.StopFollowTarget();
    }
    void SetFocus(Interactible newFocus)
    {
       
        focus = newFocus;
        Motor.FollowTarget(newFocus);
        isMoveToTarget = true;
        focus.isFocus = true;
        focus.onFocused(transform);
    }
    
    public float GetAxisCustom(string axisName)
    {
        if(axisName == "Mouse X")
        {
            if (Input.GetKey("mouse 1"))
            {
                return UnityEngine.Input.GetAxis("Mouse X");
            } 
            else
            {
                return 0;
            }
        }
        else if (axisName == "Mouse Y")
        {
            if (Input.GetKey("mouse 1"))
            {
                return UnityEngine.Input.GetAxis("Mouse Y");
            } else
            {
                return 0;
            }
        }
        return UnityEngine.Input.GetAxis(axisName);
    }
}
