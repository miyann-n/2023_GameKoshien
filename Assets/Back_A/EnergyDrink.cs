using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyDrink : MonoBehaviour
{
    //public Player player;(プレイヤーについてるスクリプトの取得)
    public float HitPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag =="Player"){
            if(HitPoint < 10){
                /*player.MaxHitPoint = player.MaxHitPoint + 1;
                (新しい体力上限値＝元の体力上限値+1)*/
                Destroy(this.gameObject);
            }
        }
    }
}
