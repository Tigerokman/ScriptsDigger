using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDig : MonoBehaviour
{
    [SerializeField] private PlayerAnimation _animator;

    private PlayerInput _playerInput;
    private float _digInputButton;
    private float _digInputKeyBoard;

    private void Awake()
    {
        _playerInput = new PlayerInput();
    }

    private void Update()
    {
        _digInputKeyBoard = _playerInput.Player.Dig.ReadValue<float>();

        if( _digInputKeyBoard == 1 || _digInputButton == 1)
        {
            Dig(1);
        }
        else
        {
            Dig();
        }
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void Dig(float digInput = 0)
    {
        _animator.PlayAnimationAttack(digInput != 0);

        if (digInput == 0 && _animator.PickAxeCollider)
            _animator.PickAxeOn();

        if (digInput == 0 && _animator.Particle.activeInHierarchy)
            _animator.OnAttackParticle();

        if (digInput == 0 && _animator.AnimationAttackOn)
            _animator.AnimationAttack();

        if (_animator.AnimationAttackOn == false)
        {
            if (transform.position != _animator.transform.position || transform.rotation != _animator.transform.rotation)
            {
                _animator.UpdatePosition();
            }
        }
    }

    public void PointerDownDig()
    {
        _digInputButton = 1;
    }

    public void PointerUpDig()
    {
        _digInputButton = 0;
    }
}
