using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class OpenMap : MonoBehaviour
{
    [SerializeField] GameObject Button;
    private bool showMap = false;

    void Update()
    {
        //[M]キーを押す
        if (Input.GetKeyDown(KeyCode.M))
        {
            if(showMap == false)
            {
                //ゲームオブジェクト非表示→表示
                Button.SetActive(true);
                showMap = !showMap;
            }
            else if(showMap == true)
            {
                //ゲームオブジェクト表示→非表示
                Button.SetActive(false);
                showMap = !showMap;
            }

        }
    }
}