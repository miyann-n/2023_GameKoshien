using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Energy : MonoBehaviour
{
    public int maxEnergy = 100;
    public float currentEnergy;

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

        //エナジーの管理
        HandleEnergy();
    }

    void HandleEnergy(){
        //物体移動
        if(Input.GetKeyDown(KeyCode.E))
        {
            currentEnergy -= 20;
            Invoke("RecoverEnergy", 3f);
            Debug.Log(currentEnergy);
        }

        //重力増強
        if(Input.GetKeyDown(KeyCode.F))
        {
            currentEnergy -= 30;
            Invoke("RecoverEnergy", 3f);
            Debug.Log(currentEnergy);
        }

        //重力反転
        if(Input.GetKeyDown(KeyCode.G))
        {
            currentEnergy -= 50;
            Invoke("RecoverEnergy", 3f);
            Debug.Log(currentEnergy);
        }

    }

    void RecoverEnergy()
    {
        currentEnergy += 20;
    }



}
