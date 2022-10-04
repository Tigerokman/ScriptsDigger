using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class UpgradePanel : MonoBehaviour
{
    [SerializeField] private List<Upgrade> _upgrades;
    [SerializeField] private PlayerStats _playerStats;
    [SerializeField] private UpgradeView _template;
    [SerializeField] private GameObject _upgradeContainer;
    [SerializeField] private PlayerWallet _wallet;
    [SerializeField] private CanUpgradeUI _canUpgradeIU;

    private List<UpgradeView> _upgradeViews = new List<UpgradeView>();
    private Animator _animator;

    public List<Upgrade> Upgrades => _upgrades;


    private void Awake()
    {
        _animator = GetComponent<Animator>();

        for (int i = 0; i < _upgrades.Count; i++)
        {
            _upgrades[i].Init(_playerStats);
            AddUpgrade(_upgrades[i]);
            _upgrades[i].SaveLeftCount(1);
        }
    }

    private void OnEnable()
    {
        for (int i = 0; i < _upgradeViews.Count; i++)
            _upgradeViews[i].UpgradeViewCanBuy();
    }

    private void AddUpgrade(Upgrade upgrade)
    {
        var view = Instantiate(_template, _upgradeContainer.transform);
        view.UpgradeButtonClick += OnSellUpgradeButtonClick;
        view.Render(upgrade, _playerStats, _wallet);
        _upgradeViews.Add(view);
    }

    private void OnSellUpgradeButtonClick(Upgrade upgrade, UpgradeView view)
    {
        TrySellUpgrade(upgrade, view);
    }

    private void TrySellUpgrade(Upgrade upgrade, UpgradeView view)
    {
        bool canPay = _wallet.CanPay(upgrade.Price);

        if (canPay)
        {
            int upgradeCount = _playerStats.Upgrade(upgrade);
            upgrade.PriceDecrease();
            upgrade.SaveLeftCount(upgradeCount);
            view.UpdateViewPrice(upgrade,_playerStats);
            view.AnimationButtonOn();

            for (int i = 0; i < _upgradeViews.Count; i++)
                _upgradeViews[i].UpgradeViewCanBuy();

            if (upgradeCount == 0)
            {
                _upgrades.Remove(upgrade);
                view.UpgradeButtonClick -= OnSellUpgradeButtonClick;
            }

            _canUpgradeIU.CanBuy();
        }
    }
}
