using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoriStory : MonoBehaviour
{
    public Transform InventoriPanel;
    public List<InventoriSlot> slots = new List<InventoriSlot>();
    void Start()
    {
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
        
    }
}
