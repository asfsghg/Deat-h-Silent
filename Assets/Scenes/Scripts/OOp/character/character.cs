using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoCharacter : MonoBehaviour
{

    [SerializeField] protected Transform handTransform;
    protected virtual void Start()
    {

        DisplayHand();
    }

    protected virtual void DisplayHand()
    {
        item item = handTransform.GetComponentInChildren<item>();
        Debug.Log("Display Hand for " );
    }

    
  
}

