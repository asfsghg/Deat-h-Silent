using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildWall : MonoBehaviour
{
    [SerializeField] public Transform[] buildPointsForBaseplate;

    public Transform SetBuild(Vector3 position)
    {
        Transform currentBuildPoint = null;
        float minDistance = Mathf.Infinity;
        
        foreach (var point in buildPointsForBaseplate)
        {
            Vector3 worldPos = point.position;
            float distance = Vector3.Distance(worldPos, position);
            if (distance < minDistance)
            {
                currentBuildPoint = point;
                minDistance = distance;

            }
        }

        if (currentBuildPoint == null)
        {
            return null;
        }

        return currentBuildPoint;
    }
}
