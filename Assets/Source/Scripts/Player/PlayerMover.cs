using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Flipper))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private Rigidbody2D _rigidbody;
    private Flipper _flipper;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _flipper = GetComponent<Flipper>();
    }
    
    public void Move(float direction)
    {
        _flipper.Flip(direction);
        _rigidbody.velocity = new Vector2(direction * _moveSpeed, _rigidbody.velocity.y);
    }
}