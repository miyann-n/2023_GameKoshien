using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSecurityKey : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision) 
    {
        if(collision.gameObject.tag == "Player")
        {
            //「拾う」というUIを出す処理
            //アイテム説明等のUIを表示する処理
            //Player.isCheckSecurityKey1 = true; (ここはキーの数字に応じて書き換え必要ありマス)
            Destroy(this.gameObject);
        }
    }
}
