using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private EndLevelBlocks _endLevelBlocks;
    [SerializeField] private PlayerAnimation _animator;

    private PlayerMovement _playerMovement;
    private bool _isEnd = false;

    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    public void TakeDamage()
    {
        if (_isEnd == false)
        {
            _playerMovement.enabled = false;
            _animator.TakeDamage(this);
            End();
        }
    }

    public void Death()
    {
        _endLevelBlocks.Lose();
    }

    public void End()
    {
        _isEnd = true;
    }
}
