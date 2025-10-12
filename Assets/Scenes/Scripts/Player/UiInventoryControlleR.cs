using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class UiInventoryControlleR : MonoBehaviour
{
    [SerializeField] private Image[] slotIcons;

    [Header("Icons")]
    [SerializeField] private Sprite appleSprite;
    [SerializeField] private Sprite appSprite; // другой предмет
    [SerializeField] private Sprite weaponSprite;

    [SerializeField] private Sprite emptyIcon;

    void Update()
    {
        Transform handPoint = GameObject.Find("HandPoint")?.transform;

        // Очистить все иконки перед обновлением
        for (int i = 0; i < slotIcons.Length; i++)
        {
            slotIcons[i].sprite = emptyIcon;
        }

        if (handPoint == null || handPoint.childCount == 0)
            return;

        int slotIndex = 0;

        foreach (Transform child in handPoint)
        {
            if (slotIndex >= slotIcons.Length) break; // чтобы не выйти за пределы массива

            if (child.CompareTag("Apple"))
                slotIcons[slotIndex].sprite = appleSprite;
            else if (child.CompareTag("App")) // твой второй предмет
                slotIcons[slotIndex].sprite = appSprite;
            else if (child.CompareTag("Weapon"))
                slotIcons[slotIndex].sprite = weaponSprite;
            else
                slotIcons[slotIndex].sprite = emptyIcon;

            slotIndex++;
        }
    }
}
