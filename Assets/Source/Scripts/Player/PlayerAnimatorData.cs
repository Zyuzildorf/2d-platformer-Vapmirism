using UnityEngine;

public static class PlayerAnimatorData
{
    public static class Params
    {
        public static readonly int Hitting = Animator.StringToHash(nameof(Hitting));
        public static readonly int IsRunning = Animator.StringToHash(nameof(IsRunning));
    }
}