using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemUse : MonoBehaviour
{
    [SerializeField] private Transform handPoint;

    void Update()
    {
        if (handPoint == null) return;

        
        if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0))
        {
            if (handPoint.childCount > 0)
            {
                Transform item = handPoint.GetChild(0);

                
                IUsable usable = item.GetComponent<IUsable>();
                if (usable != null)
                {
                    usable.Use();
                }
            }
        }
    }

}
