                   using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HedgehogMovement : MonoBehaviour
{
    [SerializeField] private int _speed;
    [SerializeField] private GameObject _hedgehogSphere;

    private Vector3 _moveDirection;
    private Vector3 _vectorRotate = new Vector3(0, 0, -720);
    private Vector3 _currentEulerAngles;
    private int _minDirection = 90;
    private int _maxDirection = 270;

    private void Start()
    {
        _moveDirection = new Vector3(1 * _speed, 0, 0);
        float startRotationY = -90;
        float rotationY = transform.rotation.y;
        Vector3 rotation = new Vector3(transform.rotation.x, rotationY += startRotationY, transform.rotation.z);
        transform.Rotate(rotation);
    }

    private void Update()
    {
        Movement();
        Spin();
    }

    public void RandomChangeDirection()
    {
        float random = Random.Range(_minDirection, _maxDirection);
        float rotationY = transform.rotation.y;
        Vector3 rotation = new Vector3(transform.rotation.x, rotationY += random, transform.rotation.z);
        transform.Rotate(rotation);
    }

    private void Spin()
    {
        _currentEulerAngles += _vectorRotate * Time.deltaTime;
        _hedgehogSphere.transform.localEulerAngles = _currentEulerAngles;
    }

    private void Movement()
    {
        transform.Translate(_moveDirection * Time.deltaTime, Space.Self);
    }    
}
