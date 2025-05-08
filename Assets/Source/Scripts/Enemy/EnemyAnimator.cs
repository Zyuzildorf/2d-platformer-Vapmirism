using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimator : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void GetHit()
    {
        _animator.SetTrigger(EnemyAnimatorData.Params.GetHitted);
    }

    public void Attack()
    {
        _animator.SetTrigger(EnemyAnimatorData.Params.Hitting);
    }

    public void RestartWalkAnimation()
    {
        _animator.SetBool(EnemyAnimatorData.Params.IsWalking, true);
    }

    public void StopWalkAnimation()
    {
        _animator.SetBool(EnemyAnimatorData.Params.IsWalking, false);
    }

    public void RestartChaseAnimation()
    {
        _animator.SetBool(EnemyAnimatorData.Params.IsChasing, true);
    }

    public void StopChaseAnimation()
    {
        _animator.SetBool(EnemyAnimatorData.Params.IsChasing, false);
    }
}