using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Build : MonoBehaviour
{
    [SerializeField] public Transform[] buildPoints;

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
        Debug.Log("Point " + currentBuildPoint.name + " is " + currentBuildPoint.GetComponent<SpriteRenderer>().sprite);
        return currentBuildPoint;
    }

}
