using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private PlayerAnimation _animator;
    [SerializeField] private GameObject _playerModel;
    [SerializeField] private Joystick _joystick;

    private bool _canMove = true;
    private PlayerInput _playerInput;
    private Vector3 _movementInput;
    private float _speedDirection = 0.2f;

    private void Awake()
    {
        _playerInput = new PlayerInput();
    }

    private void Update()
    {

        if (_animator.IsJump == false)
        {
            _movementInput = _playerInput.Player.Movement.ReadValue<Vector2>();

            if (_movementInput.x == 0 && _movementInput.y == 0)
            {
                _movementInput = new Vector2(_joystick.Horizontal, _joystick.Vertical);
            }

            Move(_movementInput);
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

    private void Move(Vector2 direction)
    {
        Vector3 move = new Vector3(direction.x * _speed, 0, direction.y * _speed);

        if (Vector3.Angle(Vector3.forward, move) > 1f || Vector3.Angle(Vector3.forward, move) == 0)
        {
            Vector3 _direction = Vector3.RotateTowards(transform.forward, move, _speedDirection, 0.0f);
            transform.rotation = Quaternion.LookRotation(_direction);
        }

        transform.position += move * Time.deltaTime;
        _animator.RunAnimation(direction.x != 0 || direction.y != 0);
    }

    public void Jump()
    {
        _canMove = false;
    }
}

