using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieManager : healtManager
{
    public GameObject[] objectsToDestroy;
    public Canvas deathCanvas;

    private bool alreadyDied = false;

    public void Die()
    {
       if (alreadyDied) return; 
        alreadyDied = true;

       
       foreach (GameObject obj in objectsToDestroy)
        {
            if (obj != null) Destroy(obj);
        }

       
        if (deathCanvas != null)
       {
            deathCanvas.gameObject.SetActive(true);
            Time.timeScale = 0f;

       }

        
    }
}
