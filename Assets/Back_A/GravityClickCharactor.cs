using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityClickCharactor : MonoBehaviour
{
    public float PlayerNormalDamage;
    public bool isCheckCanBigObject;
    public GravityMain gravityMain;
    //・ここでプレイヤーの与ダメージについて規定するスクリプトの取得

    // Start is called before the first frame update
    void Start()
    {
        isCheckCanBigObject = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(gravityMain.isCheckKeyE){
            /*
            （与ダメを規定するスクリプトの変数）= 2;
             isCheckCanBigObject = true;
             Invoke(nameof(ResetDamage),10f);
             */
        }
    }

    private void ResetDamage(){
        /*
        (与ダメを規定するスクリプトの変数) = 1;
        isCheckCanBigObject = false;
        */
    }
}
