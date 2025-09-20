using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoCharacter : MonoBehaviour
{
    protected Health _health;
    [SerializeField] protected Transform handTransform;
    protected virtual void Start()
    {
        _health = GetComponent<Health>();
        DisplayHand();
    }

    protected virtual void DisplayHand()
    {
        item item = handTransform.GetComponentInChildren<item>();
        Debug.Log("Display Hand for " );
    }

    public virtual void Death()
    {
        Destroy(gameObject);
    }
  
}

