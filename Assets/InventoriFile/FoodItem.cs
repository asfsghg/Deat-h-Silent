using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Food Item", menuName = "Inventory/Items/newFoodItem")]
public class FoodItem : ItemScriptobelObject
{
    public int healAmount;
    void Start()
    {
        itemType = ItemType.Food;
    }

   
    void Update()
    {
        
    }
}
