using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsMenu : MonoBehaviour
{
    [SerializeField] private int _levelsCount;
    [SerializeField] private LevelView _level;
    [SerializeField] private GameObject _upgradeContainer;
    [SerializeField] private Menu _menu;

    private List<LevelView> _levels = new List<LevelView>();
    private int _currentLevel = 1;
    private int _levelOpened = 1;

    private void Awake()
    {
        string level = "LevelComplete";

        if (PlayerPrefs.HasKey(level))
        _levelOpened = PlayerPrefs.GetInt(level);

        for (int i = 0; i < _levelsCount; i++)
        {
            AddButtonLevel();
            _currentLevel++;
        }
    }

    public void Reset()
    {
        for (int i = 1; i < _levels.Count; i++)
        {
            _levels[i].TryGetComponent<Button>(out Button button);
            _levels[i].LevelButtonClick -= LoadLevel;
            button.interactable = false;
            _levels[i].RenderActive(button.interactable);
        }

        PlayerPrefs.DeleteAll();
    }

    private void AddButtonLevel()
    {
        var view = Instantiate(_level, _upgradeContainer.transform);
        view.LevelButtonClick += LoadLevel;
        view.Render(_currentLevel);
        view.TryGetComponent<Button>(out Button button);

        if(_levelOpened >= _currentLevel)
        {
            button.interactable = true;
            view.RenderActive(button.interactable);
        }
        else
        {
            button.interactable= false;
            view.RenderActive(button.interactable);
        }

        _levels.Add(view);
    }

    private void LoadLevel(int level)
    {
        _menu.AppointScene(level);
    }    
}
