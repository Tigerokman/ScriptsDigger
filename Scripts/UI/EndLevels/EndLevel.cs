using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AnalycicsComponent))]
public class EndLevel : MonoBehaviour
{
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private Menu _menu;
    [SerializeField] private AudioSource _win;
    [SerializeField] private AudioSource _lose;
    [SerializeField] private SettingsUI _settingsUI;

    private bool _isRunTime = true;

    protected AnalycicsComponent AnalycicsComponent;
    public bool IsRunTime => _isRunTime;

    private void Awake()
    {
        AnalycicsComponent = GetComponent<AnalycicsComponent>();
    }

    public virtual void EndLevelTrigger()
    {
        ChangeRunTime();
        string level = "LevelComplete";
        _winPanel.SetActive(true);
        _settingsUI.EndSounds(_win);
        PlayerPrefs.SetInt(level, SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Fade(string load)
    {
        string restartWin = "RestartWin";
        string restartLose = "RestartLose";
        string nextLevel = "NextLevel";
        string mainMenu = "MainMenu";

        if (load == restartWin)
        {
            bool isLose = false;
            AnalycicsComponent.RestartLevelAnalytics(SceneManager.GetActiveScene().buildIndex, isLose);
            Debug.Log("ЗаписалВин");
            _menu.AppointScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (load == restartLose)
        {
            bool isLose = true;
            AnalycicsComponent.RestartLevelAnalytics(SceneManager.GetActiveScene().buildIndex, isLose);
            Debug.Log("ЗаписалЛуз");
            _menu.AppointScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (load == nextLevel)
        {
            _menu.AppointScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (load == mainMenu)
        {
            _menu.AppointScene(0);
        }
    }

    public void ChangeRunTime()
    {
        _isRunTime = !_isRunTime;
    }

    protected void LoseSound()
    {
        _settingsUI.EndSounds(_lose);
    }

    private void FadeComplete()
    {
        _menu.LoadLevel();
    }
}
