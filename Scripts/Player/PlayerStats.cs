using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private UpgradeHedgehog _upgradeHedgehog;
    [SerializeField] private UpgradePower _upgradePower;
    [SerializeField] private UpgradeRange _upgradeRange;
    [SerializeField] private PickAxe _pickAxe;

    private int _countPowerUpgrade = 10;
    private int _countRangeUpgrade = 10;
    private int _hedgehogCount = 0;

    public UpgradeHedgehog UpgradeHedgehog => _upgradeHedgehog;
    public int CountHedgehogUpgrade { get; private set; } = 3;
    public int PowerUpgradeLevel { get; private set; } = 1;
    public int RangeUpgradeLevel { get; private set; } = 1;
    public float Damage { get; private set; } = 1;
    public float HedgehodAttack { get; private set; } = 1;
    public int HedgehogCount => _hedgehogCount;



    public event UnityAction HedgehogAttackUp;
    public event UnityAction<int> LevelUp;
    public event UnityAction<float> RangeUp;
    public event UnityAction HedgehogCountChanged;

    public void InitHedgehog(Hedgehog hedgehog)
    {
        hedgehog.HedgehogCountChange += HedgehogCountChange;
    }

    public int Upgrade(Upgrade upgrade)
    {
        int template = 0;
        int templateLevel = 0;

        if (upgrade == _upgradePower)
        {
            template = PowerUpgrade();
            templateLevel = PowerUpgradeLevel;
        }
        else if (upgrade == _upgradeRange)
        {
            template = UpgradeRange();
            templateLevel = RangeUpgradeLevel;
        }
        else if (upgrade == _upgradeHedgehog)
        {
            template = HedgehogUp();
            templateLevel = CountHedgehogUpgrade;
        }

        LevelUp?.Invoke(templateLevel);
        return template;
    }

    private int PowerUpgrade()
    {
        int template = 0;

        Damage += _upgradePower.UpgradeValue;
        _countPowerUpgrade--;
        PowerUpgradeLevel++;
        template = _countPowerUpgrade;

        return template;
    }

    private int UpgradeRange()
    {
        int template = 0;

        _countRangeUpgrade--;
        RangeUpgradeLevel++;
        RangeUp?.Invoke(_upgradeRange.UpgradeValue);
        template = _countRangeUpgrade;

        return template;
    }

    private int HedgehogUp()
    {
        int template = 0;

        HedgehodAttack += _upgradeHedgehog.UpgradeValue;
        CountHedgehogUpgrade--;
        HedgehogAttackUp?.Invoke();
        template = CountHedgehogUpgrade;

        return template;
    }

    private void HedgehogCountChange(int count, Hedgehog hedgehog)
    {
        _hedgehogCount += count;
        HedgehogCountChanged?.Invoke();
        if (count == -1)
            hedgehog.HedgehogCountChange -= HedgehogCountChange;
    }
}
