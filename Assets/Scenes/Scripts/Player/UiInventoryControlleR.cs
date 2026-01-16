using UnityEngine;
using UnityEngine.UI;

public class UiInventoryControlleR : MonoBehaviour
{
    [SerializeField] private InventoryData inventoryCore; 
    [SerializeField] private Image[] slotIcons;
    [SerializeField] private Sprite emptyIcon;

    void OnEnable()
    {
        if (inventoryCore != null) inventoryCore.OnChange += RefreshUI;
        RefreshUI();
    }

    void OnDisable()
    {
        if (inventoryCore != null) inventoryCore.OnChange -= RefreshUI;
    }

    public void RefreshUI()
    {
        if (inventoryCore == null) return;

        for (int i = 0; i < slotIcons.Length; i++)
        {
            if (slotIcons[i] == null) continue;


            if (i < inventoryCore.items.Count && inventoryCore.items[i] != null)
            {
                Sprite itemSprite = inventoryCore.items[i].icon;
                if (itemSprite != null)
                {
                    slotIcons[i].sprite = itemSprite;
                    slotIcons[i].enabled = true;
                    slotIcons[i].color = Color.white; 
                }
            }
            else // Если слот пустой
            {
                if (emptyIcon != null)
                {
                    slotIcons[i].sprite = emptyIcon;
                    slotIcons[i].enabled = true;
                }
                else
                {
 
                    slotIcons[i].color = new Color(1, 1, 1, 0); 
                }
            }
        }
    }
}