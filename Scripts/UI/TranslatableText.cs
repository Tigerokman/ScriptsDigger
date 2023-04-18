using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TranslatableText : MonoBehaviour
{
    [SerializeField] private int _textID;
    [SerializeField] private bool _isClassic;

    public int TextID => _textID;
    public bool IsClassic => _isClassic;

    [HideInInspector] public TextMeshProUGUI UIText;

    private void Awake()
    {
        UIText = GetComponent<TextMeshProUGUI>();
        Translator.AddText(this);
    }

    private void OnEnable()
    {
        Translator.UpdateText(); 
    }

    private void OnDestroy()
    {
        Translator.Delete(this);
    }
}
