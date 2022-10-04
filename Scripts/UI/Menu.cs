using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Menu : MonoBehaviour
{
    [SerializeField] private Animator _fade;
    [SerializeField] private SettingsUI _settingsUI;

    private int _scene = 0;

    public void StartGame()
    {
        string level = "LevelComplete";

        if (PlayerPrefs.HasKey(level))
        {
            Debug.Log("lolNot");
            _scene = PlayerPrefs.GetInt(level);
        }
        else
        {
            Debug.Log("lol");
            _scene = 1;
        }

        Fade(); 
    }

    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
    }

    public void ClosePanel(GameObject panel)
    {
        string off = "Off";

        panel.TryGetComponent<Animator>(out Animator panelAnim);
        panelAnim.SetTrigger(off);
        StartCoroutine(PanelOff(panel));
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void AppointScene(int scene)
    {
        _scene = scene;
        Fade();
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(_scene);
    }

    private void Fade()
    {
        _settingsUI.SoundFading();
        string fade = "Fade";
        _fade.SetTrigger(fade);
    }

    private IEnumerator PanelOff(GameObject panel)
    {
        float expiredTime = 0.4f;

        while (expiredTime > 0)
        {
            expiredTime -= Time.deltaTime;
            yield return null;
        }

        panel.SetActive(false);
    }
}
