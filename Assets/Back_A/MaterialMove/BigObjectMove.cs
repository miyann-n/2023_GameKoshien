using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigObjectMove : MonoBehaviour
{
    public MaterialMove materialMove;
    public GravityClickCharactor gclickCharactor;
    Vector2 mousePos,worldPos;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(materialMove.isCheckObjectChase){
            if(gclickCharactor.isCheckCanBigObject){
                //マウス座標の取得
                mousePos = Input.mousePosition;
                //スクリーン座標をワールド座標に変換
                worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x,mousePos.y));
                //ワールド座標を移動させるオブジェクトの座標に設定
                transform.position = worldPos;
            }
        }
    }
}

