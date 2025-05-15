using System.Collections;
using UnityEngine;
 
public class SmoothHealthBar : HealthSliderBar
{
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
        float startValue = HealthBar.value;
        float timePassed = 0f;

        while (timePassed < _duration)
        {
            timePassed += Time.deltaTime;
            HealthBar.value = Mathf.MoveTowards(startValue, targetValue, timePassed / _duration);
            yield return null;
        }

        HealthBar.value = targetValue;
        _currentCoroutine = null;
    }
}