using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HedgehogBoss : EnemyHedgehog
{
    [SerializeField] private PlayerStats _stats;
    [SerializeField] private PlayerWallet _wallet;

    private int _layerBoss = 11;

    protected override void Start()
    {
        base.Start();
        Debug.Log("Boss");
        IsBoss = true;
        _stats.InitHedgehog(this);
        WakeUp(_wallet, _stats);
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerHealth player))
            player.TakeDamage();

        base.OnTriggerEnter(other);
    }

    protected override void WakeUp(PlayerWallet player, PlayerStats playerStats)
    {
        Debug.Log("1 авы");
        base.WakeUp(player, playerStats);
        gameObject.layer = _layerBoss;
    }

}
