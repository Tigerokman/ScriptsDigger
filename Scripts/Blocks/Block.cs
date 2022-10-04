using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Block : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] protected float HealthToDestroy;
    [SerializeField] private EndLevel _endLevelTrigger;

    private float _invulnerability = 0.25f;
    private ParticleSystem _temp;
    private Animator _animator;

    public EndLevel EndLevelTrigger => _endLevelTrigger;
    public Animator Animator => _animator;
    protected float Health;

    private void Start()
    {
        _animator = GetComponent<Animator>();

        if(_health != 0)
        Health = _health;

        StartCoroutine(IsInvulnerability());
    }

    public void TakeDamage(float damage)
    {
        if (_invulnerability <= 0)
        {
            float invulnerability = 0.25f;
            _invulnerability = invulnerability;
            PlayAnimationDamage();
            OnParticle();
            Health -= damage;

            StartCoroutine(IsInvulnerability());
            CheckHealth(Health);
        }
    }

    public void Init(float health, Animator animator, EndLevel endLevelTrigger)
    {
        _endLevelTrigger = endLevelTrigger;
        _animator = animator;
        Health = health;
        CheckHealth(Health);
    }

    private void PlayAnimationDamage()
    {
        string attack = "Attack";

        _animator.SetTrigger(attack);
    }

    protected virtual void OnParticle()
    {
        if (_temp == null)
        {
            _temp = Instantiate(_particleSystem);
            _temp.transform.position = transform.position;
            _temp.TryGetComponent<BlockParticle>(out BlockParticle blockParticle);
            blockParticle.Init();
        }

        _temp.Stop();
        _temp.Play();
    }

    protected virtual void Destroing()
    {
        Destroy(gameObject);
    }

    private void CheckHealth(float health)
    {
        if (health <= HealthToDestroy)
        {
            if (_endLevelTrigger != null)
            {
                _endLevelTrigger.EndLevelTrigger();
            }
            Destroing();
        }
    }

    private IEnumerator IsInvulnerability()
    {
        while (_invulnerability > 0)
        {
            _invulnerability -= Time.deltaTime;
            yield return null;
        }
    }
}
