using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialMove : MonoBehaviour
{
    public bool isCheckKey1;
    public bool isCheckAbilityWake;
    public bool isCheckObjectMove;
    public bool isCheckObjectChase;
    public bool roopStoper;
    private int eKeyPressCount;
    public Outline outline;//ハイライトを行うスクリプトの取得
    


    // Start is called before the first frame update
    void Start()
    {
        isCheckKey1 = false;
        isCheckAbilityWake = false;
        isCheckObjectMove = false;
        isCheckObjectChase = false;
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKey(KeyCode.Alpha1)){
            isCheckKey1 = true;
            Debug.Log("物体移動選択");
        }
    
        if (Input.GetKey(KeyCode.E) && isCheckKey1) {

            if (isCheckAbilityWake == false ) {
                isCheckAbilityWake = true;
            }
            else{
                isCheckAbilityWake = false;
            }

            if(isCheckAbilityWake){
                Debug.Log("起動");
                //outline.enabled = true;　(ハイライト処理を行う)
                Debug.Log("ハイライト中");
            }
            else{
                isCheckAbilityWake = false;
                isCheckObjectMove = false;
                isCheckObjectChase = false;
                //outline.enabled = false;　(ハイライト処理を終了する)
                Debug.Log("中止");
            }



        }

        if (isCheckObjectMove == true) {

            isCheckObjectChase = true;
            Debug.Log("物体移動");

        }




    }
}
