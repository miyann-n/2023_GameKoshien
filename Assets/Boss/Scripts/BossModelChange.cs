using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossModelChange : MonoBehaviour
{
    public int bossHelth = 18; //ボス体力
    public int bossCoreHelth = 18; //ボスコア体力
    public int i = 2; //体力の変化チェッカー
    public int bossModel = 0; //ボスの状態
    public bool isCheckBossClear = false; //クリアの状態
    Animator animator;
    [SerializeField] private MonoBehaviour mmPath;
    [SerializeField] private BoxCollider2D boxcolli;
    public BossCoreStan bossCoreStan;
    public BossAttackPattern bossAttackPattern;
    
    // Start is called before the first frame update
    void Start()
    {
        bossAttackPattern = GameObject.Find("RetroBlobDash").GetComponent<BossAttackPattern>();
        animator = GetComponent<Animator>(); 
        animator.SetBool("break", false); 
    }

    // Update is called once per frame
    void Update()
    {
        if(isCheckBossClear == false){
            //外殻に計６ダメージ与えられた時
            if(i * 6 == bossHelth){
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
        }
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

    //20秒間待つ
    private IEnumerator DelayCoroutine()
    {
        yield return new WaitForSeconds(20);
        bossAttackPattern.RunningChecker = false;
        animator.SetBool("stan", false);
        animator.SetBool("break", false);
        bossModel = 0;
        mmPath.enabled = true;
        //boxcolli.enabled = true;
        yield break;
    }

    public void Clear()
    {
      isCheckBossClear = true;
      boxcolli.enabled = false;
      Debug.Log(isCheckBossClear);
    }

    public void SpaceInput()
    {
        if(bossModel == 0){
            bossHelth -= 1;
        }
        if(bossModel == 1){
            bossCoreHelth -= 1;
        }
    }   
        
}
