using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build : MonoBehaviour
{
    [SerializeField] public Transform[] buildPoints;

    public void SetBuild(Vector3 position)
    {
        if (buildPoints == null || buildPoints.Length == 0) return;
        Transform nearestPoint = null;
        float minDistance = Mathf.Infinity;
        Debug.Log("Ближайшая точка: " + nearestPoint.name);
        foreach (Transform point in buildPoints)
        {
            Debug.Log("Ближайшая точка: " + nearestPoint.name);
            float distance = Vector3.Distance(position, point.position);
            if (distance < minDistance)
            {
                Debug.Log("Ближайшая точка: " + nearestPoint.name);
                minDistance = distance;
                nearestPoint = point;
            }
        }
        
        if (nearestPoint != null)
        {
            Debug.Log("Ближайшая точка: " + nearestPoint.name);
            
        }
        
    }

}
