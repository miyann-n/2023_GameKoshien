using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
public class Energy : MonoBehaviour
{

    public float maxEnergy; //最大のエネルギー
    public float currentEnergy; //現在のエネルギー
    public bool isMoveObjectSet; //物体移動のアビリティが選択されているかどうか
    public bool isGravityIncreaseSet; //重力増強のアビリティが選択されているかどうか
    public bool isGravityInversionSet; //重力反転のアビリティが選択されているかどうか

    private float energyIncreaseDelay = 3f; // エネルギー増加の遅延時間
    private float energyIncreaseRate = 20f; // エネルギー増加の速度
    private float energyIncreaseTimer = 0f; // エネルギー増加のタイマー

    private bool isMoveObjectActive; //物体移動のアビリティが起動しているかどうか
    public bool isCheckBigObjectMove; //大障害物を動かせるかどうか


    
    private MaterialMove materialMove;
    private Ability ability;
    private GravityClickCharactor gcCharctor;

    private void Start()
    {   
        ability = GameObject.Find("AvatarHead").GetComponent<Ability>();
        gcCharctor = GameObject.Find("Player").GetComponent<GravityClickCharactor>();
        materialMove = GameObject.Find("Player").GetComponent<MaterialMove>();
        maxEnergy = 100;
        currentEnergy = maxEnergy;
        isMoveObjectSet = false;
        isGravityIncreaseSet = false;
        isGravityInversionSet = false;
        isMoveObjectActive = false;
        isCheckBigObjectMove = false;
    }
    void Update()
    {
        bool isCharactorClicked = gcCharctor.isCharactorClicked; //大障害物をクリックしたかどうか
        /*
        int b = ability.b;  //選択されているアビリティの番号
        
        if(b == 0)
        {
            isMoveObjectSet = true;
            isGravityIncreaseSet = false;
            isGravityInversionSet = false;
        }
        else if(b == 1)
        {
            isMoveObjectSet = false;
            isGravityIncreaseSet = true;
            isGravityInversionSet = false;
        }
        else if(b == 2)
        {
            isMoveObjectSet = false;
            isGravityIncreaseSet = false;
            isGravityInversionSet = true;
        }
        else if(b == 3)
        {
            isMoveObjectSet = false;
            isGravityIncreaseSet = false;
            isGravityInversionSet = false;
        }
        */

        //物体移動
        if(Input.GetKeyDown(KeyCode.E) && isMoveObjectSet && currentEnergy >= 20)
        {
            if(!isMoveObjectActive)
            {
                //currentEnergy -= 20;
                energyIncreaseTimer = energyIncreaseDelay;
            }
            isMoveObjectActive =! isMoveObjectActive;
        }

        //重力増強
        if(gcCharctor.isCharactorClicked && isGravityIncreaseSet && currentEnergy >= 30)
        {
            currentEnergy -= 30;
            energyIncreaseTimer = energyIncreaseDelay;
            gcCharctor.isCharactorClicked = false;
        }

        //重力反転 毎回減る
        if (Input.GetKeyDown(KeyCode.E) && isGravityInversionSet && currentEnergy >= 50)
        {
            //currentEnergy -= 50;
            energyIncreaseTimer = energyIncreaseDelay;
        }

        //エネルギーの回復
        
        if (energyIncreaseTimer > 0)
        {
            energyIncreaseTimer -= Time.deltaTime;
        }
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