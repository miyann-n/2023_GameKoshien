using System.Collections;
using System.Collections.Generic; 
using UnityEngine; 
public class MoveObject : MonoBehaviour 
{ 
    Vector3 mousePos, worldPos;
    Vector3 StartPos;
    Animator animator;
    private bool SkillCheck = false; 
    private bool ObMoveCheck = false; 
    private BossModelChange bossModelChange; //bossmodelchangeスクリプト
    private BossCoreStan bossCoreStan; //bossmodelchangeスクリプト

    void Start()
    {
        bossModelChange = GameObject.Find("RetroBlobDash").GetComponent<BossModelChange>();
        bossCoreStan = GameObject.Find("BossCoreStan").GetComponent<BossCoreStan>();
    }
    void Update() 
    { 
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
        if(SkillCheck == true)
        { 
            //マウス座標の取得 
            mousePos = Input.mousePosition;
            //スクリーン座標をワールド座標に変換 
            worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y,10f)); 
            //ワールド座標を自身の座標に設定 
            transform.position = worldPos;
        }

    } 
    
    // タッチされた時に呼ばれる関数 
    public void OnTouched() 
    { 
        bool isCheckBossClear = bossModelChange.isCheckBossClear;
        if(ObMoveCheck == true)
        { 
            SkillCheck = !SkillCheck;
            //Debug.Log(isCheckBossClear); 
        }
        if(SkillCheck == false){
            bossModelChange.Clear();
            animator.SetBool("death", true);
        }
    } 
}
