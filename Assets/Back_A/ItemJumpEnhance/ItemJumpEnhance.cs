using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemJumpEnhance : MonoBehaviour
{
    public gcJumpEnhance gcJumpEnhance;
    [SerializeField] GameObject jumpEnhanceUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gcJumpEnhance.getJumpEnhance){
            //materialMove.isCheckObjectMove = true;(ここでジャンプ力増強の能力のフラグをオンにしてます)
            Destroy(this.gameObject);
            //ここに取得メッセージ等を表示する処理
            //ここにチュートリアル開始の処理
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.tag == "Player"){
            Debug.Log("OK");
            jumpEnhanceUI.SetActive(true);
            //アイテム説明等のUIを表示する処理
        }
    }

    private void OnCollisionExit2D(Collision2D collision){
        if(collision.gameObject.tag =="Player"){
            jumpEnhanceUI.SetActive(false);
            Debug.Log("OUt");
        }
    }
}
