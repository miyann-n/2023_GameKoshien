using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD

public class BigRubble : MonoBehaviour
{
    public bool isCheckLeftClick;
    public bool isCheckMousePointLR;
    private bool isCheckCollisionPlayer;
    Rigidbody2D rb;
    
    public Player player;

=======
using MoreMountains.CorgiEngine;
using RubbleManager;
using System.IO;

public class BigRubble : MonoBehaviour
{   
    RubbleManager.RubbleManagement  rubbleManager = new RubbleManager.RubbleManagement();
    public bool isCheckLeftClick;
    public bool isCheckMousePointLR;
    private bool isCheckCollisionPlayer;
    private Rigidbody2D rb;
    
    //public GameObject player;


    public RubbleManagement rubbleManagement;
>>>>>>> feature/back_B
    // Start is called before the first frame update
    void Start()
    {
        isCheckLeftClick = false;
        isCheckMousePointLR = false;
        isCheckCollisionPlayer = false;
        rb = this.gameObject.GetComponent<Rigidbody2D>();
<<<<<<< HEAD
=======
        //rubbleManagement = GameObject.Find("Player").GetComponent<RubbleManagement>();
>>>>>>> feature/back_B
    }

    // Update is called once per frame
    void Update()
<<<<<<< HEAD
    {
        if(Input.GetMouseButton(0) && player.isCheckBigObjectMove){
            RubbleMove();
        }

        if(Input.GetMouseButtonUp(0) && player.isCheckBigObjectMove){
=======
    {   
        string isRubbleItemCollected = File.ReadAllText("Assets/Back_B/Scripts/Flags.txt");
        string isCheckBigObjectMove = File.ReadAllText("Assets/Back_B/Scripts/EnergyFlags.txt");
        
        if(Input.GetMouseButton(0) && isCheckBigObjectMove == "true" && isRubbleItemCollected == "true"){
            RubbleMove();
        }

        if(Input.GetMouseButtonUp(0) && isCheckBigObjectMove == "true" && isRubbleItemCollected == "true"){
>>>>>>> feature/back_B
            RubbleLaunch();
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
<<<<<<< HEAD
                this.transform.position = new Vector2(playerPosition.x+2.2f,0.15f);
=======
                this.transform.position = new Vector2(playerPosition.x+1.7f,1.5f + playerPosition.y);
>>>>>>> feature/back_B
            }
            else if(worldPos.x < playerPosition.x){
                isCheckMousePointLR = false;
                Debug.Log("左");
<<<<<<< HEAD
                this.transform.position = new Vector2(playerPosition.x-2.2f,0.15f);
=======
                this.transform.position = new Vector2(playerPosition.x-1.7f,1.5f + playerPosition.y);
>>>>>>> feature/back_B
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
=======
>>>>>>> feature/back_B
        }
    }


}
