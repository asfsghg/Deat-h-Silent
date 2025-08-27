using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public class InventoriStory : MonoBehaviour
{
    public GameObject UIPanel;
    public Transform InventoriPanel;
    public List<InventoriSlot> slots = new List<InventoriSlot>();
    public bool IsOpen;
    void Start()
    {
        UIPanel.SetActive(false); 
        for (int i = 0; i < InventoriPanel.childCount; i++)
        {
            if(InventoriPanel.GetChild(i).GetComponent<InventoriSlot>() != null)
            {
                slots.Add(InventoriPanel.GetChild(i).GetComponent<InventoriSlot>());
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            IsOpen = !IsOpen;
            if (IsOpen)
            {
                UIPanel.SetActive(true);
            }
            else
            {
                UIPanel.SetActive(false);
            }
        }
    }
}
