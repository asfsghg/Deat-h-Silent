using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

public class InventoriSlot : MonoBehaviour
{
    public ItemScriptobelObject item;
    public int amount;
    public bool isEmpty = true;
    public GameObject iconGO;
    public TMP_Text itemAmount;

    private void Start()
    {
        iconGO = transform.GetChild(0).gameObject;
        itemAmount = transform.GetChild(1).GetComponent<TMP_Text>();
    }
    public void SetIcon(Sprite icon)
    {
        iconGO.GetComponent<Image>().color = new Color(1,1, 1, 1);
        iconGO.GetComponent<Image>().sprite = icon;
    }
}
