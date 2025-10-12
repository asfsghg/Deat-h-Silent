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
            healtManager playerHP = collision.collider.GetComponent<healtManager>();
            if (playerHP != null)
            {
                playerHP.Healt -= damage;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            healtManager playerHP = other.GetComponent<healtManager>();
            if (playerHP != null)
            {
                playerHP.Healt -= damage;
            }
        }
    }
}
