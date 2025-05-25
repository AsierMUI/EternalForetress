using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{
    public Text moneyText;


    private void Start()
    {
        UpdateMoneyUI();
    }
    // Update is called once per frame
    void Update()
    {
        UpdateMoneyUI();
    }

    void UpdateMoneyUI()
    {
        moneyText.text = PlayerStats.Money.ToString() + "€";
    }


}
