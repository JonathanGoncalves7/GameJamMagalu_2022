using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text moneyText;

    private void OnEnable()
    {
        GameManager.OnChangeMoney += UpdateMoneyText;
    }

    private void OnDisable()
    {
        GameManager.OnChangeMoney -= UpdateMoneyText;
    }

    private void UpdateMoneyText(int value)
    {
        moneyText.text = value.ToString("000000");
    }
}
