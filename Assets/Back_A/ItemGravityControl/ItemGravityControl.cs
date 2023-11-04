using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGravityControl : MonoBehaviour
{
    public MaterialMove materialMove;
    public gcGravityControl gcGravityControl;
    [SerializeField] GameObject gravityControlUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gcGravityControl.getGravityControl){
            //materialMove.isCheckObjectMove = true;(ここで重力操作の能力のフラグをオンにしてます)
            Destroy(this.gameObject);
            //ここに取得メッセージを表示する処理
            //ここにチュートリアル開始の処理
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("OK!");
            gravityControlUI.SetActive(true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision){
        if(collision.gameObject.tag =="Player"){
            gravityControlUI.SetActive(false);
            Debug.Log("OUt");
        }
    }
}
