using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Vampirism : MonoBehaviour
{
    [SerializeField] private VampirismVisual _vampirismVisual;
    [SerializeField] private float _duration = 6f;
    [SerializeField] private float _tickInterval = 0.1f;
    [SerializeField] private float _cooldown = 4f;
    [SerializeField] private float _abilityRange = 3.5f;
    [SerializeField] private int _damagePerTick = 1;

    private WaitForSeconds _waitForCooldown;
    private WaitForSeconds _waitForTick;
    private Coroutine _vampirismCoroutine;
    private List<Enemy> _enemiesInRange;
    private List<Collider2D> _hitColliders;
    private Enemy _enemyToHit;
    private bool _isOnCooldown;
    private bool _isActive;

    public event Action VampirismActivated;
    public event Action<int> HealthAbsorbed;

    private void Awake()
    {
        _waitForTick = new WaitForSeconds(_tickInterval);
        _waitForCooldown = new WaitForSeconds(_cooldown);
        _isOnCooldown = false;
        _isActive = false;
        _vampirismVisual.Deactivate();
    }

    public void ActivateAbility()
    {
        if (_isOnCooldown == false && _isActive == false)
        {
            _isActive = true;
            _vampirismCoroutine = StartCoroutine(VampirismRoutine());
            _vampirismVisual.Activate();
        }
    }

    private IEnumerator VampirismRoutine()
    {
        float endTime = Time.time + _duration;

        while (Time.time < endTime)
        {
            FindEnemies();

            if (_enemyToHit != null)
            {
                _enemyToHit.Health.TakeDamage(_damagePerTick);
                HealthAbsorbed?.Invoke(_damagePerTick);
            }

            yield return _waitForTick;
        }

        DeactivateAbility();
    }

    private void FindEnemies()
    {
        _enemyToHit = null;

        if (CheckForEnemies() == false || _enemiesInRange.Count == 0)
            return;

        if (_enemiesInRange.Count == 1)
        {
            _enemyToHit = _enemiesInRange[0];
        }
        else
        {
            Enemy closestEnemy = null;
            float minDistance = _abilityRange;

            foreach (Enemy enemy in _enemiesInRange)
            {
                float distance = Vector2.Distance(transform.position, enemy.transform.position);

                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestEnemy = enemy;
                }
            }

            _enemyToHit = closestEnemy;
        }
    }

    private bool CheckForEnemies()
    {
        bool isEnemiesFound = false;

        _hitColliders = Physics2D.OverlapCircleAll(transform.position, _abilityRange).ToList();
        _enemiesInRange = new List<Enemy>();

        foreach (var collider in _hitColliders)
        {
            if (collider.TryGetComponent(out Enemy enemy))
            {
                _enemiesInRange.Add(enemy);
                isEnemiesFound = true;
            }
        }

        return isEnemiesFound;
    }

    private IEnumerator CooldownRoutine()
    {
        _isOnCooldown = true;
        yield return _waitForCooldown;
        _isOnCooldown = false;
    }


    private void DeactivateAbility()
    {
        _isActive = false;
        _vampirismVisual.Deactivate();

        if (_vampirismCoroutine != null)
        {
            StopCoroutine(_vampirismCoroutine);
            _vampirismCoroutine = null;
        }


        StartCoroutine(CooldownRoutine());
    }
}
