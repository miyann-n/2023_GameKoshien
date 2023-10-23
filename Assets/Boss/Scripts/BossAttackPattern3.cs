using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackPattern3 : MonoBehaviour
{
    public int AttackControl;
    private BossModelChangeTree bossModelChange; //bossmodelchangeスクリプト
    private RubbleTree rubble;
    public List<GameObject> RubbleList;
    public GameObject[] RubbleArray;
    //private MiniBoss miniboss;
    //public List<GameObject> MiniBossList;
    //public GameObject[] MiniBossArray;
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
        AttackControl = Random.Range(0,2);
        //AttackControl = 0;
        bossModelChange = GameObject.Find("RetroBlobDash").GetComponent<BossModelChangeTree>();
        RubbleArray = GameObject.FindGameObjectsWithTag("Rubble");
        foreach (GameObject obj in RubbleArray)
        {
            RubbleList.Add(obj);
        }
        //miniboss = GameObject.Find("MiniBoss").GetComponent<MiniBoss>();
        /*MiniBossArray = GameObject.FindGameObjectsWithTag("MiniBoss");
        foreach (GameObject obj in MiniBossArray)
        {
            MiniBossList.Add(obj);
        }*/
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

            /*if(AttackControl == 2){
                StartCoroutine(Summon());//5秒後にボス小召喚の関数を呼び出す
            }*/
        }
    }

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

    /*private IEnumerator Summon()
    {
        RunningChecker = true;
        yield return new WaitForSeconds(5);
        int cnt = 0;
        while(cnt < MiniBossList.Count)
        {
            miniboss = MiniBossList[cnt].GetComponent<MiniBoss>();
            miniboss.SmAttack();
            cnt++;
        }
        //miniboss.SmAttack(); 
        AttackControl = Random.Range(0,2);
        if(AttackControl == 2){
            AttackControl--;
        }      
    }*/

    public void Body()
    {
        int movePosition = Random.Range(4,6);
        //int bossModel = bossModelChange.bossModel;
        bool isCheckBossClear = bossModelChange.isCheckBossClear;
        if(isCheckBossClear != true){
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
