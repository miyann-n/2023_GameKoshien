using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackPatternTree : MonoBehaviour
{
    public int AttackControl; //攻撃パターンの乱数を格納
    private BossModelChangeTree bossModelChange; //bossmodelchangeスクリプト
    private RubbleTree rubble; //RubbleTreeスクリプト
    public List<GameObject> RubbleList; //瓦礫オブジェクトを格納するリスト
    public GameObject[] RubbleArray; //瓦礫オブジェクトを格納する配列
    [SerializeField] private MonoBehaviour RightMove; //RightMoveスクリプト
    [SerializeField] private MonoBehaviour LeftMove; //LeftMoveスクリプト
    [SerializeField] private MonoBehaviour mmPath; //mmPathスクリプト
    public bool RunningChecker = false; //攻撃状態フラグ
    Vector3 startPos;   //初めの場所
    Vector3 endPos;     //向かう場所
    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        AttackControl = Random.Range(0,2); //乱数を生成(０〜１)
        bossModelChange = GameObject.Find("RetroBlobDash").GetComponent<BossModelChangeTree>();
        RubbleArray = GameObject.FindGameObjectsWithTag("Rubble"); //Rubbleタグのオブジェクトを配列に格納
        //配列に入っているものをリスト化する
        foreach (GameObject obj in RubbleArray)
        {
            RubbleList.Add(obj);
        }
        RightMove.enabled = false;
        LeftMove.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        bool isCheckBossClear = bossModelChange.isCheckBossClear;
        if(isCheckBossClear == false && RunningChecker == false)
        {
            if(AttackControl == 0){
                StartCoroutine(RubbleAttack());//5秒後に瓦礫攻撃の関数を呼び出す
            }

            if(AttackControl == 1){
                StartCoroutine(BodyAttack());//５秒後に体当たりの関数を呼び出す
            }
        }
    }

    //瓦礫攻撃を呼び出す
    private IEnumerator RubbleAttack()
    {
        RunningChecker = true;
        yield return new WaitForSeconds(5);
        int cnt = 0;
        while(cnt < RubbleList.Count)
        {
            rubble = RubbleList[cnt].GetComponent<RubbleTree>();
            rubble.rbAttack();
            cnt++;
        }
        AttackControl = Random.Range(0,2);
        if(AttackControl == 0){
            AttackControl++;
        }    
    }

    //体当たり攻撃を呼び出す
    private IEnumerator BodyAttack()
    {
        RunningChecker = true;
        yield return new WaitForSeconds(5);
        Body();
        AttackControl = Random.Range(0,2);
        if(AttackControl == 1){
            AttackControl--;
        }
   
    }

    //体当たり攻撃
    public void Body()
    {
        int movePosition = Random.Range(4,6); //攻撃前モーション左右を判断する乱数生成
        //int bossModel = bossModelChange.bossModel;
        bool isCheckBossClear = bossModelChange.isCheckBossClear;
        if(isCheckBossClear == false){
            //右モーション
            if(movePosition == 4)
            {
                RightMove.enabled = true;
                mmPath.enabled = false;
                StartCoroutine(Wait());
            }
            //左モーション
            if(movePosition == 5)
            {
                LeftMove.enabled = true;
                mmPath.enabled = false;
                StartCoroutine(Wait());
            }
        }
    }

    //体当たりモーション
    private IEnumerator Wait()
    {
        bool isCheckBossClear = bossModelChange.isCheckBossClear;  
        if(isCheckBossClear == false)
        {
            yield return new WaitForSeconds(2);
            GameObject target = GameObject.Find("Rectangle");
            endPos = target.transform.position;
            StartCoroutine(GotoTargetM(0.5f));
            mmPath.enabled = true;
            RunningChecker = false;
        }
        
    }

    IEnumerator GotoTargetM(float t) //引数:t秒でクリックした座標に移動する関数
    {
        float duration = t;     //移動にかける時間    
        float currentTime = 0;  //経過時間を初期化
        startPos = transform.position;      //移動開始位置 
        bool isCheckBossClear = bossModelChange.isCheckBossClear;  
        //指定した時間を越えない間、以下の処理を繰り返す
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;      // 経過時間を更新
            float p = currentTime / duration;   //経過時間の割合を算出
            transform.position = Vector3.Lerp(startPos, endPos, p); //座標更新
            yield return null;                  //1フレームスキップ
        }
    }
}
