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
    public Image iconGO;
    public TMP_Text itemAmount;

    private void Start()
    {
       // iconGO = transform.GetChild(0).gameObject; // иконка
        itemAmount = transform.GetChild(1).GetComponent<TMP_Text>(); 
        UpdateUI();
    }

    public void SetIcon(Sprite icon)
    {
        iconGO.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        iconGO.GetComponent<Image>().sprite = icon;
    }

    public void UpdateUI()
    {
        if (!isEmpty && item != null)
        {
            SetIcon(item.itemIcon);
            itemAmount.text = amount.ToString();
            iconGO.sprite = item.itemIcon;
            iconGO.color = Color.white;
            itemAmount.text = amount.ToString();
        }
        else
        {
            iconGO.GetComponent<Image>().color = new Color(1, 1, 1, 0);
           
            itemAmount.text = "";
        }
    }
}


