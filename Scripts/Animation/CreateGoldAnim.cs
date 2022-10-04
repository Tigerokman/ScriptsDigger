using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGoldAnim : MonoBehaviour
{
    [SerializeField] private int _countGoldAnim;
    [SerializeField] private float _durationCreateGold;
    [SerializeField] private Transform _target;
    [SerializeField] private GoldAnimation _animatedGold;


    public void AnimationOn()
    {
        StartCoroutine(CreateGoldAnimOn());
    }

    private IEnumerator CreateGoldAnimOn()
    {
        int createdInFrame = 0;
        int countInFrame = 4;

        for (int i = 0; i < _countGoldAnim; i++)
        {
            GoldAnimation coin = Instantiate(_animatedGold);
            coin.Init(_target, transform.position);

            if(createdInFrame != countInFrame)
            {
                createdInFrame++;
            }
            else
            {
                createdInFrame = 0;
                float waiting = _durationCreateGold / _countGoldAnim;
                yield return new WaitForSeconds(waiting);
            }    
        }
    }
}
