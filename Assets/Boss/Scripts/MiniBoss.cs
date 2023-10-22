using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBoss : MonoBehaviour
{
    private BossModelChange bossModelChange; //bossmodelchangeスクリプト
    private BossAttackPattern bossAttackPattern; //bossattackpatternスクリプト
    private float PositionX = 7.25f;
    [SerializeField] private BoxCollider2D boxcolli;
    [SerializeField] private MonoBehaviour stomp;
    [SerializeField] private SpriteRenderer sp;
    [SerializeField] private MonoBehaviour CharaMove;
    void Start()
    {
        bossModelChange = GameObject.Find("RetroBlobDash").GetComponent<BossModelChange>();
        bossAttackPattern = GameObject.Find("RetroBlobDash").GetComponent<BossAttackPattern>();
        Vector3 posi = this.transform.localPosition; //オブジェクトの初期位置の取得
        sp.enabled = false; //隠す
        CharaMove.enabled = false;
        boxcolli.enabled = false;
        stomp.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Vector3 posi = this.transform.localPosition;
        if (other.gameObject.CompareTag("Player"))
        {
            boxcolli.enabled = false;
            sp.enabled = false; //隠す
            //bossAttackPattern.RunningChecker = false;
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
}
