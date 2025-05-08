using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] protected int CurrentHealth;
    
    private int _maxHealth;

    public int MaxHealth => _maxHealth;
    public event Action Defeated;
    public event Action DamageTaken;
    public event Action<int> HealthChanged;
    
    private void Awake()
    {
        _maxHealth = CurrentHealth;
    }
    
    public virtual void TakeDamage(int damage)
    {
        if (damage < 0)
        {
            return;
        }
        
        if (CurrentHealth > 0)
        {
            CurrentHealth -= damage;
            HealthChanged?.Invoke(CurrentHealth);
            DamageTaken?.Invoke();
        }
        
        if (CurrentHealth <= 0)
        {
            Defeated?.Invoke();
        }
    }
    
    public void HealthRecover(Heart heart)
    {
        if (heart.HealtAmount < 0)
        {
            return;
        }
        
        CurrentHealth += heart.HealtAmount;

        if (CurrentHealth > _maxHealth)
        {
            CurrentHealth = _maxHealth;
        }
        
        HealthChanged?.Invoke(CurrentHealth);
    }
}