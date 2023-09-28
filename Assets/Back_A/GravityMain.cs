using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityMain : MonoBehaviour
{
    public bool isCheckKey2;
    public bool isCheckKeyE;
    // Start is called before the first frame update
    void Start()
    {
        isCheckKey2 = false;
        isCheckKeyE = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey (KeyCode.Alpha2)|Input.GetKey (KeyCode.Keypad2)){
            //変数1の切り替え
            if(isCheckKey2){
                isCheckKey2 = false;
            }
            else{
                isCheckKey2 = true;
            }

            if(Input.GetKey (KeyCode.E)){
            //変数2の切り替え
                if(isCheckKeyE){
                    isCheckKeyE = false;
                }
                else{
                    isCheckKeyE = true;
                }

            }
        }
    }
}
