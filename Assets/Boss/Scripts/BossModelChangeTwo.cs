using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossModelChangeTwo : MonoBehaviour
{
    public int bossHelth = 5; //ボス体力
    public bool isCheckBossClear = false; //クリアの状態
    Animator animator; //アニメータ
    [SerializeField] private MonoBehaviour mmPath; //mmPathスクリプト
    [SerializeField] private BoxCollider2D boxcolli; //boxcolliderスクリプト
    [SerializeField] private MonoBehaviour RightMove; //reightmoveスクリプト
    public BossAttackPatternTree bossAttackPattern; //BossAttackPatternTreeスクリプト
    Vector3 startPos;   //初めの場所
    Vector3 endPos;     //向かう場所

    
    // Start is called before the first frame update
    void Start()
    {
        bossAttackPattern = GameObject.Find("RetroBlobDash").GetComponent<BossAttackPatternTree>();
        animator = GetComponent<Animator>(); 
        animator.SetBool("break", false); 
    }

    // Update is called once per frame
    void Update()
    {
        //クリアではない時実行
        if(isCheckBossClear == false){
            //ダメージ処理
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                SpaceInput();
            }
        }
    }

    //クリアの時に呼び出される関数
    public void Clear()
    {
        isCheckBossClear = true; //クリアフラグをONにする
        boxcolli.enabled = false; //ボックスコライダーをOFFにする
        //Debug.Log(isCheckBossClear);
        StartCoroutine(GotoTargetR(5));       
    }

    //ダメージを受けた時に呼び出される関数
    public void SpaceInput()
    {
        bossHelth -= 1; //体力を減らす

        if(bossHelth < 1){ 
            Clear(); //クリア処理を送る
        }
    }   
        
    //体力がなくなった時の逃げ動作
    IEnumerator GotoTargetR(float t)    //引数:t秒で指定した場所へ移動する関数
    {
        yield return new WaitForSeconds(1);
        float duration = t;     //移動にかける時間（引数:t）   
        float currentTime = 0;  //経過時間を初期化
        startPos = transform.position;     //移動開始位置
        endPos =  new Vector3(-40,15,5);     //向かう場所を指定
        //指定した時間を越えない間、以下の処理を繰り返す
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;      // 経過時間を更新
            float p = currentTime / duration;   //経過時間の割合を算出
            transform.position = Vector3.Lerp(startPos, endPos, p); //座標更新
            yield return null;                  //1フレームスキップ
        }
        Destroy(gameObject); //ゲームオブジェクトを破壊
    }
}
