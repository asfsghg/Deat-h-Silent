using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI; 

public class Start : MonoBehaviour
{
    [SerializeField] private Slider progressBar;
    
    public void StartKraft()
    {
        for (int i = 0; i < 100; i++)
        {
            progressBar.value = i;
        }
    }
}
