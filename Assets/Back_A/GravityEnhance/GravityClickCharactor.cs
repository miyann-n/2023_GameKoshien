using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityClickCharactor : MonoBehaviour
{
    public float PlayerNormalDamage;
    public bool isCheckCanBigObject;
    public GravityMain gravityMain;

    SpriteRenderer spriteRenderer;
    //・ここでプレイヤーの与ダメージについて規定するスクリプトの取得

    // Start is called before the first frame update
    void Start()
    {   
        spriteRenderer = GameObject.FindWithTag("BigObject").GetComponent<SpriteRenderer>();
        isCheckCanBigObject = false;
    }

    // Update is called once per frame

    public void GravityEnhance(){
        if(gravityMain.isCheckKeyE){
            //（与ダメを規定するスクリプトの変数）= 2;
             isCheckCanBigObject = true;
             Debug.Log("ダメージ = 2 & 大障害物動かせる");
             ResetDamage();
             
        }
    }


    private void ResetDamage(){
        //(与ダメを規定するスクリプトの変数) = 1;
        isCheckCanBigObject = false;
        Debug.Log("ダメージ = 1 & 大障害物無理");
        spriteRenderer.material.color = new Color(1f,0f,0f);
    }

}
