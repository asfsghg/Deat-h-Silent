using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class MonoDamagable : MonoBehaviour
{
    [SerializeField] private int currentHealth = 110;
    [SerializeField] private int maxHealth = 100;
    public Image healtBar;

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

    public void Heal(int heal)
    {
        currentHealth += heal;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        OnHealthChanged?.Invoke(currentHealth);
        healtBar.fillAmount = currentHealth / maxHealth;
    }
}
