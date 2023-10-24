using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubbleTwo : MonoBehaviour
{
    Rigidbody2D rd;
    [SerializeField] private SpriteRenderer sp;
    [SerializeField] private BoxCollider2D boxcolli;
    private BossModelChangeTwo bossModelChange; //bossmodelchangeスクリプト
    private BossAttackPatternTwo bossAttackPattern; //bossattackpatternスクリプト
    private float PositionY = 3.5f; //瓦礫初期Y座標
    
    void Start()
    {
        bossModelChange = GameObject.Find("RetroBlobDash").GetComponent<BossModelChangeTwo>();
        bossAttackPattern = GameObject.Find("RetroBlobDash").GetComponent<BossAttackPatternTwo>();
        Vector3 posi = this.transform.localPosition; //瓦礫オブジェクトの初期位置の取得
        rd = this.GetComponent<Rigidbody2D>(); 
        rd.bodyType = RigidbodyType2D.Static; //重力を無効化
        sp.enabled = false; //瓦礫を隠す
        boxcolli.enabled = false;
    }

    //床に触れた時の処理
    private void OnTriggerEnter2D(Collider2D other)
    {
        Vector3 posi = this.transform.localPosition; //初期位置を取得
        //床に触れた時
        if (other.gameObject.CompareTag("Platform"))
        {
            posi = new Vector3(posi.x, PositionY, posi.z);
            this.transform.localPosition = posi; //初期位置にセット
            rd.bodyType = RigidbodyType2D.Static; //重力を無効化
            sp.enabled = false; //隠す
            boxcolli.enabled = false;
            bossAttackPattern.RunningChecker = false; //攻撃状態フラグをOFF
        }
    }

    //瓦礫攻撃が呼び出された時
    public void rbAttack()
    {
        bossAttackPattern.RunningChecker = true; //攻撃状態フラグをON
        bool isCheckBossClear = bossModelChange.isCheckBossClear;
        //クリア状態ではない時
        if(isCheckBossClear != true){
            sp.enabled = true; //表示する
            boxcolli.enabled = true;
            rd.bodyType = RigidbodyType2D.Dynamic; //重力を有効化
        }
    }
}
