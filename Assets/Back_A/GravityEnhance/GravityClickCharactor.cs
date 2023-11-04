using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityClickCharactor : MonoBehaviour
{
    public float PlayerNormalDamage;
    public bool isCheckCanBigObject;
    public GravityMain gravityMain;
<<<<<<< HEAD
=======

    public bool isCharactorClicked;

    SpriteRenderer spriteRenderer;
>>>>>>> feature/back_B
    //・ここでプレイヤーの与ダメージについて規定するスクリプトの取得

    // Start is called before the first frame update
    void Start()
<<<<<<< HEAD
    {
        isCheckCanBigObject = false;
=======
    {   
        spriteRenderer = GameObject.FindWithTag("BigObject").GetComponent<SpriteRenderer>();
        isCheckCanBigObject = false;
        isCharactorClicked = false;
>>>>>>> feature/back_B
    }

    // Update is called once per frame

    public void GravityEnhance(){
        if(gravityMain.isCheckKeyE){
<<<<<<< HEAD
            /*
            （与ダメを規定するスクリプトの変数）= 2;
             */
             Debug.Log("ダメージ = 2");
             Invoke("ResetDamage",10f);
             
        }
    }

    private void ResetDamage(){
        /*
        (与ダメを規定するスクリプトの変数) = 1;
        */
        Debug.Log("ダメージ = 1 & 大障害物無理");
    }
=======
            //（与ダメを規定するスクリプトの変数）= 2;
             //isCheckCanBigObject = true;
             Debug.Log("ダメージ = 2" /*& 大障害物動かせる"*/);
             isCharactorClicked = true;
             Invoke("ResetDamage", 10f);
        }
    }


    private void ResetDamage(){
        //(与ダメを規定するスクリプトの変数) = 1;
        //isCheckCanBigObject = false;
        Debug.Log("ダメージ = 1 "/*& 大障害物無理*/);
        //spriteRenderer.material.color = new Color(1f,0f,0f);
    }

>>>>>>> feature/back_B
}
