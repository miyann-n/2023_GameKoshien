using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;

public class GravityReversalPlayer : MonoBehaviour
{
    public bool isCheckReversalDate;//アイテム「重力反転データ」の有無の判定
    public bool isHitReversalGround;//重力反転すると別エリアに行ける場所にいるかの判定
    /*public Player player;//プレイヤー情報を取得する。*/
    Vector2 rb;


    // Start is called before the first frame update
    void Start()
    {
      isCheckReversalDate = false;
      isHitReversalGround = false;
      Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
    } 

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Alpha3)){
            isCheckReversalDate = true;
        }

        if(isCheckReversalDate & Input.GetKey (KeyCode.E) & isHitReversalGround == false){
            GameObject[] enemyObjects = GameObject.FindGameObjectsWithTag("firearm");//タグ「firearm（飛び道具）」のオブジェクトを取得
            foreach (GameObject firearm in enemyObjects){//リストに入った飛び道具のオブジェクト一つ一つに処理を与える。
                Vector3 tmp = firearm.transform.position;
                firearm.transform.position = new Vector3(tmp.x*-1,tmp.y*-1,tmp.z*-1);//オブジェクトのベクトルの反転処理        
            }
        }

        if(isCheckReversalDate & Input.GetKey (KeyCode.E) & isHitReversalGround){
            Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
            Vector2 force = new Vector2(0.0f,10.0f);
            rb.AddForce(force,ForceMode2D.Impulse);//プレイヤーの上方向に力を一瞬かけて飛ばす処理
        }
    }

    void OnCollisionEnter2D(Collision collision){
        if(collision.gameObject.tag == "ReversalArea"){
            isHitReversalGround = true;
        }
    }
}
