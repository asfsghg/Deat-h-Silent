using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallEvent : MonoBehaviour
{
    [SerializeField] private Wallet wallet;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            wallet.AddCoins(10);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            wallet.IsSubtendCoins(10);
        }
    }
}
