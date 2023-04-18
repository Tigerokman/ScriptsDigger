using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelBlocks : EndLevel
{
    [SerializeField] private GameObject _blocks;
    [SerializeField] private GameObject _goldBlocks;
    [SerializeField] private GameObject _stoneBlocks;
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerHealth _playerHealth;

    private int _currentBlocks = 0;
    private int _allBlocks = 0;
    private int _enemyDestroyedBlocks = 0;
    private bool _isLose = false;

    protected virtual void Start()
    {
        int stoneBlockLife = 4;

        _currentBlocks += _blocks.transform.childCount;
        _currentBlocks += _goldBlocks.transform.childCount;
        _currentBlocks += _stoneBlocks.transform.childCount * stoneBlockLife;
        Debug.Log(_currentBlocks);
        _allBlocks = _currentBlocks;
        Debug.Log(_allBlocks);
    }

    public override void EndLevelTrigger()
    {
        _currentBlocks -= 1;

        //PlayerPrefs.SetInt("LevelComplete", 10);
        //_currentBlocks = 0;
        //_allBlocks = 1;

        if (_currentBlocks <= 0)
        {
            Debug.Log(_allBlocks - _enemyDestroyedBlocks);
            Debug.Log(_enemyDestroyedBlocks);

            if (_allBlocks - _enemyDestroyedBlocks > _enemyDestroyedBlocks)
            {
                if (_playerHealth != null)
                    _playerHealth.End();

                base.EndLevelTrigger();
                PlayerOff();
            }
            else
            {
                Lose();
            }
        }
    }

    public void Lose()
    {
        if(_isLose == false)
        {
            _losePanel.SetActive(true);
            LoseSound();
            PlayerOff();
            _isLose = true;
            AnalycicsComponent.OnPlayerDead(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("ЗаписалСмэрть");
        }
    }

    public void EnemyDestroyBlock()
    {
        _enemyDestroyedBlocks++;
        Debug.Log("Удар");
    }

    private void PlayerOff()
    {
        Debug.Log("Работаю");
        string end = "End";
        _playerMovement.enabled = false;
        _playerAnimator.SetTrigger(end);
    }
}
