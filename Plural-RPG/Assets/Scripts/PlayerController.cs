using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        anim.SetFloat("speed", agent.velocity.magnitude);
    }
}
