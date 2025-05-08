using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
public class EnemyPatroler : MonoBehaviour
{
    [SerializeField] private Waypoints _waypoints;
    [SerializeField] private float _pauseTime = 3;
    [SerializeField] private float _accuracyValue = 0.1f;
    [SerializeField] private float _patrolMoveSpeed = 2f;

    private WaitForSeconds _waitForSeconds;
    private EnemyMover _enemyMover;
    private int _currentWaypoint = 0;

    public bool IsTargetReached { get; private set; }

    private void Awake()
    {
        _enemyMover = GetComponent<EnemyMover>();
        _waitForSeconds = new WaitForSeconds(_pauseTime);
    }

    public void Patrol()
    {
        if (IsTargetReached)
        {
            return;
        }
        
        IsTargetReached = transform.position.IsEnoughClose(
            _waypoints.GetArrayElementByIndex(_currentWaypoint).position,
            _accuracyValue);

        if (IsTargetReached)
        {
            StartCoroutine(WaitForNextWaypoint());

            _currentWaypoint = ++_currentWaypoint % _waypoints.GetArrayLength;
        }
        else
        {
            _enemyMover.MoveTo(_waypoints.GetArrayElementByIndex(_currentWaypoint).position, _patrolMoveSpeed);
        }
    }

    private IEnumerator WaitForNextWaypoint()
    {
        yield return _waitForSeconds;
        IsTargetReached = false;
    }
}