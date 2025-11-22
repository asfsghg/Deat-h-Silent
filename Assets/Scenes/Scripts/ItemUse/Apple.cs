using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour, IUsable
{

    public int healAmount = 20;

    private HP playerHP;

    void Start()
    {
        // Ищем HP только на игроке
        playerHP = GameObject.FindGameObjectWithTag("Player")?.GetComponent<HP>();

        if (playerHP == null)
            Debug.LogError("HP на Player НЕ найден! Добавь тег Player игроку и компонент HP.");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            Use();
    }

    public void Use()
    {
        if (playerHP == null)
        {
            Debug.Log("HP не найден");
            return;
        }

        // Если здоровье полное — НЕ едим
        if (playerHP.currentHealth >= playerHP.maxHealth)
        {
            Debug.Log("Здоровье полное — яблоко НЕ съедается");
            return;
        }

        // Лечение
        playerHP.Heal(healAmount);

        Debug.Log($"Съел яблоко +{healAmount} HP");

        // Удаляем предмет
        Destroy(gameObject);
    }

}
