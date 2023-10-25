using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    public MaterialMove materialMove;
    Vector2 mousePos,worldPos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(materialMove.isCheckObjectChase){
            //マウス座標の取得
            mousePos = Input.mousePosition;
            //スクリーン座標をワールド座標に変換
            worldPos = Camera.main.ScreenToWorldPoint(new Vector2(mousePos.x,mousePos.y));
            //ワールド座標を移動させるオブジェクトの座標に設定
            this.transform.position = worldPos;
            Debug.Log(this.transform.position);
        }
    }
}
