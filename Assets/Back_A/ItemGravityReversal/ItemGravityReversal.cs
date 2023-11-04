using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGravityReversal : MonoBehaviour
{
    // Start is called before the first frame update
    public GravityReversalPlayer gravityReversalPlayer;
    public gcGravityReversal gcGravityReversal;
    [SerializeField] GameObject gravityReversalUI;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gcGravityReversal.getGravityReversal){
            //materialMove.isCheckObjectMove = true;(ここで重力反転の能力のフラグをオンにしてます)
            Destroy(this.gameObject);
            //ここに取得メッセージ等を表示する処理
            //ここにチュートリアル開始の処理
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("OK");
            gravityReversalUI.SetActive(true);
            //アイテム説明等のUIを表示する処理
        }
    }

    private void OnCollisionExit2D(Collision2D collision){
        if(collision.gameObject.tag =="Player"){
            gravityReversalUI.SetActive(false);
            Debug.Log("OUt");
        }
    }
}
