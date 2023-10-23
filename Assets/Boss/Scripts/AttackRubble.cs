using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRubble : MonoBehaviour
{
    private bool leftClick = false;
    private bool direction = false;
    public Rigidbody2D rb;
    Vector3 startPos;   //初めの場所
    Vector3 endPos;     //向かう場所

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        
    }
    /*void Update()
    {
        
        Debug.Log(leftClick);
        if(leftClick == true)
        {
            Vector3 posi = this.transform.position;
            GameObject player = GameObject.FindWithTag("Player");
            posi = player.transform.position;
            Vector3 mousePos = Input.mousePosition;
            Debug.Log(mousePos);

            if(mousePos.x > posi.x)
            {
                direction = true;
            }
            else if(mousePos.x < posi.x)
            {
                direction = false;
            }
        }
    }

    public void OnMouseDown(){
        leftClick = true;
        //Debug.Log("yyy");
    }

    public void OnMouseUp(){
        leftClick = false;
        if(direction == true)
        {
            rb.AddForce(transform.forward * 10.0f, ForceMode2D.Force);
        }
    }*/

    private bool buttonDownFlag = false;
    private void Update()
    {
        if (leftClick)
        {
            // ボタンが押しっぱなしの状態の時にのみ「Hold」を表示する。
            Vector3 posi = this.transform.position; //瓦礫オブジェクトの位置取得
            
            //GameObject player = GameObject.FindWithTag("Player");//ゲームタグがPlayerのオブジェクトを取得
            //posi = player.transform.position;//瓦礫オブジェクト＝
            Vector3 mousePos = Input.mousePosition;
            Vector3 ScPosi = Camera.main.WorldToScreenPoint(new Vector3(posi.x, posi.y,10f));
            //Vector3 worldMouse = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y,10f));
            Debug.Log(ScPosi);
            if(mousePos.x > ScPosi.x)
            {
                direction = true;
            }
            else if(mousePos.x < ScPosi.x)
            {
                direction = false;
            }
        }
    }
    // ボタンを押したときの処理
    public void OnButtonDown()
    {
        leftClick = true;
    }
    // ボタンを離したときの処理
    public void OnButtonUp()
    {
        leftClick = false;
        if(direction == true)
        {
            StartCoroutine(GotoTargetR(1));
            //rb.AddForce(transform.forward * 10.0f, ForceMode2D.Force);
        }
        if(direction == false)
        {
            StartCoroutine(GotoTargetL(1));
            //rb.AddForce(transform.forward * 10.0f, ForceMode2D.Force);
        }
    }

    IEnumerator GotoTargetR(float t) //引数:t秒でクリックした座標に移動する関数
    {
        float duration = t;     //移動にかける時間    
        float currentTime = 0;  //経過時間を初期化
        startPos = transform.position;      //移動開始位置   
        //指定した時間を越えない間、以下の処理を繰り返す
        while (currentTime < duration)
        {
        currentTime += Time.deltaTime;      // 経過時間を更新
        float p = currentTime / duration;   //経過時間の割合を算出
        transform.position = Vector3.Lerp(startPos, endPos, p); //座標更新
        yield return null;                  //1フレームスキップ
        }
    }
    IEnumerator GotoTargetL(float t) //引数:t秒でクリックした座標に移動する関数
    {
        float duration = t;     //移動にかける時間    
        float currentTime = 0;  //経過時間を初期化
        startPos = transform.position;      //移動開始位置   
        //指定した時間を越えない間、以下の処理を繰り返す
        while (currentTime < duration)
        {
        currentTime += Time.deltaTime;      // 経過時間を更新
        float p = currentTime / duration;   //経過時間の割合を算出
        transform.position = Vector3.Lerp(-startPos, -endPos, p); //座標更新
        yield return null;                  //1フレームスキップ
        }
    }
}
