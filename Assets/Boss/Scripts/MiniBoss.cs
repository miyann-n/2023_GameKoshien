using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBoss : MonoBehaviour
{
    private BossModelChange bossModelChange; //bossmodelchangeスクリプト
    private BossAttackPattern bossAttackPattern; //bossattackpatternスクリプト
    private float PositionX;
    public int MiniBossHelth = 3;
    [SerializeField] private BoxCollider2D boxcolli;
    [SerializeField] private MonoBehaviour stomp;
    [SerializeField] private SpriteRenderer sp;
    [SerializeField] private MonoBehaviour CharaMove;
    [SerializeField] private MonoBehaviour HorizontalMove;
    void Start()
    {
        bossModelChange = GameObject.Find("RetroBlobDash").GetComponent<BossModelChange>();
        bossAttackPattern = GameObject.Find("RetroBlobDash").GetComponent<BossAttackPattern>();
        Vector3 posi = this.transform.localPosition; //オブジェクトの初期位置の取得
        sp.enabled = false; //隠す
        CharaMove.enabled = false;
        boxcolli.enabled = false;
        stomp.enabled = false;
        PositionX = this.transform.localPosition.x;
    }

    // Update is called once per frame
    void Update()//ダメージ処理
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            SpaceInput();
        }
    }

    public void SmAttack()
    {
        Vector3 posi = this.transform.localPosition;
        //Debug.Log(posi.y);
        int bossModel = bossModelChange.bossModel;
        if(bossModel != 2){
            posi = new Vector3(PositionX, posi.y, posi.z);
            this.transform.localPosition = posi; 
            sp.enabled = true;
            CharaMove.enabled = true;
            boxcolli.enabled = true;
            stomp.enabled = true;
            bossAttackPattern.AttackControl = Random.Range(0,3);
            if(bossAttackPattern.AttackControl == 2){
                bossAttackPattern.AttackControl--;
            } 
        }
        bossAttackPattern.RunningChecker = false;
    }

    public void SpaceInput() //ダメージ処理
    {
        if(MiniBossHelth > 1) //体力減少
        {
            MiniBossHelth -= 1;
        }else
        {
            HorizontalMove.enabled = false; //横移動を非アクティブ
            boxcolli.enabled = false;
            //HorizontalMove.enabled = false;
            sp.enabled = false; //隠す
            MiniBossHelth = 3;
        }
        
    } 
}
