using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UpgradeView : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private TMP_Text _level;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _upgradeButton;
    [SerializeField] private GameObject _silverButton;
    [SerializeField] private GameObject _charactersUpgrade;
    [SerializeField] private GameObject _buttonParticle;
    [SerializeField] private GameObject _silverButtonChildImage;

    private Upgrade _upgrade;
    private PlayerWallet _wallet;

    public event UnityAction<Upgrade, UpgradeView> UpgradeButtonClick;

    private void OnEnable()
    {
        _upgradeButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _upgradeButton.onClick.RemoveListener(OnButtonClick);
    }

    public void Render(Upgrade upgrade, PlayerStats player, PlayerWallet wallet)
    {
        _wallet = wallet;
        _wallet.GoldAdded += UpgradeViewCanBuy;
        _upgrade = upgrade;
        _label.text = upgrade.Label;
        _icon.sprite = upgrade.Icon;
        UpdateViewPrice(upgrade, player);
    }

    public void UpdateViewPrice(Upgrade upgrade, PlayerStats player)
    {
        if (upgrade == player.UpgradeHedgehog)
            _level.text = player.CountHedgehogUpgrade.ToString() + " Available";
        else
            _level.text = "Level " + upgrade.Level.ToString();

        _price.text = upgrade.Price.ToString();
    }

    public void UpgradeViewCanBuy()
    {
        if (_silverButton.activeInHierarchy == false && _wallet.Gold < _upgrade.Price)
        {
            _silverButton.SetActive(true);
        }

        if(_silverButton.activeInHierarchy == true && _wallet.Gold >= _upgrade.Price && _upgrade.LeftCount != 0)
            _silverButton.SetActive(false);

        if (_upgrade.LeftCount == 0)
        {
            _silverButton.SetActive(true);
            _wallet.GoldAdded -= UpgradeViewCanBuy;
            Destroy(_silverButtonChildImage);
            Destroy(_charactersUpgrade);
        }

        Debug.Log(_upgrade.LeftCount);
    }

    public void AnimationButtonOn()
    {
        if (_buttonParticle.activeInHierarchy)
            _buttonParticle.SetActive(false);

        Vector3 animationScaleDegree = new Vector3(0.05f, 0.05f, 0.05f);
        this.transform.localScale += animationScaleDegree;
        _buttonParticle.SetActive(true);
        _buttonParticle.TryGetComponent<ParticleSystem>(out ParticleSystem particle);
        particle.Play();

        StartCoroutine(IsAnimationScale());
    }

    private void OnButtonClick()
    {
        UpgradeButtonClick?.Invoke(_upgrade, this);
    }

    private IEnumerator IsAnimationScale()
    {
        float waiting = 0.1f;

        while (waiting > 0)
        {
            waiting -= Time.unscaledDeltaTime;
            yield return null;
        }

        this.transform.localScale = new Vector3(1f, 1f, 1f);
    }
}
