using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healtManager : MonoBehaviour
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
       // healtBar.fillAmount = HP / maxHP;

        if (HP <= 0 && !alreadyDied)
        {
            alreadyDied = true;

            
            if (deathCanvas != null)
            {
                deathCanvas.gameObject.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }

   
    public void TakeDamage(float amount)
    {
        healtBar.fillAmount = HP / maxHP;

        if (alreadyDied) return;
        HP -= amount;
        HP = Mathf.Clamp(HP, 0, maxHP);
    }
}
