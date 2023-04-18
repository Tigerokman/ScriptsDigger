using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class InfoUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _level;
    [SerializeField] private EndLevel _endLevelTimeChange;
    [SerializeField] private HedgehogBoss _boss;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerDig _playerDig;

    private void Start()
    {
        string temp = _level.text;
        _playerDig.enabled = false;
        _playerMovement.enabled = false;


        if (_endLevelTimeChange != null)
            _endLevelTimeChange.ChangeRunTime();

        _level.text = temp + SceneManager.GetActiveScene().buildIndex;
    }

    public void ClosePanel()
    {
        if (_endLevelTimeChange != null)
            _endLevelTimeChange.ChangeRunTime();

        if (_boss != null)
            _boss.enabled = true;

        _playerDig.enabled = true;
        _playerMovement.enabled = true;
    }
}
