using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]

public class FlyingEnemy : MonoBehaviour
{
    bool Check;
    float EnemyArea;
    float x =1.0f;  //xの初期値を設定

    // Rigidbodyコンポーネントの参照
    private Rigidbody2D _rigidbody;
    // 速度を変更する際の加速度
    [SerializeField] private Vector2 acceleration;

    // 敵の速度を格納する変数（未定義）
    private float EnemySpeed;

    //プレイヤーがエリア内に入ったかを示すグローバル変数
    bool AreaChecker;
    
    
    // Start is called before the first frame update

    void Start()
    {
        // Rigidbodyコンポーネントを取得
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {   
        Vector2 EnemyPosition =this.transform.position;
        Debug.Log("Enemy x = " + EnemyPosition.x);
        Debug.Log("Enemy y = " + EnemyPosition.y);

        if ( Check == false){
            if( EnemyPosition.x == EnemyArea ){
                x = -1.0f; // xを反転
            }
            EnemySpeed = EnemySpeed * x ;
               /*敵に速度を与える*/
                RigidbodyAccelerator();

                
        }
        else {
            /*０．５秒待機*/
            StartCoroutine(WaitAndAttack()); 
        }
    }
    /*速度を与える処理*/

void RigidbodyAccelerator()
{
    // 加速度を指定してRigidbodyに力を加える
    //_rigidbody.AddForce(acceleration, ForceMode.Acceleration);
}

/*攻撃処理*/
     IEnumerator WaitAndAttack()
    {
        yield return new WaitForSeconds(0.5f); // 0.5秒待機
        Vector2 PlayerPosition =GameObject.Find("Player").transform.position;
        Debug.Log("Player x = " + PlayerPosition.x);
        Debug.Log("Player y = " + PlayerPosition.y);

        Vector2 EnemyPosition =this.transform.position;
        Debug.Log("Enemy x = " + EnemyPosition.x);
        Debug.Log("Enemy y = " + EnemyPosition.y);

        
        float Dist = Vector2.Distance(PlayerPosition,EnemyPosition);
        
        if(Check==true && Dist > 0 && AreaChecker == true ){
            EnemySpeed = EnemySpeed * 1.3f;
            /*AIActionMoveTowardsTarget*/
        }
    }

/*視界に入ったかの判定するやつ*/

/*プレイヤーが視界に入ったかどうかの判定*/
/*void PlayerChecker(){
    if(IsVisible == true){
        Check = true;
    }
    else{
        Check = false;
    }
}
*/
/*プレイヤーがエリアにはいったかどうかの判定*/
void OnCollisionStay2D(Collision2D col) {
    if (col.gameObject.name == "Player")
        {
            AreaChecker =true;
        }
     else
     {
        AreaChecker = false;
    }
}
}
class SightCheckerExample2D : MonoBehaviour
{
    // 自分自身
    [SerializeField] private Transform _self;

    // ターゲット
    [SerializeField] private Transform _target;

    // 視野角（度数法）
    [SerializeField] private float _sightAngle;

    // 視界の最大距離
    [SerializeField] private float _maxDistance = float.PositiveInfinity;

    #region Logic

    /// <summary>
    /// ターゲットが見えているかどうか
    /// </summary>
    /*public bool IsVisible()
    {
        // 自身の位置
        Vector2 selfPos = _self.position;
        // ターゲットの位置
        Vector2 targetPos = _target.position;

        // 自身の向き（正規化されたベクトル）
        // この例では右向きを正面とする
        Vector2 selfDir = _self.right;
        
        // ターゲットまでの向きと距離計算
        var targetDir = targetPos - selfPos;
        var targetDistance = targetDir.magnitude;

        // cos(θ/2)を計算
        var cosHalf = Mathf.Cos(_sightAngle / 2 * Mathf.Deg2Rad);

        // 自身とターゲットへの向きの内積計算
        // ターゲットへの向きベクトルを正規化する必要があることに注意
        var innerProduct = Vector2.Dot(selfDir, targetDir.normalized);

        // 視界判定
        return innerProduct > cosHalf && targetDistance < _maxDistance;
    }*/

    #endregion

    #region Debug

    // 視界判定の結果をGUI出力
    
    #endregion
}
