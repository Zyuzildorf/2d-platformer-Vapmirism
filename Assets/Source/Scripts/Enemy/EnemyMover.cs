using UnityEngine;

[RequireComponent(typeof(Flipper))]
public class EnemyMover : MonoBehaviour
{
    private Flipper _flipper;
    private Vector3 _direction;

    private void Awake()
    {
        _flipper = GetComponent<Flipper>();
    }

    public void MoveTo(Vector3 target, float speed)
    {
        FlipTowardsTarget(target);

        transform.position = Vector2.MoveTowards(transform.position,
            target,
            speed * Time.deltaTime);
    }

    private void FlipTowardsTarget(Vector3 target)
    {
        _direction = transform.position - target;

        _flipper.Flip(_direction.x);
    }
}