using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    public float detectionRange;
    public Transform player;
    public float attackCooldown;
    public int damage;
    public float moveSpeed;
    public float attackRange = 2f;
    public Canvas deathCanvas;

    private float lastAttackTime;

    void Start()
    {
        
    }

    
    void Update()
    {
        if (player == null) return;

       
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= detectionRange)
        {
           
            transform.position = Vector3.MoveTowards(
                transform.position,
                player.position,
                moveSpeed * Time.deltaTime);

           
            transform.LookAt(player);

            
            if (distance <= attackRange && Time.time > lastAttackTime + attackCooldown)
            {
                Atack();
                lastAttackTime = Time.time;
            }
        }
        
    }
    void Atack()
    {
        HEALT hp = player.GetComponent<HEALT>();
        if (hp != null)
        {
            hp.TakeDamage(damage);
            if (deathCanvas != null)
            {
                deathCanvas.gameObject.SetActive(true);
                Time.timeScale = 0f;
            } 

        }
    }

}
