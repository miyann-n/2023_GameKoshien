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
    public BossCoreStan bossCoreStan;
    
    // Start is called before the first frame update
    void Start()
    {
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
            //死亡した時の処理
        }
    }

    //20秒間待つ
    private IEnumerator DelayCoroutine()
    {
        yield return new WaitForSeconds(20);
        animator.SetBool("stan", false);
        animator.SetBool("break", false);
        bossModel = 0;
        mmPath.enabled = true;
        yield break;
    }
}
