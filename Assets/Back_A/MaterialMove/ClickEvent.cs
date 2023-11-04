using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickEvent : MonoBehaviour
{

<<<<<<< HEAD
    public MaterialMove materialMove;
=======
    private MaterialMove materialMove;
>>>>>>> feature/back_B
    private bool isCheckObjectMove;

    Vector2 mousePos,worldPos;

<<<<<<< HEAD
    void Update()
    {
=======
    private void Start()
    {
        materialMove = GameObject.FindWithTag("Player").GetComponent<MaterialMove>();
        isCheckObjectMove = false;
    }
    void Update()
    {
        bool isCheckAbilityWake = materialMove.isCheckAbilityWake;

>>>>>>> feature/back_B
        if(isCheckObjectMove && materialMove.isCheckAbilityWake){
            ObjectMove();
        }

        if(materialMove.isCheckAbilityWake == false){
                isCheckObjectMove = false;
        }
    }

    public void ObjectClick(){
        
        if(materialMove.isCheckAbilityWake){

<<<<<<< HEAD
            if(isCheckObjectMove == false){
                isCheckObjectMove = true;
                Debug.Log("materialMove = true");
            }

=======
            isCheckObjectMove = !isCheckObjectMove;
            Debug.Log("materialMove = true");
>>>>>>> feature/back_B
        }
        
    }

    private void ObjectMove(){
        mousePos = Input.mousePosition;//マウス座標の取得
<<<<<<< HEAD
        worldPos = Camera.main.ScreenToWorldPoint(new Vector2(mousePos.x,mousePos.y));//スクリーン座標をワールド座標に変換
=======

        worldPos = Camera.main.ScreenToWorldPoint(new Vector2(mousePos.x,mousePos.y));//スクリーン座標をワールド座標に変換


>>>>>>> feature/back_B
        this.transform.position = worldPos;//ワールド座標を移動させるオブジェクトの座標に設定
    }

}
