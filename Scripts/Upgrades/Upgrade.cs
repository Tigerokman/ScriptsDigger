using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Upgrade : MonoBehaviour
{
    [SerializeField] private string _label;
    [SerializeField] private int _startPrice;
    [SerializeField] private Sprite _icon;
    [SerializeField] private float _upgradeValue;
    [SerializeField] private int _buyPriceDecrease;

    private PlayerStats _playerStats;
    private int _currentPrice;
    private int _leftCount;

    public int LeftCount => _leftCount;
    public string Label => _label;
    public int Price => _currentPrice;
    public int Level { get; private set; } = 0;
    public Sprite Icon => _icon;
    public float UpgradeValue => _upgradeValue;

    private void OnDisable()
    {
        _playerStats.LevelUp -= LevelUp;
    }

    public void SaveLeftCount(int count)
    {
        _leftCount = count;
    }

    public void Init(PlayerStats playerStats)
    {
        _playerStats = playerStats;
        _playerStats.LevelUp += LevelUp;
        Level = 1;
        _currentPrice = _startPrice;
    }

    public void PriceDecrease()
    {
        _currentPrice += _buyPriceDecrease;
    }

    private void LevelUp(int level)
    {
        Level = level;
    }
}