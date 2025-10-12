using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulleT : MonoBehaviour
{
    [SerializeField] private int damage;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out MonoDamagable health))
        {
            health.TakeDamage(damage);
        }
    }
}
