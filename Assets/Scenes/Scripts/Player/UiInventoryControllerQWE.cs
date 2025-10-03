using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class UiInventoryControllerQWE : MonoBehaviour
{
    [SerializeField] private Image[] slotIcons;
    [SerializeField] private Sprite appleSprite;  
    [SerializeField] private Sprite emptyIcon;

    void Update()
    {
        Transform handPoint = GameObject.Find("HandPoint")?.transform;

        if (handPoint != null && handPoint.childCount > 0)
        {
            bool foundApple = false;

            foreach (Transform child in handPoint)
            {
                if (child.CompareTag("Apple"))
                {
                    slotIcons[0].sprite = appleSprite; 
                    foundApple = true;
                    break;
                }
            }

            if (!foundApple)
                slotIcons[0].sprite = emptyIcon; 
        }
        else
        {
            slotIcons[0].sprite = emptyIcon; 
        }
    }
}
