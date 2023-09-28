using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityClickEnemy : MonoBehaviour
{

    public bool variable2 = false; //変数２
    public float variable3; //変数3

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if (variable2)
        {
            // 左クリックされたかどうかを確認
            if (Input.GetMouseButtonDown(0))
            {
                // 変数3=敵の元の移動速度
                //float variable3 = EnemyOriginalSpeed; //EnemyOriginalSpeedは敵の行動を指定しているスクリプトから取得する

                // 敵の速度=変数3 * 0.8
                float EnemySpeed = variable3 * 0.8f;

                // 10秒待機
                StartCoroutine(WaitForSeconds(10.0f));

                // 敵の速度=変数3
                EnemySpeed = variable3;
            }
        }
    }
    
    void EnemySpecifying()
    {
        //敵の行動を指定しているスクリプトの取得



        // 処理終了
    }

    // 10秒間待機するコルーチン
    private IEnumerator WaitForSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
}