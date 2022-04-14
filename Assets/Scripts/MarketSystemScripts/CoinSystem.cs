using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinSystem : MonoBehaviour
{
    [SerializeField] int coinsAmount;

    [SerializeField] TextMeshProUGUI coinsUi;
    // Start is called before the first frame update
    void Start()
    {
        SetTheUiCoins();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RemoveCoins(int amountToRemove)
    {
        if(coinsAmount- amountToRemove>=0)
        {
            coinsAmount -= amountToRemove;

            SetTheUiCoins();
        }
 
    }

    public void AddCoins(int amountToAdd)
    {
       coinsAmount += amountToAdd;

        SetTheUiCoins();

    }

    public int CoinsAmount()
    {
        return coinsAmount;
    }

    void SetTheUiCoins()
    {
        coinsUi.text = coinsAmount.ToString();
    }



}
