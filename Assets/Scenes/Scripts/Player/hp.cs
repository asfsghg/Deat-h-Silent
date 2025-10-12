using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healtManager : MonoBehaviour
{
    public Image healtBar;
    public float maxHealt = 100f;
    public float Healt;
    public Canvas deathCanvas;
    private bool alreadyDied = false;

    void Start()
    {
        healtBar = GetComponent<Image>();
        Healt = maxHealt;
    }

    void Update()
    {
       // healtBar.fillAmount = Healt / maxHealt;

        if (Healt <= 0 && !alreadyDied)
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
        healtBar.fillAmount = Healt / maxHealt;

        if (alreadyDied) return;
        Healt -= amount;
        Healt = Mathf.Clamp(Healt, 0, maxHealt);
    }
}
