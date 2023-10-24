using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rubble : MonoBehaviour
{
    Rigidbody2D rd;
    [SerializeField] private SpriteRenderer sp;
     
    private BossModelChange bossModelChange; //bossmodelchangeスクリプト
    private BossAttackPattern bossAttackPattern; //bossattackpatternスクリプト
    private float PositionY = 3.5f;

    /*public List<GameObject> ObjctList = List<GameObject>();
    public GameObject ListObject;
    private int ObjectCount;*/
    
    void Start()
    {
        bossModelChange = GameObject.Find("RetroBlobDash").GetComponent<BossModelChange>();
        bossAttackPattern = GameObject.Find("RetroBlobDash").GetComponent<BossAttackPattern>();
        Vector3 posi = this.transform.localPosition; //瓦礫オブジェクトの初期位置の取得
        rd = this.GetComponent<Rigidbody2D>(); 
        rd.bodyType = RigidbodyType2D.Static; //重力を無効化
        sp.enabled = false; //隠す
    }

    /*void update()
    {
        GameObject ListObjects = GameObject.Instantiate(ListObject) as GameObject;// ListObjectsとしてプレファブを生成する
                ListObjects.transform.position = transform.position;// このオブジェクトの位置にプレファブの座標を移動させる
                ListObjects.transform.rotation = Quaternion.identity;// プレファブの向きを元のままにする
                ObjectList.Add(ListObjects);// リストにプレファブを加える
                ObjectCount += 1;
    }*/

    private void OnTriggerEnter2D(Collider2D other)
    {
        Vector3 posi = this.transform.localPosition;
        if (other.gameObject.CompareTag("Platform"))
        {
            posi = new Vector3(posi.x, PositionY, posi.z);
            this.transform.localPosition = posi;
            rd.bodyType = RigidbodyType2D.Static; //重力を無効化
            sp.enabled = false; //隠す
            bossAttackPattern.RunningChecker = false;
        }
    }

    public void rbAttack()
    {
        bossAttackPattern.RunningChecker = true;
        int bossModel = bossModelChange.bossModel;
        
        if(bossModel != 2){
            sp.enabled = true; //表示する
            rd.bodyType = RigidbodyType2D.Dynamic; //重力を有効化
        }
    }
}
