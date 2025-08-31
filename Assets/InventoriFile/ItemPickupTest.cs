using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickupTest : MonoBehaviour
{
    public float reachDistance = 2f;  
    public float pickupRadius = 3f;  
    private Camera MainCamera;

    void Start()
    {
        MainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            PickupItem();
        }
    }

    private void PickupItem()
    {
        Vector3 center = MainCamera.transform.position + MainCamera.transform.forward * reachDistance;
        Collider[] hits = Physics.OverlapSphere(center, pickupRadius);

        foreach (Collider col in hits)
        {
            if (col.TryGetComponent<ItemS>(out ItemS item))
            {
                Debug.Log("Picked up: " + item.item);
                Destroy(col.gameObject);  
                break;  
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (MainCamera != null)
        {
            Vector3 center = MainCamera.transform.position + MainCamera.transform.forward * reachDistance;
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(center, pickupRadius);
        }
    }
}
