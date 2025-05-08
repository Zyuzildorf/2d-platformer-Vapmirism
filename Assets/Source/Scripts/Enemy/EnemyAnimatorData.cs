using UnityEngine;

public static class EnemyAnimatorData
{
   public static class Params
   {
      public static readonly int IsWalking = Animator.StringToHash(nameof(IsWalking));
      public static readonly int GetHitted = Animator.StringToHash(nameof(GetHitted));
      public static readonly int IsChasing = Animator.StringToHash(nameof(IsChasing));
      public static readonly int Hitting = Animator.StringToHash(nameof(Hitting));
   }
}