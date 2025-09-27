using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpp : MonoBehaviour
{
    public Image healtBar;
    public float maxHP = 100f;
    public float HP;
    public Canvas deathCanvas;
    private bool alreadyDied = false;

    void Start()
    {
        healtBar = GetComponent<Image>();
        HP = maxHP;
    }

    void Update()
    {
        healtBar.fillAmount = HP / maxHP;

        if (HP <= 0 && !alreadyDied)
        {
            alreadyDied = true;

            // Показать канвас смерти, если указан
            if (deathCanvas != null)
            {
                deathCanvas.gameObject.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }

    // Вызываем этот метод из других скриптов, чтобы нанести урон
    public void TakeDamage(float amount)
    {
        healtBar.fillAmount = HP / maxHP;

        if (alreadyDied) return;
        HP -= amount;
        HP = Mathf.Clamp(HP, 0, maxHP);
    }
}
