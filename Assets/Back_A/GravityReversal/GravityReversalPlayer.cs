using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;

public class GravityReversalPlayer : MonoBehaviour
{
    public bool isCheckReversalDate;//アイテム「重力反転データ」の有無の判定
    public bool isHitReversalGround;//重力反転すると別エリアに行ける場所にいるかの判定
    public bool isCheckReversalSet;
    public EnemySpeed enemySpeed;
    /*public Player player;//プレイヤー情報を取得する。*/



    // Start is called before the first frame update
    void Start()
    {
      isCheckReversalDate = true;
      isCheckReversalSet = false;
      isHitReversalGround = false;
    } 

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Alpha3) && isCheckReversalDate){
            isCheckReversalSet = true;
            Debug.Log("重力反転選択");
        }

        if(isCheckReversalSet && Input.GetKey (KeyCode.E) && isHitReversalGround == false){
            Debug.Log("飛び道具反転");
            enemySpeed.EnemySpeedf = enemySpeed.EnemySpeedf * -1.0f;
            Debug.Log(enemySpeed.EnemySpeedf);       
        }

        if(isCheckReversalSet && Input.GetKey (KeyCode.E) && isHitReversalGround){
            Debug.Log("エリア移動");
            Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
            Vector2 force = new Vector2(0.0f,10.0f);
            rb.AddForce(force,ForceMode2D.Impulse);//プレイヤーの上方向に力を一瞬かけて飛ばす処理(エリア移動処理に変更してください)
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "ReversalArea"){
            Debug.Log("OK");
            isHitReversalGround = true;
        }
    }
}
