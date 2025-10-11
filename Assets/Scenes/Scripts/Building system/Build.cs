using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Build : MonoBehaviour
{
    [SerializeField] public Transform[] buildPoints;
    [SerializeField] public Transform[] buildWall;

    public Transform SetBuild(Vector3 position)
    {
         Transform currentBuildPoint = null;
        float minDistance = Mathf.Infinity;
        foreach (var point in buildPoints)
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

    public Transform SetBuildWall(Vector3 position)
    {
        Transform currentBuildPoint1 = null;
        float minDistance1 = Mathf.Infinity;
        foreach (var point in buildWall)
        {
            Vector3 worldPos1 = point.position;
            float distance1 = Vector3.Distance(worldPos1, position);
            if (distance1 < minDistance1)
            {
                currentBuildPoint1 = point;
                minDistance1 = distance1;
                
            }
        }
        if (currentBuildPoint1 == null)
        {
            return null;
        }
      
        return currentBuildPoint1;
    }

}
