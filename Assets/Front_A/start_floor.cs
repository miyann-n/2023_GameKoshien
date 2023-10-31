using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;
using CSVHundler;
/*
プログラム適用対象：プレイヤー
プログラム概要：
  warp2.csにて、前のシーンのシーン移動用オブジェクトと同じ名前とexitタグをもった空のオブジェクトを作成、DontDestroyOnLoadに追加している。
  そのためそこから使用した移動用オブジェクトの名前を取り出し、それを使って座標をtestというcsvファイルから見つけ出す。
  なおcsvファイルの整形については別建てで作成しているCSVHundler.csというプログラムを参照している。
  そちらの説明はそちらのプログラムで行っているため、要参照。

各クラス説明：
    Awake() 
        ->  Start()よりも先に実行される。
            CSVHundlerファイルのインスタンス化を行い、そのうちのCsvLoader()関数を呼び出している。
            これによって整形されたcsvファイルを入手し、sceneTableという変数に格納する。
    
    Start()
        ->  Awake()の次に実行される。
            エリア読み込み時にPlayerが生成されるため、そのたびに実行される。
            DontDestroyOnLoadで引き渡された、前回のシーンの移動用オブジェクトを入手し、その名前を取り出す。
            この時、前回の移動用オブジェクトがない場合は移動用オブジェクトにnullを格納し、名前を"null"と設定する。
            その後引き渡された移動用オブジェクトを削除し、Awake()で入手したcsvファイルの情報を参照。
            移動先のx,y座標を取り出してそこに移動させる。

    Coordinate(string[,] sceneTable,string exitName)
        return : {x座標,y座標}(float型の配列)
        ->  引数にはCSVHundlerで整形された二次元配列と前回シーンの移動用オブジェクト名が要求されている。
            この移動用オブジェクト名を使用してsceneTableから移動先のx,y座標を参照する。
            その後、{x座標,y座標}という形式のfloat型一次元配列を返す。
*/
public class start_floor : MonoBehaviour
{
    // Start is called before the first frame update
    
    string[,] sceneTable;
    GameObject exit;
    void Awake()
    {
        CSVHundler.CSVHundler csvhundler = new CSVHundler.CSVHundler("Assets/Front_A/test.csv");
        this.sceneTable = csvhundler.CsvLoader();
    }
    void Start()
    {
        try{this.exit = GameObject.FindWithTag("exit");}
        catch(Exception e){this.exit = null;}
        string exitName;
        try{exitName = this.exit.name;}//前のシーンの出口の名前
        catch(Exception e){exitName = "null";}
        Destroy(this.exit);
        float[] xy = Coordinate(sceneTable,exitName);
        Debug.Log(xy[0]);
        Debug.Log(xy[1]);
        GameObject player = GameObject.FindWithTag("Player");
        player.transform.position = new Vector2(xy[0], xy[1]);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    
    float[] Coordinate(string[,] sceneTable,string exitName){
        for(int i = 0;i < sceneTable.GetLength(0);i++){
            if(sceneTable[i,0] == exitName){
                return new float[]{float.Parse(sceneTable[i,2]),float.Parse(sceneTable[i,3])};
            }
        }
        return new float[]{(float)-79.79,(float)-5.0};
    }
}
