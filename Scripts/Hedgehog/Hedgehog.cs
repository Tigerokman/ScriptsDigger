using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(HedgehogMovement))]
[RequireComponent (typeof(HedgehogParticles))]
public class Hedgehog : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private GameObject _head;

    private Animator _animator;
    private HedgehogMovement _movement;
    private PlayerWallet _playerWallet;
    private PlayerStats _playerStats;
    private int _layerHedgehod = 3;
    private int _currentHealth;
    private string _wakeUp = "WakeUpBitch";
    private string _die = "Die";

    public float Attack { get; private set; } = 0;
    protected bool IsBoss = false;

    public event UnityAction<int, Hedgehog> HedgehogCountChange;


    protected virtual void Start()
    {
        Debug.Log("NeBoss");
        _currentHealth = _health;
        _movement = GetComponent<HedgehogMovement>();
        _animator = GetComponent<Animator>();
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Block block) || other.TryGetComponent(out Decoration decoration))
        {

            if (block != null)
            {
                block.TakeDamage(Attack);

                if (other.TryGetComponent(out GoldBlock goldBlock) && IsBoss == false)
                {
                    _playerWallet.GetGold(goldBlock.Bounty);
                }
            }

             TakeDamage();
            _movement.RandomChangeDirection();
        }
        else if (other.TryGetComponent(out PlayerWallet player) && other.TryGetComponent(out PlayerStats playerStats) && IsBoss == false)
        {
            playerStats.InitHedgehog(this);
            WakeUp(player, playerStats);
        }
    }

    public void TakeDamage()
    {
        _currentHealth--;

        if (_currentHealth <= 0)
        {
            HedgehogCountChange?.Invoke(-1, this);
            _animator.enabled = true;
            _head.SetActive(true);
            _playerStats.HedgehogAttackUp -= UpgradeAttack;
            _movement.enabled = false;
            _animator.SetTrigger(_die);
        }
    }

    private void MovementOn()
    {
        _head.SetActive(false);
        _movement.enabled = true;
        _animator.enabled = false;
    }

    protected virtual void WakeUp(PlayerWallet player, PlayerStats playerStats)
    {
        Debug.Log("2 авы");
        HedgehogCountChange?.Invoke(1,this);
        _playerStats = playerStats;
        _playerStats.HedgehogAttackUp += UpgradeAttack;
        UpgradeAttack();
        _playerWallet = player;
        gameObject.layer = _layerHedgehod;
        _animator.SetTrigger(_wakeUp);
    }

    private void UpgradeAttack()
    {
        Attack = _playerStats.HedgehodAttack;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
