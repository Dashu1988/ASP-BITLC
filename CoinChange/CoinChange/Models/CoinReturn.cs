using System;
using System.Collections.Generic;
using System.Linq;
namespace CoinChange.Models;

public class CoinReturn
{
    private string _currencySymbol;
    private List<decimal> _coinSet;
    public decimal input {get; set;}

    public CoinReturn(string newCurrencySymbol, List<decimal> newCoinSet)
    {
        this.NewCoinSet(newCurrencySymbol, newCoinSet);
    }


    public CoinReturn()
    {
        this._coinSet = new List<decimal>() { 2m, 1m, 0.5m, 0.2m, 0.1m, 0.05m, 0.02m, 0.01m };
        this._currencySymbol = "€";
    }

    public void NewCoinSet(string newCurrencySymbol, List<decimal> newCoinSet)
    {
        this._currencySymbol = newCurrencySymbol;
        this._coinSet = newCoinSet.Distinct().OrderByDescending(x => x).ToList();
    }

    public Dictionary<decimal, int> GetChange(decimal moneyInput)
    {
        Dictionary<decimal, int> change = new Dictionary<decimal, int>();
        for (int i = 0; i < _coinSet.Count; i++)
        {
            while (moneyInput >= _coinSet[i])
            {
                if (!change.ContainsKey(_coinSet[i]))
                {
                    change.Add(_coinSet[i], 1);
                }
                else
                {
                    change[_coinSet[i]]++;
                }

                moneyInput -= _coinSet[i];
            }
        }

        return change;
    }

    public string GetChangeToString(decimal amount)
    {
        Dictionary<decimal, int> change = this.GetChange(amount);
        string output = "";
        foreach (KeyValuePair<decimal, int> coins in change)
        {
            output += coins.Value + "x" + coins.Key + _currencySymbol + "\n";
        }

        return output;
    }
}