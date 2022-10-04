using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class LevelView : MonoBehaviour
{
    [SerializeField] private Button _levelButton;
    [SerializeField] private TMP_Text _levelText;
    [SerializeField] private Sprite _notActiveImage;
    [SerializeField] private Sprite _activeImage;

    private int _level;

    public event UnityAction<int> LevelButtonClick;


    private void OnEnable()
    {
        _levelButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _levelButton.onClick.RemoveListener(OnButtonClick);
    }

    public void Render(int level)
    {
        _level = level;
        _levelText.text = level.ToString();
    }

    public void RenderActive(bool active)
    {
        if(active)
        {
            _levelButton.image.sprite = _activeImage;
        }
        else
        {
            _levelButton.image.sprite = _notActiveImage;
        }
    }

    private void OnButtonClick()
    {
        LevelButtonClick?.Invoke(_level);
    }
}
