using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHedgehog : Hedgehog
{
    [SerializeField] private EndLevelBlocks _endLevelBlocks;

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Block block))
            _endLevelBlocks.EnemyDestroyBlock();
        
        base.OnTriggerEnter(other);
    }
}
