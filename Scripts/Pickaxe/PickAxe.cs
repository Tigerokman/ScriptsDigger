using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class PickAxe : MonoBehaviour
{
    [SerializeField] private PlayerStats _playerStats;
    [SerializeField] private PlayerWallet _playerWallet;
    [SerializeField] private ParticleSystem _skillParticle;

    private BoxCollider _boxCollider;
    private float _skillRadius = 1.2f;

    private float _attack => _playerStats.Damage;

    private void Awake()
    {
        _boxCollider = GetComponent<BoxCollider>();
    }

    private void OnEnable()
    {
        _playerStats.RangeUp += RangeUp;
    }

    private void OnDisable()
    {
        _playerStats.RangeUp -= RangeUp;
    }

    private void OnTriggerEnter(Collider collision)
    {
        DamageBlock(collision);
    }

    public void LastAttackDamage()
    {
        Collider[] blocks = Physics.OverlapSphere(_skillParticle.transform.position, _skillRadius);

        for (int i = 0; i < blocks.Length; i++)
        {
            DamageBlock(blocks[i]);
        }

        _skillParticle.Play();
    }

    public void OnAttack(bool isAttack)
    {
        _boxCollider.enabled = isAttack;
    }

    private void RangeUp(float upgrade)
    {
        _skillRadius += upgrade;
    }

    private void DamageBlock(Collider collision)
    {
        if (collision.TryGetComponent(out Block block))
        {
            block.TakeDamage(_attack);

            if (collision.TryGetComponent(out GoldBlock goldBlock))
                _playerWallet.GetGold(goldBlock.Bounty);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_skillParticle.transform.position, _skillRadius);
    }
}
