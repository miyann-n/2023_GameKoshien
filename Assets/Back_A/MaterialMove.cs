using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialMove : MonoBehaviour
{
    public bool isCheckAbilityWake;
    public bool isCheckObjectMove;


    // Start is called before the first frame update
    void Start()
    {
        isCheckAbilityWake = false;

        isCheckObjectMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E)) {
            if (isCheckAbilityWake == false) {
                isCheckAbilityWake = true;
            }
            else {
                isCheckAbilityWake = false;
            }

            /*if(isCheckAbilityWake){
            //障害物（小）のハイライトさせる処理
            
                if (isCheckObjectMove == true) {
                //マウスのカーソルに追従させる処理(X方向)
                }

            }
            else{
            //障害物（小）のハイライトをやめる処理
            }*/
        }
    }
    
       
}
