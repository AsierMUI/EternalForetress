using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 400;


    public static int Lives;
    public int startLives = 10;
    void Start()
    {
        Money = startMoney;
        Lives = startLives;
    }

    public static void AddMoney(int amount)
    {
        Money += amount;
        Debug.Log("Dinero actual:" + Money);
    }


}
