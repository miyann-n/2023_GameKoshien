using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigRubble : MonoBehaviour
{
    public bool isCheckLeftClick;
    public bool isCheckMousePointLR;
    private bool isCheckCollisionPlayer;
    private Rigidbody2D rb;
    
    //public GameObject player;
    public GameObject player;
    private Energy energy;

    // Start is called before the first frame update
    void Start()
    {
        energy = player.GetComponent<Energy>();
        isCheckLeftClick = false;
        isCheckMousePointLR = false;
        isCheckCollisionPlayer = false;
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {   
        bool isCheckBigObjectMove = energy.isCheckBigObjectMove;   


        if(Input.GetMouseButton(0) /*&& isCheckBigObjectMovez*/){
            RubbleMove();
            Debug.Log(isCheckBigObjectMove);
        }

        if(Input.GetMouseButtonUp(0) /*&& isCheckBigObjectMove*/){
            RubbleLaunch();
        }
        if(Input.GetMouseButton(0))
        {
            Debug.Log(isCheckBigObjectMove);
        }

    }

    private void RubbleMove(){
        if(isCheckCollisionPlayer){
            GameObject player = GameObject.FindWithTag("Player");
            Vector2 playerPosition = player.transform.position;
            this.transform.position = new Vector2(playerPosition.x+1.2f,this.transform.position.y);
            Debug.Log("プレイヤー取得");
            Vector2 mousePosition = Input.mousePosition;
            Vector2 worldPos = Camera.main.ScreenToWorldPoint(new Vector2(mousePosition.x,mousePosition.y));
            Debug.Log(playerPosition);
            isCheckLeftClick = true;

            if(worldPos.x > playerPosition.x){
                isCheckMousePointLR = true;
                Debug.Log("右");
                this.transform.position = new Vector2(playerPosition.x+2.2f,0);
            }
            else if(worldPos.x < playerPosition.x){
                isCheckMousePointLR = false;
                Debug.Log("左");
                this.transform.position = new Vector2(playerPosition.x-2.2f,0);
            }

        }
    }

    public void RubbleLaunch(){
        if(isCheckLeftClick){
            Debug.Log("クリック離し");
            isCheckLeftClick = false;
            
            if(isCheckMousePointLR){
                Vector2 force = new Vector2(50f,14f);
                Debug.Log("右に飛ばす");
                rb.AddForce (force, ForceMode2D.Impulse);   
            }
            else{
                Vector2 force = new Vector2(-50f,14f);
                Debug.Log("左に飛ばす");
                rb.AddForce (force, ForceMode2D.Impulse);               
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collider) {
        if(collider.gameObject.tag == "Player"){
            isCheckCollisionPlayer = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D collider) {
        if(collider.gameObject.tag == "Player"){
            isCheckCollisionPlayer = false;
        }
    }


}