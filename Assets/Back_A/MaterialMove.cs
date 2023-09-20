using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialMove : MonoBehaviour
{
    public bool isCheckAbilityWake;
    public bool isCheckObjectMove;
    public bool isCheckObjectChase;
    public Outline outline;//ハイライトを行うスクリプトの取得
    


    // Start is called before the first frame update
    void Start()
    {
        isCheckAbilityWake = false;
        isCheckObjectMove = false;
        isCheckObjectChase = false;
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

            if(isCheckAbilityWake){
                outline.enabled = true;
            
                if (isCheckObjectMove == true) {
                    if (Input.GetMouseButtonDown(0)) {
                        isCheckObjectChase = true;
                    }
                }

            }
            else{
                outline.enabled = false;
            }
        }
    }
    
       
}
