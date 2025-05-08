using UnityEngine;

public class HealthIndicator : MonoBehaviour
{
    [SerializeField] protected Health _health;

    private void OnEnable()
    {
        _health.HealthChanged += UpdateHealthIndicator;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= UpdateHealthIndicator;
    }
    
    protected virtual void UpdateHealthIndicator(int healthValue)
    {
        
    }
}