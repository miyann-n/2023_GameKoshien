using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    public MaterialMove materialMove;
    Vector3 ObjectStartPosition,mousePos,worldPos;
    // Start is called before the first frame update
    void Start()
    {
        //オブジェクトの初期座標を取得
        ObjectStartPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(materialMove.isCheckObjectChase){
            //マウス座標の取得
            mousePos = Input.mousePosition;
            //スクリーン座標をワールド座標に変換
            worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x,ObjectStartPosition.y,ObjectStartPosition.z));
            //ワールド座標を移動させるオブジェクトの座標に設定
            transform.position = worldPos;
        }
    }
}
