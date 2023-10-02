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
        //Debugのため（currentEnergyを左クリックで表示）
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log(currentEnergy);
        }

        //物体移動
        if(Input.GetKeyDown(KeyCode.E))
        {
            currentEnergy -= 20;
            Debug.Log(currentEnergy);
            energyIncreaseTimer = energyIncreaseDelay;
        }

        //重力増強
        if(Input.GetKeyDown(KeyCode.F))
        {
            currentEnergy -= 30;
            Debug.Log(currentEnergy);
            energyIncreaseTimer = energyIncreaseDelay;
        }

        //重力反転
        if(Input.GetKeyDown(KeyCode.G))
        {
            currentEnergy -= 50;
            Debug.Log(currentEnergy);
            energyIncreaseTimer = energyIncreaseDelay;
        }

        if (energyIncreaseTimer > 0)
        {
            energyIncreaseTimer -= Time.deltaTime;
            if (energyIncreaseTimer <= 0)
            {
                currentEnergy += energyIncreaseRate * Time.deltaTime;
                if (currentEnergy >= maxEnergy)
                {
                    currentEnergy = maxEnergy;
                }
            }
        }

    }
}