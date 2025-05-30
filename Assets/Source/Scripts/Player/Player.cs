using UnityEngine;

[RequireComponent(typeof(ItemsCollector), typeof(InputReader),typeof(PlayerMover))]
[RequireComponent(typeof(PlayerJumper), typeof(PlayerGroundDetector), typeof(PlayerAttacker))]
[RequireComponent(typeof(PlayerAnimator), typeof(Health),typeof(PlayerWallet))]
[RequireComponent(typeof(Vampirism))]
public class Player : MonoBehaviour
{
    private ItemsCollector _itemsCollector;
    private InputReader _inputReader;
    private Health _health;
    private PlayerWallet _playerWallet;
    private PlayerMover _playerMover;
    private PlayerJumper _playerJumper;
    private PlayerGroundDetector _playerGroundDetector;
    private PlayerAttacker _playerAttacker;
    private PlayerAnimator _playerAnimationSetter;
    private Vampirism _vampirism;

    public Health Health => _health; 
    
    private void Awake()
    {
        _itemsCollector = GetComponent<ItemsCollector>();
        _inputReader = GetComponent<InputReader>();
        _health = GetComponent<Health>();
        _playerWallet = GetComponent<PlayerWallet>();
        _playerMover = GetComponent<PlayerMover>();
        _playerJumper = GetComponent<PlayerJumper>();
        _playerGroundDetector = GetComponent<PlayerGroundDetector>();
        _playerAnimationSetter = GetComponent<PlayerAnimator>();
        _playerAttacker = GetComponent<PlayerAttacker>();
        _vampirism = GetComponent<Vampirism>();        
    }
    
    private void OnEnable()
    {
        _itemsCollector.ItemCollected += UseItem;
        _health.Defeated += Die;
        _playerAttacker.Attacking += _playerAnimationSetter.Attack;
        _vampirism.HealthAbsorbed += _health.Recover;
    }

    private void Update()
    {
        if (_inputReader.Direction != 0)
        {
            _playerMover.Move(_inputReader.Direction);
            _playerAnimationSetter.RestartRunAnimation();
        }
        else
        {
            _playerAnimationSetter.StopRunAnimation();
        }

        if (_inputReader.IsSpacebarPressed && _playerGroundDetector.IsGrounded)
        {
            _playerJumper.Jump();
        }

        if (_inputReader.IsLeftMouseButtonPressed)
        {
            _playerAttacker.Attack();
        }

        if (_inputReader.IsRightMouseButtonPressed)
        {
            _vampirism.ActivateAbility();
        }
    }

    private void OnDisable()
    {
        _itemsCollector.ItemCollected -= UseItem;
        _health.Defeated -= Die;
        _playerAttacker.Attacking -= _playerAnimationSetter.Attack;
    }

    private void UseItem(Item item)
    {
        if (item.TryGetComponent(out Coin coin))
        {
            _playerWallet.TakeCoin(coin);
        }

        if (item.TryGetComponent(out Heart heart))
        {
            _health.Recover(heart.HealtAmount);
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}