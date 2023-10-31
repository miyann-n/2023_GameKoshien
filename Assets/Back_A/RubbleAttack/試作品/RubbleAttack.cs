using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class RubbleAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isCheckLeftClick;
    public bool isCheckMousePointLR;
    public bool isCheckCollision;
    public GameObject player;
    private GameObject rubble;
   
    private Collider2D RubbleCollider;
    // Start is called before the first frame update
    void Start()
    {
        isCheckLeftClick = false;
        isCheckMousePointLR = false;
        isCheckCollision = false;
    }

    // Update is called once per frame
    void Update()
    {

        if(isCheckLeftClick == false && isCheckCollision){
            Rubblelaunch();
        }

    }

    public void OnCollisionStay2D(Collision2D collision){
        Debug.Log("衝突");
            if(collision.gameObject.tag == "SmallObject" && isCheckLeftClick){ //障害物（小）を攻撃に使う時の処理
                 isCheckCollision = true;
                 Debug.Log("当たり判定稼働中");
                 rubble = collision.gameObject;
                 RubbleCollider = collision.gameObject.GetComponent<CircleCollider2D>();
                 Vector2 playerPosition = player.transform.position;
                 RubbleCollider.enabled = false;
                 collision.gameObject.transform.position = playerPosition;
                 Debug.Log("プレイヤー = 瓦礫");
                 Vector2 mousePosition = Input.mousePosition;
                 Vector2 worldPos = Camera.main.ScreenToWorldPoint(new Vector2(mousePosition.x,mousePosition.y));
                 Debug.Log(playerPosition);
                 if(worldPos.x > playerPosition.x){
                    isCheckMousePointLR = true;
                    Debug.Log("右");
                 }
                 else if(worldPos.x < playerPosition.x){
                    isCheckMousePointLR = false;
                    Debug.Log("左");
                 }

            }

    }

    private void Rubblelaunch(){
        if(isCheckMousePointLR){
            Rigidbody2D rb = rubble.GetComponent<Rigidbody2D>();
            Vector2 force = new Vector2(100f,50f);
            Debug.Log("右に飛ばす");
            rb.AddForce (force, ForceMode2D.Impulse);   
        }
        else{
            Rigidbody2D rb = rubble.GetComponent<Rigidbody2D>();
            Vector2 force = new Vector2(-100f,5f);
            Debug.Log("左に飛ばす");
            rb.AddForce (force, ForceMode2D.Impulse);               
        }
    }



}

