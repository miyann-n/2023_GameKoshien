using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;

public class GravityReversalPlayer : MonoBehaviour
{
    public bool isCheckReversalDate;//アイテム「重力反転データ」の有無の判定
    public bool isHitReversalGround;//重力反転すると別エリアに行ける場所にいるかの判定
    public bool isCheckKey3;

    public GravityMain gravityMain;
    public MaterialMove materialMove;
    public FireArm firearm;
    public EnemySpeed enemySpeed;
    /*public Player player;//プレイヤー情報を取得する。*/



    // Start is called before the first frame update
    void Start()
    {
      isCheckReversalDate = true;
      isCheckKey3 = false;
      isHitReversalGround = false;
    } 

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha3) && isCheckReversalDate){
            isCheckKey3 = true;
            Debug.Log("重力反転選択");
            gravityMain.isCheckKey2 = false;
            materialMove.isCheckKey1 = false;
        }

        if(isCheckKey3 && Input.GetKeyDown(KeyCode.E) && isHitReversalGround == false){
            Debug.Log("飛び道具反転");
            firearm.firearmSpeedf = firearm.firearmSpeedf * -1.0f;
            Debug.Log(firearm.firearmSpeedf);       
        }

        if(isCheckKey3 && Input.GetKeyDown(KeyCode.E) && isHitReversalGround){
            Debug.Log("エリア移動");
            Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
            Vector2 force = new Vector2(0.0f,10.0f);
            rb.AddForce(force,ForceMode2D.Impulse);//プレイヤーの上方向に力を一瞬かけて飛ばす処理(エリア移動処理に変更してください)
        }
    }

    private void IsTriggerStay2D(Collider2D collision){
        if(collision.gameObject.tag == "ReversalArea"){
            Debug.Log("OK");
            isHitReversalGround = true;
        }
    }
}
