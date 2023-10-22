using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackPattern : MonoBehaviour
{
    public int AttackControl;
    private BossModelChange bossModelChange; //bossmodelchangeスクリプト
    private Rubble rubble;
    private MiniBoss miniboss;
    [SerializeField] private MonoBehaviour RightMove;
    [SerializeField] private MonoBehaviour LeftMove;
    [SerializeField] private MonoBehaviour mmPath;
    public bool RunningChecker = false;
    private bool boddyAttackChecker = false;
    Vector3 startPos;   //初めの場所
    Vector3 endPos;     //向かう場所
    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        AttackControl = Random.Range(0,3);
        
        bossModelChange = GameObject.Find("RetroBlobDash").GetComponent<BossModelChange>();
        rubble = GameObject.Find("BossRubble").GetComponent<Rubble>();
        miniboss = GameObject.Find("MiniBoss").GetComponent<MiniBoss>();
        RightMove.enabled = false;
        LeftMove.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        bool isCheckBossClear = bossModelChange.isCheckBossClear;
        //Debug.Log(isCheckBossClear);

       if(isCheckBossClear == false && RunningChecker == false)
       {
            if(AttackControl == 0){
                StartCoroutine(RubbleAttack());//5秒後に瓦礫攻撃の関数を呼び出す
            }

            if(AttackControl == 1){
                StartCoroutine(BodyAttack());//５秒後に体当たりの関数を呼び出す
            }

            if(AttackControl == 2){
                StartCoroutine(Summon());//5秒後にボス小召喚の関数を呼び出す
            }
        }
    }

    private IEnumerator RubbleAttack()
    {
        RunningChecker = true;
        yield return new WaitForSeconds(10);
        rubble.rbAttack();
        AttackControl = Random.Range(0,3);
        if(AttackControl == 0){
            AttackControl++;
        }    
    }
    private IEnumerator BodyAttack()
    {
        RunningChecker = true;
        yield return new WaitForSeconds(10);
        Body();
        AttackControl = Random.Range(0,3);
        if(AttackControl == 1){
            AttackControl++;
        }
   
    }

    private IEnumerator Summon()
    {
        RunningChecker = true;
        yield return new WaitForSeconds(10);
        miniboss.SmAttack(); 
        AttackControl = Random.Range(0,3);
        if(AttackControl == 2){
            AttackControl--;
        }      
    }

    public void Body()
    {
        int movePosition = Random.Range(4,6);
        int bossModel = bossModelChange.bossModel;
        if(bossModel != 2){
            if(movePosition == 4)
            {
                RightMove.enabled = true;
                mmPath.enabled = false;
                StartCoroutine(Wait());
            }
            if(movePosition == 5)
            {
                LeftMove.enabled = true;
                mmPath.enabled = false;
                StartCoroutine(Wait());
            }
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        boddyAttackChecker = true;
        GameObject target = GameObject.Find("Rectangle");
        endPos = target.transform.position;
        StartCoroutine(GotoTargetM(1));
        mmPath.enabled = true;
        RunningChecker = false;
    }

    IEnumerator GotoTargetM(float t) //引数:t秒でクリックした座標に移動する関数
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
}
