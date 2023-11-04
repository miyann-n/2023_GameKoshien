using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackPattern : MonoBehaviour
{
    public float AttackControl;
    public bool isCheckBossClear;
    public float BossHitPoint;
    public float CoreHitPoint;
    public float BossCondition;

    // Start is called before the first frame update
    void Start()
    {
        AttackControl = Random.Range(0,2);
        BossHitPoint = 18;
        CoreHitPoint = 18;
    }

    // Update is called once per frame
    void Update()
    {
       if(isCheckBossClear == false){
           if(AttackControl == 0){
               Invoke("RubbleAttack",5.0f);//5秒後に瓦礫攻撃の関数を呼び出す("RubbleAttack"の部分は呼びたい関数名に変更してください)
               AttackControl = Random.Range(0,2);
               if(AttackControl == 0){
                   AttackControl++;
               }
           }

           if(AttackControl == 1){
               Invoke("BodyAttack",5.0f);//５秒後に体当たりの関数を呼び出す("BodyAttack"の部分は呼びたい関数名に変更してください)
               AttackControl = Random.Range(0,2);
               if(AttackControl == 1){
                   AttackControl++;
               }
           }

           if(AttackControl == 2){
               Invoke("Summon",5.0f);//5秒後にボス小召喚の関数を呼び出す("Summon"の部分は呼びたい関数名に変更してください)
               AttackControl = Random.Range(0,2);
               if(AttackControl == 2){
                   AttackControl--;
               }
           }
        } 
    }
}
