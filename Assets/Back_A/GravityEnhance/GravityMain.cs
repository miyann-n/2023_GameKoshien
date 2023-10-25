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
            if(isCheckKey2 == false){
                isCheckKey2 = true;
                Debug.Log("選択");
            }
        }

        if(Input.GetKey(KeyCode.E) && isCheckKey2){
            //変数2の切り替え
                if(isCheckKeyE){
                    isCheckKeyE = false;
                    Debug.Log("停止");
                }
                else{
                    isCheckKeyE = true;
                    Debug.Log("起動");
                }

            }

    }
}
