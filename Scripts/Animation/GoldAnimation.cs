using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class GoldAnimation : MonoBehaviour
{
    [SerializeField][Range(0.5f, 0.9f)] private float _minAnimDuration;
    [SerializeField][Range(0.9f, 2f)] private float _maxAnimDuration;
    [SerializeField] private Ease _easeType;
    [SerializeField] private float _spreadX;
    [SerializeField] private float _spreadZ;
    [SerializeField] private float _spreadY;

    private Transform _target;
    private Vector3 _targetLastPosition;
    private Tweener _tweener;
    private float _timeLife;

    public void Init(Transform target,Vector3 position)
    {
        transform.position = position + new Vector3(Random.Range(-_spreadX, _spreadX), Random.Range(-_spreadY, _spreadY), Random.Range(-_spreadZ, _spreadZ));
        float duration = Random.Range(_minAnimDuration, _maxAnimDuration);
        _target = target;
        _targetLastPosition = _target.position;
        _tweener = transform.DOMove(_target.position, duration)
         .SetEase(_easeType);
        _timeLife = duration;
        Destroy();
    }

    private void Update()
    {
        _timeLife -= Time.deltaTime;

        if (_targetLastPosition != _target.position)
        {
            _tweener.ChangeEndValue(_target.position, _timeLife, true);
            _targetLastPosition = _target.position;
        }
    }

    private void Destroy()
    {
        Destroy(gameObject,_timeLife + -0.015f);
    }
}
