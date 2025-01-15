using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowMoney : MonoBehaviour
{
    private int money;

    public TextMeshProUGUI moneyText;

    void Update()
    {
        money = PlayerPrefs.GetInt("Money", 0);
        moneyText.text = money.ToString();
    }
}
