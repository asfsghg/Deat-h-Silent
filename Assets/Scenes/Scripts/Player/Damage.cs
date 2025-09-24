using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private float damage = 40f;     
    [SerializeField] private string playerTag = "playerr"; 

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.collider.CompareTag(playerTag))
        {
            hpp playerHP = collision.collider.GetComponent<hpp>();
            if (playerHP != null)
            {
                playerHP.HP -= damage;
            }
        }
    }

    /
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            hpp playerHP = other.GetComponent<hpp>();
            if (playerHP != null)
            {
                playerHP.HP -= damage;
            }
        }
    }
}
