using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private int _Speed = 4;
    [SerializeField] private Transform[] targetPoints;
    
    [SerializeField] private float radius = 5f;



    private NavMeshAgent agent;
    private int currentIndex = 0;
    
    private Transform player;
    
    private PlayerControllerFirstPersonWithoutPhoton  playerComp;
    void Start()
    {
        
        agent = GetComponent<NavMeshAgent>();
        agent.speed = _Speed;
        
        if (targetPoints.Length > 0)
            agent.SetDestination(targetPoints[0].position);

  
        playerComp = FindObjectOfType<PlayerControllerFirstPersonWithoutPhoton>();
        if (playerComp != null)
        {
            player = playerComp.transform;
        }
    }


    void Update()
    {
        if (player == null) return;
        
        
        Collider[] hits = Physics.OverlapSphere(transform.position, radius);

       
        foreach (Collider hit in hits)
        {
            if (hit.transform == player)
            {
              
                agent.SetDestination(player.position);
            }
            else
            {
                Movement();
            }
        }
           
        
   
    }

    private void Movement()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.1f)
        {
            currentIndex = (currentIndex + 1) % targetPoints.Length;
            agent.SetDestination(targetPoints[currentIndex].position);
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    

    
}