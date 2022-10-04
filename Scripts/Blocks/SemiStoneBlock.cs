using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemiStoneBlock : Block
{
    [SerializeField] private GameObject _semiDestroing;

    private int _rotationX = -90;
    private int _rotationY = 90;
    private int _rotationZ = 45;

    protected override void Destroing()
    {
        GameObject block =  Instantiate(_semiDestroing, transform.position, Quaternion.Euler(_rotationX, _rotationY, _rotationZ));
        block.TryGetComponent(out Block collision);
        collision.Init(Health,Animator, EndLevelTrigger);
        Destroy(gameObject);
    }
}
