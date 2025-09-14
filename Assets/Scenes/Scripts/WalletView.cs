using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WalletView : MonoBehaviour
{
    [SerializeField] private Text coinsText;
    
    [SerializeField] private Button changeCoinButton;
    void Awake()
    {
        
        Wallet.OnChangeCoins += DisplayCoins;
        
        
        
    }
    

    private void OnEnable()
    {
        Wallet.OnChangeCoins += DisplayCoins;
    }

    private void DisplayCoins(int value)
    {
        coinsText.text = value.ToString();
    } 
    private void OnDisable()
    {
        Wallet.OnChangeCoins -= DisplayCoins;
    }

    private void OnDestroy()
    {
        Wallet.OnChangeCoins -= DisplayCoins;
    }
}
