
using System;
using UnityEngine;

public class Interactible : MonoBehaviour
{
    public float radius = 3f;
    public bool isFocus = false;
    private Transform player;
    public Transform interactionTransform;

    private void Start()
    {
        interactionTransform = transform;
    }

    public void onFocused(Transform playerTransform)
    {
        
        player = playerTransform;
    }

    public void OndeFocuded()
    {
        isFocus = false;
        player = null;

    }

    public virtual void Interact()
    {
        Debug.Log("Interacting with " + transform.name);
    }
    
    private void Update()
    {
        if (isFocus)
        {
            float distance = Vector3.Distance(player.position , transform.position);
         //   Debug.Log("geliyor" + distance);
            if (distance <= radius)
            {
                Interact();
                Debug.Log("picked up");
                isFocus = false;
            }
        }
    }

    private void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position,radius);
    }
    
}
