using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private Animator _shakeCam;
    [SerializeField] private PlayerDig _playerDig;
    [SerializeField] private PickAxe _pickAxe;
    [SerializeField] private GameObject _particle;

    private Animator _animator;
    private PlayerHealth _health;
    private bool _pickAxeCollider = false;
    private bool _isJump = false;
    private bool _animationAttackOn = false;

    public bool AnimationAttackOn => _animationAttackOn;
    public bool IsJump => _isJump;
    public bool PickAxeCollider => _pickAxeCollider;
    public GameObject Particle => _particle;

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PickAxeOn()
    {
        _pickAxeCollider = !_pickAxeCollider;
        _pickAxe.OnAttack(_pickAxeCollider);
    }

    public void OnAttackParticle()
    {
        _particle.SetActive(_particle.activeInHierarchy == false);
    }

    public void PlayAnimationAttack(bool isAttack)
    {
        string dig = "IsAttack";
        _animator.SetBool(dig, isAttack);
    }

    public void TakeDamage(PlayerHealth health)
    {
        _health = health;
        string death = "Die";
        transform.localPosition = new Vector3(0, 0, 0);
        _animator.SetTrigger(death);
    }

    public void RunAnimation(bool isRun)
    {
        string run = "IsRun";
        _animator.SetBool(run, isRun);
    }

    public void UpdatePosition()
    {
        if(_isJump == false)
        transform.localPosition = new Vector3(0, 0, 0);

        transform.rotation = new Quaternion(0, 0, 0, 0);
    }

    public void AnimationAttack()
    {
        _animationAttackOn = !_animationAttackOn;
    }

    private void Death()
    {
        _animator.enabled = false;
        _health.Death();
    }

    private void JumpOn()
    {
        _isJump = !_isJump;
    }

    private void SkillOn()
    {
        string skill = "Skill";
        _animator.SetTrigger(skill);
    }

    private void LastAttackDamage()
    {
        string shake = "Shake";
        _shakeCam.SetTrigger(shake);
        _pickAxe.LastAttackDamage();
    }
}
