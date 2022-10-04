using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HedgehogParticles : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleMove;
    [SerializeField] private ParticleSystem _particleSleep;
    [SerializeField] private ParticleSystem _particleWakeUp;
    [SerializeField] private ParticleSystem _particleStun;

    private void MoveParticles()
    {
        _particleMove.Play();
    }

    private void WakeUpParticles()
    {
        Destroy(_particleSleep);
        _particleWakeUp.Play();
    }

    private void StunParticles()
    {
        Destroy(_particleMove);
        _particleStun.Play();
    }
}
