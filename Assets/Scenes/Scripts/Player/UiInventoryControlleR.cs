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
    [SerializeField] private Sprite potionSprite;
    [SerializeField] private Sprite rockSprite;
    [SerializeField] private Sprite emptyIcon;

    private Transform handPoint;
    private Dictionary<string, Sprite> tagToSprite;

    void Start()
    {
        
        handPoint = GameObject.Find("HandPoint")?.transform;

       
        tagToSprite = new Dictionary<string, Sprite>()
        {
            {"Apple", appleSprite},
            {"App", appSprite},
            {"Gun", weaponSprite},
            {"Potion", potionSprite},
            {"Rock", rockSprite}

        };
    }

    void Update()
    {
        
        for (int i = 0; i < slotIcons.Length; i++)
            slotIcons[i].sprite = emptyIcon;

        if (handPoint == null || handPoint.childCount == 0)
            return;

        int slotIndex = 0;

        foreach (Transform child in handPoint)
        {
            if (slotIndex >= slotIcons.Length)
                break;

            if (tagToSprite.TryGetValue(child.tag, out Sprite sprite))
                slotIcons[slotIndex].sprite = sprite;
            else
                slotIcons[slotIndex].sprite = emptyIcon;

            slotIndex++;
        }

    }
}
