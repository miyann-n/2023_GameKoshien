using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SurpriseActive : MonoBehaviour
{
    //初期設定
    private void Start()
    {
        this.gameObject.SetActive (false);
        Invoke(nameof(DelayMethod), 3.5f);  //DelayMethodを3.5秒後に呼び出す
    }

    //3.5秒後に呼び出されるメソッド
    void DelayMethod()
    {
        this.gameObject.SetActive (true);
        StartCoroutine(DelayCoroutine());  //DelayCoroutineを呼び出す
    }

    // コルーチン本体
    private IEnumerator DelayCoroutine()
    {     
        yield return new WaitForSeconds(1.8f);  // 3秒間待つ
        this.gameObject.SetActive (false);
    }
}