using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
public class EnemyChaser : MonoBehaviour
{
   [SerializeField] private float _chaseMoveSpeed = 4f;
   
   private EnemyMover _enemyMover;

   private void Awake()
   {
      _enemyMover = GetComponent<EnemyMover>();
   }

   public void Chase(Vector3 target)
   {
      _enemyMover.MoveTo(target, _chaseMoveSpeed);
   }
}