using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;
using RedstoneinventeGameStudio;

public class InventoriSlot : MonoBehaviour
{
    public InventoryItemData item;
    public int amount;
    public bool isEmpty = true;
    public GameObject iconGO;
    public TMP_Text itemAmount;

    private void Awake()
    {
        Image[] images = GetComponentsInChildren<Image>();
        foreach (var img in images)
        {
            if (img.gameObject != gameObject)
            {
                iconGO = img.gameObject;
                break;
            }
        }
        TMP_Text[] texts = GetComponentsInChildren<TMP_Text>();
        foreach (var txt in texts)
        {
            if (txt.gameObject != gameObject)
            {
                itemAmount = txt;
                break;
            }
        }
        UpdateUI();
    }

    public void SetIcon(Sprite icon)
    {
        Image img = iconGO.GetComponent<Image>();
        
        img.color = Color.white;
        img.sprite = icon;
        // iconGO.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        iconGO.GetComponent<Image>().sprite = icon;
    }

    public void UpdateUI()
    {
        if (!isEmpty && item != null)
        {
            SetIcon(item.icon);
            itemAmount.text = amount.ToString();
        }
        else
        {
            iconGO.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            itemAmount.text = "";
        }
    }
}


