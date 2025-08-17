using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowsManager : MonoBehaviour
{
    [SerializeField] private GameObject[] windows;
    void Awake()
    {
        foreach (GameObject window in windows)
            window.SetActive(false);
        
            
        
    }
    
    private void Start()
    {
        OpenLayout(WindowsConstant.Connection_Panel);
    }

    public void OpenLayout(string Name)
    {
        foreach (GameObject window in windows)
            window.SetActive(window.name == Name);
    }

}
