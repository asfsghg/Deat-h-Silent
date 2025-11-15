using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class UiInventoryControlleR : MonoBehaviour
{
    [SerializeField] private Image[] slotIcons;

    
    [SerializeField] private Sprite appleSprite;
    [SerializeField] private Sprite appSprite; 
    [SerializeField] private Sprite weaponSprite;
    [SerializeField] private Sprite AxeSprite;
  
    

    [SerializeField] private Sprite emptyIcon;

    void Update()
    {
        Transform handPoint = GameObject.Find("HandPoint")?.transform;

        
        for (int i = 0; i < slotIcons.Length; i++)
        {
            slotIcons[i].sprite = emptyIcon;
        }

        if (handPoint == null || handPoint.childCount == 0)
            return;

        int slotIndex = 0;

        foreach (Transform child in handPoint)
        {
            if (slotIndex >= slotIcons.Length) break; 

            if (child.CompareTag("Apple"))
                slotIcons[slotIndex].sprite = appleSprite;
            else if (child.CompareTag("Apple")) 
                slotIcons[slotIndex].sprite = appSprite;
            else if (child.CompareTag("Gun"))
                slotIcons[slotIndex].sprite = weaponSprite;
            else if (child.CompareTag("Axe"))
                slotIcons[slotIndex].sprite = AxeSprite;
            else
                slotIcons[slotIndex].sprite = emptyIcon;

            slotIndex++;
        }
    }
}
