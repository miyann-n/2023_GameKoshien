using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Energy : MonoBehaviour
{
    public int maxEnergy = 100; //最大のエネルギー
    public float currentEnergy; //現在のエネルギー
    private float energyIncreaseDelay = 3f; // エネルギー増加の遅延時間
    private float energyIncreaseRate = 20f; // エネルギー増加の速度
    private float energyIncreaseTimer = 0f; // エネルギー増加のタイマー

    void Start()
    {
        currentEnergy = maxEnergy;   
    }
    void Update()
    {
        //物体移動
        if(Input.GetKeyDown(KeyCode.E) && currentEnergy >= 20)
        {
            currentEnergy -= 20;
            energyIncreaseTimer = energyIncreaseDelay;
        }

        //重力増強
        if(Input.GetKeyDown(KeyCode.F) && currentEnergy >= 30)
        {
            currentEnergy -= 30;
            energyIncreaseTimer = energyIncreaseDelay;

        }

        //重力反転
        if(Input.GetKeyDown(KeyCode.G) && currentEnergy >= 50)
        {
            currentEnergy -= 50;
            energyIncreaseTimer = energyIncreaseDelay;

        }

        // エネルギー増加のタイマーが0より大きい場合、タイマーを減らす
        if (energyIncreaseTimer > 0)
        {
            energyIncreaseTimer -= Time.deltaTime;
        }
        // エネルギー増加のタイマーが0以下の場合、currentEnergyを20ずつ増加する
        else
        {
            currentEnergy += energyIncreaseRate * Time.deltaTime;
            if (currentEnergy >= maxEnergy)
            {
                currentEnergy = maxEnergy;
            }
        }
    }
}