using UnityEngine;

[RequireComponent(typeof(EnemyPatroler), typeof(EnemyAnimator),typeof(Health) )]
[RequireComponent(typeof(EnemyChaser), typeof(EnemyAttacker))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private PlayerSearcher _playerSearcher;

    private bool _isPatrolling;
    private bool _isChasing;
    private Health _health;
    private EnemyChaser _enemyChaser;
    private EnemyPatroler _enemyPatrol;
    private EnemyAttacker _enemyAttacker;
    private EnemyAnimator _enemyAnimator;

    public Health Health => _health;
    
    private void Awake()
    {
        _health = GetComponent<Health>();
        _enemyChaser = GetComponent<EnemyChaser>();
        _enemyPatrol = GetComponent<EnemyPatroler>();
        _enemyAttacker = GetComponent<EnemyAttacker>();
        _playerSearcher = GetComponent<PlayerSearcher>();
        _enemyAnimator = GetComponent<EnemyAnimator>();
    }

    private void OnEnable()
    {
        _enemyAttacker.Attacking += _enemyAnimator.Attack;
        _health.DamageTaken += _enemyAnimator.GetHit;
        _health.Defeated += Die;
    }

    private void Update()
    {
        if (_playerSearcher.FindedPlayer == null)
        {
            _enemyAnimator.StopChaseAnimation();

            _enemyPatrol.Patrol();

            if (_enemyPatrol.IsTargetReached == false)
            {
                _enemyAnimator.RestartWalkAnimation();
            }
            else
            {
                _enemyAnimator.StopWalkAnimation();
            }
        }
        else
        {
            _enemyAnimator.StopWalkAnimation();
            _enemyAnimator.RestartChaseAnimation();

            _enemyChaser.Chase(_playerSearcher.FindedPlayer.transform.position);

            _enemyAttacker.Attack(_playerSearcher.FindedPlayer.Health);
        }
    }
    
    private void OnDisable()
    {
        _enemyAttacker.Attacking -= _enemyAnimator.Attack;
        _health.DamageTaken -= _enemyAnimator.GetHit;
        _health.Defeated -= Die;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}