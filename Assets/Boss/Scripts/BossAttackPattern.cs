using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackPattern : MonoBehaviour
{
    public float AttackControl;
    private BossModelChange bossModelChange; //bossmodelchangeスクリプト
    private Rubble rubble;

    // Start is called before the first frame update
    void Start()
    {
        AttackControl = Random.Range(0,2);
        bossModelChange = GameObject.Find("RetroBlobDash").GetComponent<BossModelChange>();
        rubble = GameObject.Find("BossRubble").GetComponent<Rubble>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isCheckBossClear = bossModelChange.isCheckBossClear;
        //Debug.Log(isCheckBossClear);

       if(isCheckBossClear == false){
           if(AttackControl == 0){
               StartCoroutine(RubbleAttack());//5秒後に瓦礫攻撃の関数を呼び出す("RubbleAttack"の部分は呼びたい関数名に変更してください)
               
           }

           if(AttackControl == 1){
               StartCoroutine(BodyAttack());//５秒後に体当たりの関数を呼び出す("BodyAttack"の部分は呼びたい関数名に変更してください)
               
           }

           if(AttackControl == 2){
               StartCoroutine(Summon());//5秒後にボス小召喚の関数を呼び出す("Summon"の部分は呼びたい関数名に変更してください)
               
           }
        } 
    }

    private IEnumerator RubbleAttack()
    {
        yield return new WaitForSeconds(10);
        rubble.rbAttack();
        AttackControl = Random.Range(0,3);
        if(AttackControl == 0){
           AttackControl++;
       }
        //yield break;
    }
    private IEnumerator BodyAttack()
    {
        yield return new WaitForSeconds(10);
        AttackControl = Random.Range(0,3);
        if(AttackControl == 1){
            AttackControl++;
        }
    }

    private IEnumerator Summon()
    {
        yield return new WaitForSeconds(10);
        AttackControl = Random.Range(0,3);
        if(AttackControl == 2){
            AttackControl--;
        }
    }
}
