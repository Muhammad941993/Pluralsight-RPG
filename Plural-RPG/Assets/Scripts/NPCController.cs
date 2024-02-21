using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCController : MonoBehaviour
{
    public float patrolTime;
    public float aggroRange;

    public Transform[] wayPoints;
    public  int currentWayPoint;

    float agentSpeed;
    Transform player;
    NavMeshAgent agent;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agentSpeed = agent.speed;
    }

    // Start is called before the first frame update
    void Start()
    {
        if(wayPoints.Length > 0)
        {
            InvokeRepeating("Patrol", 0, patrolTime);
        }
        InvokeRepeating("Tick", 0, 0.5f);
    }

   

    void Patrol()
    {
        //currentWayPoint = (currentWayPoint == wayPoints.Length)? 0 : currentWayPoint++;
        currentWayPoint++;
        if (currentWayPoint == wayPoints.Length) currentWayPoint = 0;
        print(currentWayPoint);
    }

    void Tick()
    {
        agent.destination = wayPoints[currentWayPoint].position;
        agent.speed = agentSpeed / 2;
        if (Vector3.Distance(transform.position, player.position )< aggroRange)
        {
            agent.destination = player.position;
            agent.speed = agentSpeed;

        }
    }
}
