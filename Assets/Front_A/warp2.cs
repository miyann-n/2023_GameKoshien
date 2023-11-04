using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using CSVHundler;
/*
プログラム適用対象：プレイヤー
プログラム概要：
  warpタグのついたオブジェクトと接触した時点でオブジェクトの名前を取得。
  その後オブジェクト名そのままで、exitタグをつけた空のオブジェクトを生成し、DontDestroyOnLoad設定する。
  そしてcsvファイルから次のエリアのシーン名を取り出し、そこにシーン遷移を行う。

各関数説明：
    OnTriggerEnter2D()
        ->  オブジェクトと衝突したときに実行。
            初めに衝突対象が移動用オブジェクトであることを確認する。
            移動用オブジェクトであれば、同名かつ"exit"タグのついた空のオブジェクトを生成する。
            その後このオブジェクトをDontDestroyOnLoadに追加し、シーン遷移をする。
            なお、シーン遷移にはAdditiveではなくSingleを適用している。
    
    nextScene(string colliderName)
        return : 次のシーン名(string)
        ->  引数には衝突した移動用オブジェクトの名前を要求される。
            CSVHundlerを呼び出し、csvをCSVLoaderを使って整形した二次元配列を生成。
            それをつかって、同階かつ同名のオブジェクトからの移動先シーン名を抽出し、returnする。
*/

public class warp2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "warp")
        {        
            string colliderName = other.name;
            GameObject exit = new GameObject(colliderName);
            exit.tag = "exit";
            DontDestroyOnLoad(exit);
            SceneManager.LoadSceneAsync(nextScene(colliderName)); //"�V�[���̖��O"   
           // 2d�Ȃ�vector2�H
            Debug.Log(SceneManager.GetActiveScene().name);
        }
    }
    string nextScene(string colliderName){
        CSVHundler.CSVHundler csvhundler = new CSVHundler.CSVHundler("Assets/Front_A/test.csv");
        string[,] sceneTable = csvhundler.CsvLoader();
        for(int i = 0;i < sceneTable.GetLength(0);i++){
            if(sceneTable[i,0] == colliderName){
                if(sceneTable[i,4] == SceneManager.GetActiveScene().name){
                    return sceneTable[i,1];
                }
            }
        }
        return "null";
    }
}
