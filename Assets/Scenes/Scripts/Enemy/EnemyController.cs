using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private int _Speed = 4;
    [SerializeField] private Transform[] targetPoints;


    private NavMeshAgent agent;
    private int currentIndex = 0;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = _Speed;
        
        if (targetPoints.Length > 0)
            agent.SetDestination(targetPoints[0].position);
    }


    void Update()
    {
        Movement();
    }
    private void Movement()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.1f)
        {
            currentIndex = (currentIndex + 1) % targetPoints.Length;
            agent.SetDestination(targetPoints[currentIndex].position);
        }
    }
}