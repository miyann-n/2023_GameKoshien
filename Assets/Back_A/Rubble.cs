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
             rubblePosition.x = playerPosition.x;
             rubblePosition.y = playerPosition.y;
             Vector2 mousePosition = Input.mousePosition;
             if(mousePosition.x > rubblePosition.x){
                isCheckMousePointLR = true;
             }
             else{
                isCheckMousePointLR = false;
             }
        }
    }

    public void OnMouseDrag(){
        isCheckLeftClick = true;
    }

    public void OnMouceUp(){
        isCheckLeftClick = false;
        if(isCheckMousePointLR){
            Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
            Vector2 force = new Vector2(10f,0f);
            rb.AddForce (force, ForceMode2D.Impulse);   
        }
        else{
            Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
            Vector2 force = new Vector2(-10f,0f);
            rb.AddForce (force, ForceMode2D.Impulse);               
        }
    }

}
