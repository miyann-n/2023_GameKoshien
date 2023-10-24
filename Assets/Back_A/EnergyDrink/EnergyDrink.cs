using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyDrink : MonoBehaviour
{
    //public Player player;(プレイヤーについてるスクリプトの取得)
    public float HitPoint;
    private bool ischeckGet;
    public GetControlEnergyDrink gcEnergyDrink;
    [SerializeField] GameObject proxcube;
 
    // Start is called before the first frame update
    void Start()
    {
        HitPoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
       ischeckGet = gcEnergyDrink.getEnDrink;
       Debug.Log(ischeckGet);

       if(HitPoint < 10 && ischeckGet){
           Debug.Log("来てるよ");
               /*player.MaxHitPoint = player.MaxHitPoint + 1;
               (新しい体力上限値＝元の体力上限値+1)*/
               Destroy(this.gameObject);
            }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag =="Player"){
            proxcube.SetActive(true);
            Debug.Log("OK");
        }
    }

        private void OnCollisionExit2D(Collision2D collision){
        if(collision.gameObject.tag =="Player"){
            proxcube.SetActive(false);
            Debug.Log("OUt");
        }
    }
}
