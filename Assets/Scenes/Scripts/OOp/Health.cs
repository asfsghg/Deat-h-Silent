using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int currentHealth = 110;
    [SerializeField] private int maxHealth = 100;
    
    public event Action OnDeath;
    public event Action<int> OnHealthChanged;

    private void OnValidate()
    {
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        if (currentHealth <= 0)
        {
            OnDeath?.Invoke();
        }
        
        OnHealthChanged?.Invoke(currentHealth);
    }
    
    public int GetHealth() => currentHealth;
}
