using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacker : MonoBehaviour
{
    [SerializeField] private int _attackDamage = 20;
    [SerializeField] private float _attackDistance;
    [SerializeField] private float _attackDelay = 2f;

    private WaitForSeconds _waitForSeconds;
    private List<Collider2D> _hit;
    private bool _isAttackDelayOver;

    public event Action Attacking;

    private void Awake()
    {
        _waitForSeconds = new WaitForSeconds(_attackDelay);
        _isAttackDelayOver = true;
    }

    public void Attack(Health playerHealth)
    {
        if (_isAttackDelayOver == false)
            return;

        if (IsAttackPossibility(playerHealth.transform.position))
        {
            Attacking?.Invoke();
            playerHealth.TakeDamage(_attackDamage);
        }

        StartCoroutine(WaitForNextAttack());
    }

    private bool IsAttackPossibility(Vector3 target)
    {
        return target.IsEnoughClose(transform.position, _attackDistance);
    }

    private IEnumerator WaitForNextAttack()
    {
        _isAttackDelayOver = false;
        yield return _waitForSeconds;
        _isAttackDelayOver = true;
    }
}