using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Player))]
public class PlayerWallet : MonoBehaviour
{
    public int Gold { get; private set; } = 0;

    public event UnityAction GoldChanged;
    public event UnityAction GoldAdded;

    private void Start()
    {
        GoldChanged?.Invoke();
    }


    public void GetGold (int gold)
    {
        Gold += gold;
        GoldChanged?.Invoke();
        GoldAdded?.Invoke();
    }

    public bool CanPay(int price)
    {
        bool canPay = false;

        if (Gold >= price)
        {
            canPay = true;
            Pay(price);
        }

        return canPay;
    }

    private void Pay(int price)
    {
        Gold -= price;
        GoldChanged?.Invoke();
    }
}
