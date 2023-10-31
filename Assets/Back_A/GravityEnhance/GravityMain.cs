using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityMain : MonoBehaviour
{
    public bool isCheckKey2;
    public bool isCheckKeyE;
    public MaterialMove materialMove;
    public GravityReversalPlayer grPlayer;
    public GravityClickCharactor gcCharactor;
    // Start is called before the first frame update
    void Start()
    {
        isCheckKey2 = false;
        isCheckKeyE = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2)|Input.GetKeyDown(KeyCode.Keypad2)){
            SelectAbilityGE();
        }

        if(Input.GetKeyDown(KeyCode.E) && isCheckKey2){
            AbilityOnOffGE();
        }
    }

    private void SelectAbilityGE(){ //2が押されたときに重力増強の選択フラグを上げる
        //変数1の切り替え
        if(isCheckKey2 == false){
            isCheckKey2 = true;
            Debug.Log("選択");
            materialMove.isCheckKey1 = false;
            grPlayer.isCheckKey3 = false;
        }
    }

    private void AbilityOnOffGE(){ //Eが押された時に像力増強の起動フラグを上げ下げする

        //変数2の切り替え
        if(isCheckKeyE && gcCharactor.isCheckCanBigObject != true){
            isCheckKeyE = false;
            Debug.Log("重力増強停止");
        }
        else{
            isCheckKeyE = true;
            Debug.Log("重力増強起動");
        }

    }

}
