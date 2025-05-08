using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothHealthBar : HealthIndicator
{
    [SerializeField] private Slider _healthBar;
    [SerializeField] private float _duration = 2f;

    private Coroutine _currentCoroutine;
    private Quaternion _fixedRotation;

    private void Awake()
    {
        _fixedRotation = transform.rotation;
    }

    private void LateUpdate()
    {
        transform.rotation = _fixedRotation;
    }

    protected override void UpdateHealthIndicator(int healthValue)
    {
        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }

        _currentCoroutine = StartCoroutine(SmoothHealthChange(healthValue));
    }

    private IEnumerator SmoothHealthChange(int targetHealth)
    {
        float targetValue = (float)targetHealth / _health.MaxHealth;
        float startValue = _healthBar.value;
        float timePassed = 0f;

        while (timePassed < _duration)
        {
            timePassed += Time.deltaTime;
            _healthBar.value = Mathf.MoveTowards(startValue, targetValue, timePassed / _duration);
            yield return null;
        }

        _healthBar.value = targetValue;
        _currentCoroutine = null;
    }
}