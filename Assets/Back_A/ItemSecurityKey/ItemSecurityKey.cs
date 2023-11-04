using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSecurityKey : MonoBehaviour
{    
    public gcSecurityKey gcSecurityKey;
    [SerializeField] GameObject securityUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gcSecurityKey.getSecurityKey){
            //materialMove.isCheckSecurityKey1 = true;(ここで取得した鍵のフラグをオンにしてます（数字は要変更)
            Destroy(this.gameObject);
            //ここに取得メッセージ等を表示する処理
            //ここにチュートリアル開始の処理
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.tag == "Player"){
            Debug.Log("OK");
            securityUI.SetActive(true);
            //アイテム説明等のUIを表示する処理
        }
    }

    private void OnCollisionExit2D(Collision2D collision){
        if(collision.gameObject.tag =="Player"){
            securityUI.SetActive(false);
            Debug.Log("OUt");
        }
    }
}
