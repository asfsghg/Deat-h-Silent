using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowsManager : MonoBehaviour
{
    [SerializeField] private GameObject[] windows;
     private void Awake()
    {
        foreach (GameObject window in windows) 
            window.SetActive(false);
    }

    private void Start()
    {
       OpenLayout(WindowsConstant.Connection_Panel);
    }
    public void OpenLayout(string name)
    {
        foreach (GameObject window in windows)
            window.SetActive(window.name == name);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
