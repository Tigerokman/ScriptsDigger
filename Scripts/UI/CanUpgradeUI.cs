using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanUpgradeUI : MonoBehaviour
{
    [SerializeField] private PlayerWallet _wallet;
    [SerializeField] private GameObject _canBuyImage;
    [SerializeField] private UpgradePanel _upgradePanel;

    private int _cantBuyCount = 0;

    private void OnEnable()
    {
        _wallet.GoldAdded += CanBuy;
    }

    private void OnDisable()
    {
        _wallet.GoldAdded -= CanBuy;
    }

    public void CanBuy()
    {
        if (_canBuyImage.activeInHierarchy == false)
        {
            for (int i = 0; i < _upgradePanel.Upgrades.Count; i++)
            {
                if (_upgradePanel.Upgrades[i].Price <= _wallet.Gold)
                    _canBuyImage.SetActive(true);

            }
        }

        if (_canBuyImage.activeInHierarchy == true)
        {

            for (int i = 0; i < _upgradePanel.Upgrades.Count; i++)
            {
                if (_upgradePanel.Upgrades[i].Price > _wallet.Gold)
                    _cantBuyCount++;
            }

            _canBuyImage.SetActive(_upgradePanel.Upgrades.Count != _cantBuyCount);

            _cantBuyCount = 0;
        }
    }
}
