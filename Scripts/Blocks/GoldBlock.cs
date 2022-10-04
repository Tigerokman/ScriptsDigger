using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class GoldBlock : Block
{
    [SerializeField] private int _bounty;
    [SerializeField] private CreateGoldAnim _createGoldAnim;

    public int Bounty => _bounty;

    protected override void OnParticle()
    {
        _createGoldAnim.AnimationOn();
    }
}
