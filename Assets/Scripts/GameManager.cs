using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager s_instance;

    [Header("Money")]
    public int startMoney = 1000;
    public int currentMoney;

    public static event Action<int> OnChangeMoney;
    public static event Action<int> OnIncMoney;
    public static event Action<int> OnDecMoney;

    private void Awake()
    {
        s_instance = this;
    }

    private void Start()
    {
        SetMoney(startMoney);
    }

    private void SetMoney(int value)
    {
        currentMoney = value;

        if (OnChangeMoney != null)
            OnChangeMoney(currentMoney);
    }

    public void IncMoney(int value)
    {
        currentMoney += value;

        if (OnChangeMoney != null)
            OnChangeMoney(currentMoney);

        if (OnChangeMoney != null)
            OnIncMoney(value);
    }

    public void DecMoney(int value)
    {
        currentMoney -= value;

        if (OnChangeMoney != null)
            OnChangeMoney(currentMoney);

        if (OnDecMoney != null)
            OnDecMoney(value);
    }
}
