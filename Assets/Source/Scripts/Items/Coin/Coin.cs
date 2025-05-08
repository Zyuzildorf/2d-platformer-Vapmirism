using UnityEngine;

public class Coin : Item 
{
    [SerializeField] private int _coinValue = 50;
    
    public int CoinValue => _coinValue;
}