using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityClickEnemy : MonoBehaviour
{

    public GravityMain gravityMain;
    public EnemySpeed enemySpeed;
    public float EnemyOriginalSpeed; //変数3

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void EnemyGravityEnhance()
    {
         if (gravityMain.isCheckKeyE)
        {
            // 変数3=敵の元の移動速度
            EnemyOriginalSpeed = enemySpeed.EnemySpeedf; //EnemyOriginalSpeedは敵の行動を指定しているスクリプトから取得する
            Debug.Log(EnemyOriginalSpeed);

            // 敵の速度=変数3 * 0.8
            enemySpeed.EnemySpeedf = enemySpeed.EnemySpeedf * 0.8f;
            Debug.Log(enemySpeed.EnemySpeedf);


            // 10秒待機
            Invoke("ResetSpeed", 10f);
            Debug.Log("10秒間デバフ");
        }
    }
    

    // 10秒間待機するコルーチン
    private void ResetSpeed(){
        enemySpeed.EnemySpeedf = EnemyOriginalSpeed;
        Debug.Log(enemySpeed.EnemySpeedf);
    }
}