using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyController : MonoBehaviour
{
    public static MoneyController instance;

    [SerializeField] TextMeshProUGUI text;

    int currentMoney;

    private void Awake()
    {
        instance = this;
        text.text = currentMoney.ToString();
    }

    public void AddMoney(int money)
    {
        currentMoney += money;
        text.text = currentMoney.ToString();
    }
}
