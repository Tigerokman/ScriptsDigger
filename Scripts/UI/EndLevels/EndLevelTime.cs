using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndLevelTime : EndLevelBlocks
{
    [SerializeField] private float _timeToEnd;
    [SerializeField] private TMP_Text _textTime;

    private int _currentTime;

    protected override void Start()
    {
        _currentTime = (int)_timeToEnd;
        _textTime.text = _currentTime.ToString();

        base.Start();
    }

    private void Update()
    {
        if (_timeToEnd > 0 && IsRunTime == true)
        {
            _timeToEnd -= Time.deltaTime;
            _currentTime = (int)_timeToEnd;
            _textTime.text = (_currentTime + 1).ToString();

            if (_timeToEnd <= 0)
            {
                _textTime.text = 0.ToString();
                Lose();
            }
        }
    }
}
