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
    Vector3 mousePos, worldPos; 
    private bool SkillCheck = false; 
    private bool ObMoveCheck = false;
    
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
      /*if(ObMoveCheck == false && transform.position != bossPos){
        isCheckBossClear = true;
        Debug.Log("yyy");
      }*/

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
      if(Input.GetKeyDown(KeyCode.E))
      { 
        ObMoveCheck = !ObMoveCheck; 
        if(ObMoveCheck == true)
        { 
            GetComponent<Renderer>().material.color = Color.red; 
        }
        else
        { 
            GetComponent<Renderer>().material.color = Color.white; 
        } 
      } 
      /*if(SkillCheck == true)
      { 
        //マウス座標の取得 
        mousePos = Input.mousePosition;
        //スクリーン座標をワールド座標に変換 
        worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y,10f)); 
        //ワールド座標を自身の座標に設定 
        transform.position = worldPos;
        //Debug.Log(transform.position.x); 
      }*/
    }

    //ボスがスタンした時に呼び出される関数
    public void Stan()
    {
      //bossPos = bossAttackPattern.transform.position;
      //transform.position = bossPos;
      animator.SetBool("core", true);
      MethodCheck = true;
    }
    
}
