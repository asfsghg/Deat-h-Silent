using UnityEngine;

public class Items : MonoBehaviour
{


    public InventoryItemData itemData; 

    public int amount = 1;

    private void OnValidate()
    {
        if (itemData != null)
        {
            gameObject.name = "Item_" + itemData.itemName;
        }
    }
}