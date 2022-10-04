using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MoneyBalance : MonoBehaviour
{
    [SerializeField] private TMP_Text _money;
    [SerializeField] private PlayerWallet _wallet;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _wallet.GoldChanged += MoneyViewChange;
        _money.text = _wallet.Gold.ToString();
    }

    private void OnDisable()
    {
        _wallet.GoldChanged -= MoneyViewChange;
    }

    private void MoneyViewChange()
    {
        string cnahge = "Change";
        _animator.SetTrigger(cnahge);
        _money.text = _wallet.Gold.ToString();
    }
}