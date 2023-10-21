using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCoreStan : MonoBehaviour
{
    [SerializeField] private Animator animator; //animatorコンポーネント
    private BossModelChange bossModelChange; //bossmodelchangeスクリプト
    private bool MethodCheck = false; //メソッドstanが呼ばれたかどうか
    
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
      //ボスがスタンした時の処理
      if(MethodCheck == true){
        bossModelChange = GameObject.Find("RetroBlobDash").GetComponent<BossModelChange>();
        int bossModel = bossModelChange.bossModel;
        bool isCheckBossClear = bossModelChange.isCheckBossClear;
        if(bossModel == 2 && isCheckBossClear == false)
        {
          animator.SetBool("core", true);
        }
        else
        {
         animator.SetBool("core", false);
        }
      }
      
    }

    //ボスがスタンした時に呼び出される関数
    public void Stan()
    {
      animator.SetBool("core", true);
      MethodCheck = true;
      
    }

    private IEnumerator DelayCoroutine()
    {
        yield return new WaitForSeconds(20);
        //animator.SetBool("core", false);
    }
    
}
