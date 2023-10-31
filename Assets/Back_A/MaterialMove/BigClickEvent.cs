using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigClickEvent : MonoBehaviour
{

    public MaterialMove materialMove;
    public GravityClickCharactor gcCharactor;
    private bool isCheckObjectMove;

    Vector2 mousePos,worldPos;

    void Update()
    {
        if(gcCharactor.isCheckCanBigObject && isCheckObjectMove && materialMove.isCheckAbilityWake){
            ObjectMove();
        }

        if(materialMove.isCheckAbilityWake == false){
                isCheckObjectMove = false;
        }
    }

    public void ObjectClick(){
        
        if(materialMove.isCheckAbilityWake && gcCharactor.isCheckCanBigObject){

            if(isCheckObjectMove == false){
                isCheckObjectMove = true;
                Debug.Log("materialMove = true");
            }

        }
        
    }

    private void ObjectMove(){
        mousePos = Input.mousePosition;//マウス座標の取得
        worldPos = Camera.main.ScreenToWorldPoint(new Vector2(mousePos.x,mousePos.y));//スクリーン座標をワールド座標に変換
        this.transform.position = worldPos;//ワールド座標を移動させるオブジェクトの座標に設定
    }

}