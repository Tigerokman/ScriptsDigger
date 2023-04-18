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

        #region ����������
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

        #region �������
        {
            "�����", // 0
            "������", // 1
            "���������", // 2
            "����� ����", // 3
            "�����", // 4
            "���", // 5
            "��", // 6
            "�����?", // 7
            "���������", // 8
            "�������", // 9
            "����", // 10
            "���������", // 11
            "������� ", // 12
            "��������\n\n\n\n��� ������:)", // 13
            "   �Ѩ!!!", // 14
            "���������", // 15
            "����", // 16
            "����� �������", // 17
            "�������", // 18
            "�����", // 19
            "���������!", // 20
            "������!", // 21
            "���� ��������\n\n\n\n���� �������...", // 22
            "���� �� �� ������ ��������� ������ ������ �����, ��� ����������.", // 23
            "������   ������   ������   ������    ������   ������   ������   ������ ", // 24
            "�������", // 25
            " ��������", // 26
            "�� - C���", // 27
            "����� - C���", // 28
            "����� - ������", // 29
            "����� ���������\n����\n�� ��������.", // 30
            "����", // 31
            "�����", // 32
            "����             - ���� ����.", // 33
            "����", // 34
            "�����", // 35
            "                 � ������ ������ �� ����.", // 36
            "��� �����...\n��� �������...\n���", // 37
            "��!!!", // 38      
            "���� � ����!\n� ���� ��� ���������!", // 39
            "���������", // 40
            "�� �������." // 41

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
