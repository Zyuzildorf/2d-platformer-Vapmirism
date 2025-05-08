using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacker : MonoBehaviour
{
    [SerializeField] private float _attackRange = 0.5f;
    [SerializeField] private int _attackDamage = 20;
    [SerializeField] private float _attackDelay = 0.1f;
   
    private WaitForSeconds _waitForSeconds;
    private List<Enemy> _hitEnemies;
    private List<Collider2D> _hit;
    private bool _isAttackDelayOver;

    public event Action Attacking;
    
    private void Awake()
    {
        _waitForSeconds = new WaitForSeconds(_attackDelay);
        _isAttackDelayOver = true;
    }

    public void Attack()
    {
        if (_isAttackDelayOver == false)
            return;

        Attacking?.Invoke();
        
        _hit = Physics2D.OverlapCircleAll(transform.position, _attackRange).ToList();
        _hitEnemies = new List<Enemy>();
        
        for (int i = 0; i < _hit.Count; i++)
        {
            if (_hit[i].TryGetComponent(out Enemy enemy))
            {
                _hitEnemies.Add(enemy);
            }
        }

        foreach (Enemy enemy in _hitEnemies)
        {
            enemy.Health.TakeDamage(_attackDamage);
        }

        StartCoroutine(WaitForNextAttack());
    }
    
    private IEnumerator WaitForNextAttack()
    {
        _isAttackDelayOver = false;
        yield return _waitForSeconds;
        _isAttackDelayOver = true;
    }
}