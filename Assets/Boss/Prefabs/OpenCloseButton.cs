using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class OpenCloseButton : MonoBehaviour
{
    [SerializeField] GameObject Button;

    void Update()
    {
        //[M]キーを押す
        if (Input.GetKeyDown(KeyCode.M))
        {
            //ゲームオブジェクト非表示→表示
            Button.SetActive(true);
        }
    }
}