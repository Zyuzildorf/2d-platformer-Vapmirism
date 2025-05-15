using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] protected int _maxValue;
    
    private int _currentValue;

    public event Action Defeated;
    public event Action DamageTaken;
    public event Action<int> HealthChanged;

    public int MaxHealth => _maxValue;
    public int CurrentValue => _currentValue;
    
    private void Awake()
    {
        _currentValue = _maxValue;
    }
    
    public virtual void TakeDamage(int damage)
    {
        if (damage < 0)
        {
            return;
        }
        
        if (_currentValue > 0)
        {
            _currentValue -= damage;
            HealthChanged?.Invoke(_currentValue);
            DamageTaken?.Invoke();
        }
        
        if (_currentValue <= 0)
        {
            Defeated?.Invoke();
        }
    }
    
    public void Recover(int healValue)
    {
        if (healValue < 0)
        {
            return;
        }
        
        _currentValue += healValue;

        if (_currentValue > _maxValue)
        {
            _currentValue = _maxValue;
        }
        
        HealthChanged?.Invoke(_currentValue);
    }
}