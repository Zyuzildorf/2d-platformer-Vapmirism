using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    
    public void Attack()
    {
        _animator.SetTrigger(PlayerAnimatorData.Params.Hitting);
    }
    
    public void RestartRunAnimation()
    {
        _animator.SetBool(PlayerAnimatorData.Params.IsRunning, true);
    }

    public void StopRunAnimation()
    {
        _animator.SetBool(PlayerAnimatorData.Params.IsRunning, false);
    }
}