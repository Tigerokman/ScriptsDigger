using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class AnalycicsComponent : MonoBehaviour
{
    private string _level = "Level";

    public void OnPlayerDead(int levelID)
    {
        string playerDead = "PlayerDead";

        Analytics.CustomEvent(playerDead, new Dictionary<string,object>()
        {
            { _level, levelID},
        });
    }

    public void RestartLevelAnalytics(int levelID, bool isLose)
    {
        string restartLevel = "RestartLevel";
        string isLoseString = "Lose?";

        Analytics.CustomEvent(restartLevel, new Dictionary<string, object>()
        {
            { _level, levelID},
            { isLoseString, isLose}
        });
    }

    public void LikeGame(int rate)
    {
        string likeGame = "LikeGame";
        string rateString = "Rate";
        string isRated = "IsRated";

        if (PlayerPrefs.GetInt(isRated) != 1)
        {
            Analytics.CustomEvent(likeGame, new Dictionary<string, object>()
            {
               { rateString, rate}
            });
            PlayerPrefs.SetInt(isRated, 1);
            Debug.Log("Оценил");
        }
        else
        {
            Debug.Log("Вы уже оценивали игру");
        }
    }
}
