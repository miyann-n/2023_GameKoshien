using System.Collections;
using System.Collections.Generic;
<<<<<<< HEAD
using UnityEngine;
using UnityEngine.UI;
=======
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using JetBrains.Annotations;
>>>>>>> feature/back_B

public class MaterialMove : MonoBehaviour
{
    public bool isCheckKey1;
    public bool isCheckAbilityWake;
    public bool isCheckObjectChase;
    public bool roopStoper;
<<<<<<< HEAD
    public GravityMain gravityMain;
    /*public GravityClickCharactor gclickCharactor;*/
    public Player player;
=======

    public bool isNowOnHighLitht;
    public GravityMain gravityMain;
    /*public GravityClickCharactor gclickCharactor;*/
    private Energy energy;
>>>>>>> feature/back_B
    public GravityReversalPlayer grPlayer;
    
    


    // Start is called before the first frame update
    void Start()
    {
        isCheckKey1 = false;
        isCheckAbilityWake = false;
        isCheckObjectChase = false;
<<<<<<< HEAD
=======
        energy = GameObject.FindWithTag("Player").GetComponent<Energy>();
>>>>>>> feature/back_B
    }

    // Update is called once per frame
    void Update()
<<<<<<< HEAD
    {
=======
    {   
        float currentEnergy = energy.currentEnergy;
        string isCheckBigObjectMove = File.ReadAllText("Assets/Back_B/Scripts/Flags.txt");

>>>>>>> feature/back_B

        if(Input.GetKeyDown(KeyCode.Alpha1)){
            SelectAbilityMM();
        }
<<<<<<< HEAD
    
        if (Input.GetKeyDown(KeyCode.E) && isCheckKey1) {
            AbilityOnOffMM();
            HighLightMM();
=======
        if(Input.GetKeyDown(KeyCode.E) && isCheckKey1 && isNowOnHighLitht)
        {
            test();
            isNowOnHighLitht = false;
        }
        if (Input.GetKeyDown(KeyCode.E) && isCheckKey1 && currentEnergy >= 20 && isNowOnHighLitht == false) {
            AbilityOnOffMM();
            HighLightMM();
            Debug.Log("kantu");
            isNowOnHighLitht = true;
>>>>>>> feature/back_B
        }

    }

    
    private void SelectAbilityMM(){ //1が押された時に物体移動の選択フラグを上げる

        isCheckKey1 = true;
        Debug.Log("物体移動選択");
        gravityMain.isCheckKey2 = false;
        grPlayer.isCheckKey3 = false;
    }

    private void AbilityOnOffMM(){ //Eが押された時に物体移動の起動フラグを上げ下げする

        if (isCheckAbilityWake == false ) {
            isCheckAbilityWake = true;
        }
        else if(isCheckAbilityWake == true){
            isCheckAbilityWake = false;
        }

    }

<<<<<<< HEAD
    private void HighLightMM(){ //物体移動が起動した時に移動可能なオブジェクトをハイライトする
    
        if(isCheckAbilityWake && player.isCheckBigObjectMove == false){
=======
    public void HighLightMM(){ //物体移動が起動した時に移動可能なオブジェクトをハイライトする
    
        Debug.Log(isCheckAbilityWake);
        Debug.Log(energy.isCheckBigObjectMove);
        string isCheckBigObjectMove = File.ReadAllText("Assets/Back_B/Scripts/Flags.txt");

        if(isCheckAbilityWake  && isCheckBigObjectMove != "true" ){
>>>>>>> feature/back_B
            Debug.Log("物体移動起動");
            GameObject[] canmove= GameObject.FindGameObjectsWithTag("SmallObject");
            GameObject[] cannotmove= GameObject.FindGameObjectsWithTag("BigObject");
            foreach (GameObject obj in canmove){
                Renderer renderer = obj.GetComponent<SpriteRenderer>();
                renderer.material.color = new Color(0f/255f,255f/255f,0f/255f);
            }
            foreach (GameObject obj in cannotmove){
                Renderer renderer = obj.GetComponent<SpriteRenderer>();
                renderer.material.color = new Color(255f/255f,0f/255f,0f/255f);
            }
            Debug.Log("ハイライト中");
<<<<<<< HEAD
        }

        else if(isCheckAbilityWake && player.isCheckBigObjectMove == true){
=======
            energy.currentEnergy -= 20;
        }

        else if(isCheckAbilityWake && isCheckBigObjectMove == "true"){
>>>>>>> feature/back_B
            Debug.Log("物体移動起動");
            GameObject[] canmove= GameObject.FindGameObjectsWithTag("SmallObject");
            GameObject[] cannotmove= GameObject.FindGameObjectsWithTag("BigObject");
            foreach (GameObject obj in canmove){
                Renderer renderer = obj.GetComponent<SpriteRenderer>();
                renderer.material.color = new Color(0f/255f,255f/255f,0f/255f);
            }
            foreach (GameObject obj in cannotmove){
                Renderer renderer = obj.GetComponent<SpriteRenderer>();
                renderer.material.color = new Color(0f/255f,255f/255f,0f/255f);
            }
            Debug.Log("ハイライト中");
        }
<<<<<<< HEAD

        else{
=======
    }
        private void test() {
>>>>>>> feature/back_B
            isCheckObjectChase = false;
            GameObject[] canmove= GameObject.FindGameObjectsWithTag("SmallObject");
            GameObject[] cannotmove= GameObject.FindGameObjectsWithTag("BigObject");
            foreach (GameObject obj in canmove){
                Renderer renderer = obj.GetComponent<SpriteRenderer>();
                renderer.material.color = new Color(255f/255f,255f/255f,255f/255f);
            }
            foreach (GameObject obj in cannotmove){
                Renderer renderer = obj.GetComponent<SpriteRenderer>();
                renderer.material.color = new Color(255f/255f,255f/255f,255f/255f);
            }             
            Debug.Log("物体移動中止");
        }

<<<<<<< HEAD
    }
=======
>>>>>>> feature/back_B


}
