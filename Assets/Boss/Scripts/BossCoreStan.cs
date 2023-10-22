using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCoreStan : MonoBehaviour
{
    [SerializeField] private Animator animator; //animatorコンポーネント
    private BossModelChange bossModelChange; //bossmodelchangeスクリプト
    private BossAttackPattern bossAttackPattern; //bossmodelchangeスクリプト
    private bool MethodCheck = false; //メソッドstanが呼ばれたかどうか
    Vector3 bossPos; 
    
    // Start is called before the first frame update
    void Start()
    {
      bossModelChange = GameObject.Find("RetroBlobDash").GetComponent<BossModelChange>();
      bossAttackPattern = GameObject.Find("RetroBlobDash").GetComponent<BossAttackPattern>();
    }

    // Update is called once per frame
    void Update()
    {
      int bossModel = bossModelChange.bossModel;
      bool isCheckBossClear = bossModelChange.isCheckBossClear;
      
      //クリアの処理

      //ボスがスタンした時の処理
      if(MethodCheck == true){ 
        if(bossModel == 2 && isCheckBossClear == false)
        {
          bossPos = bossAttackPattern.transform.position;
          transform.position = bossPos;
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
    
}
