using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{
    public NavMeshAgent _meshAgent;
    private Transform target;
    private void Start()
    {
        _meshAgent = GetComponent<NavMeshAgent>();
        
    }


    private void Update()
    {
        if (target != null)
        {
            _meshAgent.SetDestination(target.position);
            
        }
        else
        {
            _meshAgent.SetDestination(transform.position);
        }
    }

  
    public void FollowTarget(Interactible newTarget)
    {
        target = newTarget.transform;
    }
    public void StopFollowTarget()
    {
        target = null;
        
    }
}
