using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityDoor : MonoBehaviour
{
    public BoxCollider2D boxCollider2D;

    //public Player player;(プレイヤーのスクリプトを取得)

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        private void OnCollisionEnter(Collision collision) 
    {
        if(collision.gameObject.tag == "Player")
        {
            //「開く」というUIを出す処理
          /*if(Player.isCheckSecurityKey1){ (ここはキーの数字に応じて書き換え必要ありマス)
                boxCollider2D.enabled = false;(扉の当たり判定を消す)
            }*/

          /*else{
                ・「キーがないと開かないようだ」という文のUIを表示する処理
            }*/
        }
    }
}
