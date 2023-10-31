using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;
/*
依存関係：
start_floor.cs , warp2.cs

プログラム概要：
  csvファイルをプログラムで使用しやすい二次元配列に整形するプログラム。
  初めにファイルを一つのstring形式のデータに変換し、
  その後Split関数を使って行ごと、要素ごとの二次元配列にする。
  データ形式とその例はいかに記載

データ形式：
    {{棒のオブジェクト名,移動先シーン名,移動先x座標,移動先y座標,移動元シーン名}}(string型二次元配列)

データ例：
    {{棒のオブジェクト名,移動先シーン名,移動先のx座標,移動先のy座標,移動元シーン名},
     {Platform1000x100 (62),Area2-3,-44,-5,Area2-5}}

各関数説明：
    CSVHundler()
        ->  コンストラクタ。コンストラクタが何かわからなければ各自調べること。
            ファイルパスからcsvファイルをstring形式のデータに変換している。
    
    CsvLoader()
        ->  string形式のcsvファイルデータを上記のデータ形式に整形し、returnする。
*/
namespace CSVHundler{
    public class CSVHundler : MonoBehaviour
    {
        // Start is called before the first frame update
        string data;
        public CSVHundler(string path){
            this.data = File.ReadAllText(path);
        }
        
        public string[,] CsvLoader(){
        string[] csvSplitOne =  Regex.Split(this.data,Environment.NewLine);
        string[,] csvList = new string [csvSplitOne.Length - 1,5];
        for(int i = 1;i < csvSplitOne.Length;i++){
           string[] csvLine = csvSplitOne[i].Split(',');
            for(int j = 0;j < 5;j++){
                csvList[i - 1,j] = csvLine[j];
            }
        }
        return csvList;
    }
    
    }
}