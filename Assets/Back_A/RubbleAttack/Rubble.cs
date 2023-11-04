using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using RubbleManager;
using System.IO;

public class Rubble : MonoBehaviour
{
    RubbleManager.RubbleManagement  rubbleManager = new RubbleManager.RubbleManagement();
    public bool isCheckLeftClick;
    public bool isCheckMousePointLR;
    private bool isCheckCollisionPlayer;

    //public GameObject[] PlayerPrefabs;
    public RubbleManagement rubbleManagement;
    Rigidbody2D rb;
    // Start is called before the first frame update

    void Start()
    {
        isCheckLeftClick = false;
        isCheckMousePointLR = false;
        isCheckCollisionPlayer = false;
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        string isRubbleItemCollected = File.ReadAllText("Assets/Back_B/Scripts/Flags.txt");
        if(Input.GetMouseButton(0) && isRubbleItemCollected == "true"){
            RubbleMove();
        }

        if(Input.GetMouseButtonUp(0) && isRubbleItemCollected == "true"){
            RubbleLaunch();
        }

    }

    private void RubbleMove(){
        Debug.Log("クリック中");
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
               this.transform.position = new Vector2(playerPosition.x+0.8f,1f + playerPosition.y);
            }
            else if(worldPos.x < playerPosition.x){
                isCheckMousePointLR = false;
                Debug.Log("左");
                this.transform.position = new Vector2(playerPosition.x-0.8f,1f + playerPosition.y);
            }

        }
    }

    public void RubbleLaunch(){
        if(isCheckLeftClick){
            Debug.Log("クリック離し");
            isCheckLeftClick = false;
            
            if(isCheckMousePointLR){
                Vector2 force = new Vector2(50f,20f);
                Debug.Log("右に飛ばす");
                rb.AddForce (force, ForceMode2D.Impulse);   
            }
            else{
                Vector2 force = new Vector2(-50f,20f);
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
