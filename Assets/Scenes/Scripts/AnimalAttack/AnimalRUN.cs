using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalRUN : MonoBehaviour
{
    public float detectionRange;
    public Transform player;
    public float attackCooldown;
    public int damage;
    public float moveSpeed;
    public float attackRange = 2f;
    public Canvas deathCanvas;

    private float lastAttackTime;

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= detectionRange)
        {

            Vector3 direction = (transform.position - player.position).normalized;


            transform.position += direction * moveSpeed * Time.deltaTime;


            transform.rotation = Quaternion.LookRotation(direction);


            if (distance <= attackRange && Time.time > lastAttackTime + attackCooldown)
            {
                Atack();
                lastAttackTime = Time.time;
            }
        }
    }

    void Atack()
    {
        hpp hp = player.GetComponent<hpp>();
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
