using UnityEngine;

public class InventoriStory : MonoBehaviour
{
    public InventoryData inventoryCore;
    public float pickupRadius = 3f;
    public LayerMask itemLayer;   

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            Pickup();
        }
    }

    private void Pickup()
    {

        Collider[] colliders = Physics.OverlapSphere(transform.position, pickupRadius, itemLayer);

        foreach (var hit in colliders)
        {
    
            if (hit.TryGetComponent<Item>(out Item worldItem))
            {

                if (worldItem.itemData != null)
                {
   
                    bool success = inventoryCore.AddItem(worldItem.itemData);

                    if (success)
                    {
                     
                        Destroy(hit.gameObject); 
                        break;
                    }
                }
      
            }
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, pickupRadius);
    }
}