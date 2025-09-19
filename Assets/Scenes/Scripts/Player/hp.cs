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

    //public bool isDead = false;

    void Start()
    {
        healtBar = GetComponent<Image>();
        HP = maxHP;
        //if (deathCanvas != null)
        //{
        //    deathCanvas.gameObject.SetActive(false);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        healtBar.fillAmount = HP / maxHP ;
        if (HP <= 0 )
        {
            //if (deathCanvas != null)
            //{
            //    deathCanvas.gameObject.SetActive(true);
            //    Time.timeScale = 0f;
            //}
            //if (alreadyDied) return;
           // alreadyDied = true;

        }
    }
}
