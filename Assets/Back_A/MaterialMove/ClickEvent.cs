using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickEvent : MonoBehaviour
{

    private MaterialMove materialMove;
    private bool isCheckObjectMove;

    Vector2 mousePos,worldPos;

    private void Start()
    {
        materialMove = GameObject.FindWithTag("Player").GetComponent<MaterialMove>();
        isCheckObjectMove = false;
    }
    void Update()
    {
        bool isCheckAbilityWake = materialMove.isCheckAbilityWake;

        if(isCheckObjectMove && materialMove.isCheckAbilityWake){
            ObjectMove();
        }

        if(materialMove.isCheckAbilityWake == false){
                isCheckObjectMove = false;
        }
    }

    public void ObjectClick(){
        
        if(materialMove.isCheckAbilityWake){

            isCheckObjectMove = !isCheckObjectMove;
            Debug.Log("materialMove = true");
        }
        
    }

    private void ObjectMove(){
        mousePos = Input.mousePosition;//マウス座標の取得

        worldPos = Camera.main.ScreenToWorldPoint(new Vector2(mousePos.x,mousePos.y));//スクリーン座標をワールド座標に変換


        this.transform.position = worldPos;//ワールド座標を移動させるオブジェクトの座標に設定
    }

}
