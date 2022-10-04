using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    [SerializeField] private float _lifeTime;

    public virtual void Init()
    {
        Destroy(gameObject,_lifeTime);
    }
}
