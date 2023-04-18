using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RateTheGameScript : MonoBehaviour
{
    [SerializeField] private GameObject _ratings;
    [SerializeField] private GameObject _textRated;

    private void OnEnable()
    {
        string isRated = "IsRated";

        if (PlayerPrefs.GetInt(isRated) == 1)
        {
            _ratings.SetActive(false);
            _textRated.SetActive(true);
        }

    }
}
