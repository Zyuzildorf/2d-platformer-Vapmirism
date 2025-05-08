using UnityEngine;

public class Heart : Item
{
    [SerializeField] private int _healthAmount = 50;
    
    public int HealtAmount => _healthAmount;
}