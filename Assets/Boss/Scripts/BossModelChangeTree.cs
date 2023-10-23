using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossModelChangeTree : MonoBehaviour
{
    public int bossHelth = 10; //ボス体力
    public bool isCheckBossClear = false; //クリアの状態
    Animator animator;
    [SerializeField] private MonoBehaviour mmPath;
    [SerializeField] private BoxCollider2D boxcolli;
    public BossAttackPattern3 bossAttackPattern;
    Vector3 startPos;   //初めの場所
    Vector3 endPos;     //向かう場所

    
    // Start is called before the first frame update
    void Start()
    {
        bossAttackPattern = GameObject.Find("RetroBlobDash").GetComponent<BossAttackPattern3>();
        animator = GetComponent<Animator>(); 
        animator.SetBool("break", false); 
    }

    // Update is called once per frame
    void Update()
    {
        if(isCheckBossClear == false){
            //外殻に計６ダメージ与えられた時
            /*if(i * 6 == bossHelth){
                animator.SetBool("break", true);
                bossModel = 1;
            }
            //外殻なしに計６ダメージ与えられた時
            if(i * 6 == bossCoreHelth){
                animator.SetBool("break", false);
                bossModel = 0;
                i -= 1;
            }
            //スタン状態になった時
            if(bossCoreHelth == 0){
                mmPath.enabled = false;
                //boxcolli.enabled = false;
                animator.SetBool("stan", true);
                animator.SetBool("break", true);
                bossModel = 2;
                bossCoreStan.Stan();
                StartCoroutine(DelayCoroutine());
                bossHelth = 6;
                bossCoreHelth = 1;
                i = 0;   
            }
        }
        else
        {
            animator.SetBool("death", true); //ボス死亡
        }*/
        /*if(bossAttackPattern.AttackControl == 2){
            animator.SetBool("houkou", true);
        }else if(bossAttackPattern.AttackControl != 2){
            animator.SetBool("houkou", false);
        }*/
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            SpaceInput();
        }
    }
    }

    //20秒間待つ
    /*private IEnumerator DelayCoroutine()
    {
        yield return new WaitForSeconds(20);
        bossAttackPattern.RunningChecker = false;
        animator.SetBool("stan", false);
        animator.SetBool("break", false);
        bossModel = 0;
        mmPath.enabled = true;
        //boxcolli.enabled = true;
        yield break;
    }*/

    public void Clear()
    {
      StartCoroutine(GotoTargetR(5));
      isCheckBossClear = true;
      boxcolli.enabled = false;
      Debug.Log(isCheckBossClear);
      Destroy(gameObject);
    }

    public void SpaceInput()
    {
        bossHelth -= 1;
        if(bossHelth < 1){
            Clear();
        }
    }   
        
    IEnumerator GotoTargetR(float t)    //引数:t秒で指定した場所へ移動する関数
    {
        float duration = t;     //移動にかける時間（引数:t）   
        float currentTime = 0;  //経過時間を初期化
        startPos = transform.position;     //移動開始位置
        endPos =  new Vector3(1,2,5);     //向かう場所を指定
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
