using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
<<<<<<< HEAD

public class Rubble : MonoBehaviour
{
    public bool isCheckLeftClick;
    public bool isCheckMousePointLR;
    private bool isCheckCollisionPlayer;
    Rigidbody2D rb;
    // Start is called before the first frame update
=======
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

>>>>>>> feature/back_B
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
<<<<<<< HEAD
        if(Input.GetMouseButton(0)){
            RubbleMove();
        }

        if(Input.GetMouseButtonUp(0)){
=======
        string isRubbleItemCollected = File.ReadAllText("Assets/Back_B/Scripts/Flags.txt");
        if(Input.GetMouseButton(0) && isRubbleItemCollected == "true"){
            RubbleMove();
        }

        if(Input.GetMouseButtonUp(0) && isRubbleItemCollected == "true"){
>>>>>>> feature/back_B
            RubbleLaunch();
        }

    }

    private void RubbleMove(){
<<<<<<< HEAD
=======
        Debug.Log("クリック中");
>>>>>>> feature/back_B
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
<<<<<<< HEAD
                this.transform.position = new Vector2(playerPosition.x+1.2f,0.15f);
=======
               this.transform.position = new Vector2(playerPosition.x+0.8f,1f + playerPosition.y);
>>>>>>> feature/back_B
            }
            else if(worldPos.x < playerPosition.x){
                isCheckMousePointLR = false;
                Debug.Log("左");
<<<<<<< HEAD
                this.transform.position = new Vector2(playerPosition.x-1.2f,0.15f);
=======
                this.transform.position = new Vector2(playerPosition.x-0.8f,1f + playerPosition.y);
>>>>>>> feature/back_B
            }

        }
    }

    public void RubbleLaunch(){
        if(isCheckLeftClick){
            Debug.Log("クリック離し");
            isCheckLeftClick = false;
            
            if(isCheckMousePointLR){
<<<<<<< HEAD
                Vector2 force = new Vector2(50f,14f);
=======
                Vector2 force = new Vector2(50f,20f);
>>>>>>> feature/back_B
                Debug.Log("右に飛ばす");
                rb.AddForce (force, ForceMode2D.Impulse);   
            }
            else{
<<<<<<< HEAD
                Vector2 force = new Vector2(-50f,14f);
=======
                Vector2 force = new Vector2(-50f,20f);
>>>>>>> feature/back_B
                Debug.Log("左に飛ばす");
                rb.AddForce (force, ForceMode2D.Impulse);               
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collider) {
        if(collider.gameObject.tag == "Player"){
            isCheckCollisionPlayer = true;
<<<<<<< HEAD
            Debug.Log("Collision!");
=======
>>>>>>> feature/back_B
        }
    }
    
    private void OnTriggerExit2D(Collider2D collider) {
        if(collider.gameObject.tag == "Player"){
            isCheckCollisionPlayer = false;
<<<<<<< HEAD
            Debug.Log("Exit");
        }
    }

    /*private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag =="Ground"){
            rb.isKinematic = false;
        }
    }*/


=======
        }
    }

>>>>>>> feature/back_B
}
