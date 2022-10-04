using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class HedgehogCountUI : MonoBehaviour
{
    [SerializeField] private PlayerStats _playerStats;
    [SerializeField] private TMP_Text _textCount;
    [SerializeField] private GameObject _imageCount;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private int _count => _playerStats.HedgehogCount;

    private void OnEnable()
    {
        _playerStats.HedgehogCountChanged += TextChange;
    }

    private void OnDisable()
    {
        _playerStats.HedgehogCountChanged -= TextChange;
    }

    private void TextChange()
    {
        string change = "Change";
        _animator.SetTrigger(change);

        _imageCount.SetActive(_count > 0);

        _textCount.text = _count.ToString();
    }
}
