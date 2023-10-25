using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rubble : MonoBehaviour
{
    public bool isCheckLeftClick;
    public bool isCheckMousePointLR;
    // Start is called before the first frame update
    void Start()
    {
        isCheckLeftClick = false;
        isCheckMousePointLR = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isCheckLeftClick){
             GameObject player = GameObject.FindWithTag("Player");
             Vector2 playerPosition = player.transform.position;
             Vector2 rubblePosition = this.transform.position;
             Debug.Log("プレイヤー取得");
             rubblePosition = playerPosition;
             this.transform.position = rubblePosition;
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

    public void OnMouseUp(){
        Debug.Log("クリック離し");
        isCheckLeftClick = false;
        if(isCheckMousePointLR){
            Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
            Vector2 force = new Vector2(100f,5.0f);
            Debug.Log("右に飛ばす");
            rb.AddForce (force, ForceMode2D.Impulse);   
        }
        else{
            Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
            Vector2 force = new Vector2(-100f,5f);
            Debug.Log("左に飛ばす");
            rb.AddForce (force, ForceMode2D.Impulse);               
        }
    }

    public void OnMouseDrag(){
        isCheckLeftClick = true;
        Debug.Log("クリック確認");
    }


}
