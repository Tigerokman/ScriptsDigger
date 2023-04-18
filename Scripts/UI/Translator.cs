using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Translator : MonoBehaviour
{
    private static int _languageId;
    private static List<TranslatableText> _listID = new List<TranslatableText> ();

    private static string[,] LineText =
    {
        // "", //

        #region Английский
        {
            "Start", // 0
            "Levels", // 1
            "Settings", // 2
            "Rate the game", // 3
            "reset", // 4
            "NO", // 5
            "YES", // 6
            "RESET?", // 7
            "SETTINGS", // 8
            "graphics quality", // 9
            "sound", // 10
            "volume", // 11 
            "Level ", // 12
            "Destroy\n\n\n\nyou see:)", // 13
            "EVERITHING!!!", // 14
            "UPGRADES", // 15
            "Main menu", // 16
            "Next level", // 17
            "Restart", // 18
            "Exit", // 19
            "Defeat!", // 20
            "Victory!", // 21
            "Also destroy\n\n\n\nIf you can...", // 22
            "If you won't wipe the stars every night, they're bound to dim.", // 23
            "STAR    STAR    STAR        STAR    STAR      STAR    STAR       STAR      STAR    STAR", // 24
            "Sold Out", // 25
            " Available", // 26
            "Hedgehog Power-Up", // 27
            "Pickaxe Power", // 28
            "Pickaxe Range", // 29
            "Let's see what\n you learned.", // 30
            "Way", // 31
            "Find a", // 32
            "Your              - your friend.", // 33
            "ENEMY", // 34
            "TIME", // 35
            "                and tide wait for no man.", // 36
            "It's a Bird...\nIt's a Plane...\nIt's a", // 37
            "HEDGEHOG!!!", // 38
            "Believe in yourself!\nYou will succeed!", // 39
            "Support", // 40
            "You are rated." // 41
        },
        #endregion

        #region Русский
        {
            "Старт", // 0
            "Уровни", // 1
            "Настройки", // 2
            "Оцени игру", // 3
            "сброс", // 4
            "НЕТ", // 5
            "ДА", // 6
            "СБРОС?", // 7
            "НАСТРОЙКИ", // 8
            "графика", // 9
            "звук", // 10
            "громкость", // 11
            "Уровень ", // 12
            "Уничтожь\n\n\n\nчто видишь:)", // 13
            "   ВСЁ!!!", // 14
            "УЛУЧШЕНИЯ", // 15
            "Меню", // 16
            "Новый уровень", // 17
            "Рестарт", // 18
            "Выход", // 19
            "Поражение!", // 20
            "Победа!", // 21
            "Тоже уничтожь\n\n\n\nЕсли сможешь...", // 22
            "Если ты не будешь протирать звезды каждый вечер, они потускнеют.", // 23
            "ЗВЕЗДА   ЗВЕЗДА   ЗВЕЗДА   ЗВЕЗДА    ЗВЕЗДА   ЗВЕЗДА   ЗВЕЗДА   ЗВЕЗДА ", // 24
            "Продано", // 25
            " Доступно", // 26
            "Ёж - Cила", // 27
            "Кирка - Cила", // 28
            "Кирка - Радиус", // 29
            "Давай посмотрим\nчему\nты научился.", // 30
            "Путь", // 31
            "Найди", // 32
            "Твой             - твой друг.", // 33
            "ВРАГ", // 34
            "ВРЕМЯ", // 35
            "                 и прилив никого не ждут.", // 36
            "Это птица...\nЭто самолет...\nЭто", // 37
            "ЁЖ!!!", // 38      
            "Верь в себя!\nУ тебя все получится!", // 39
            "Поддержка", // 40
            "Вы оценили." // 41

        },
        #endregion
    };

    static public void SelectLanguage(int id)
    {
        _languageId = id;
        UpdateText();
    }

    static public string GetText(int textKey)
    {
        return LineText[_languageId, textKey];
    }

    static public void AddText(TranslatableText idText)
    {
        _listID.Add(idText);
    }

    static public void Delete(TranslatableText idText)
    {
        _listID.Remove(idText);
    }

    static public void UpdateText()
    {
        string language = "Language";
        string EN = "EN_Language";
        string RU = "RU_Language";
        string Classic = "Classic_Language";

        for (int i = 0; i < _listID.Count; i++)
        {
            _listID[i].UIText.text = LineText[_languageId, _listID[i].TextID];
            if (PlayerPrefs.GetInt(language) == 1)
            {
                if (_listID[i].IsClassic == false)
                    _listID[i].UIText.font = Resources.Load<TMP_FontAsset>(RU);
                else
                    _listID[i].UIText.font = Resources.Load<TMP_FontAsset>(Classic);
            }
            else
            {
                if (_listID[i].IsClassic == false)
                    _listID[i].UIText.font = Resources.Load<TMP_FontAsset>(EN);
                else
                    _listID[i].UIText.font = Resources.Load<TMP_FontAsset>(Classic);
            }
        }
    }
}
