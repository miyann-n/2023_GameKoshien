using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialMove : MonoBehaviour
{
    public bool isCheckKey1;
    public bool isCheckAbilityWake;
    public bool isCheckObjectChase;
    public bool roopStoper;
    public GravityMain gravityMain;
    /*public GravityClickCharactor gclickCharactor;*/
    public Player player;
    public GravityReversalPlayer grPlayer;
    
    


    // Start is called before the first frame update
    void Start()
    {
        isCheckKey1 = false;
        isCheckAbilityWake = false;
        isCheckObjectChase = false;
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Alpha1)){
            SelectAbilityMM();
        }
    
        if (Input.GetKeyDown(KeyCode.E) && isCheckKey1) {
            AbilityOnOffMM();
            HighLightMM();
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

    private void HighLightMM(){ //物体移動が起動した時に移動可能なオブジェクトをハイライトする
    
        if(isCheckAbilityWake && player.isCheckBigObjectMove == false){
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
        }

        else if(isCheckAbilityWake && player.isCheckBigObjectMove == true){
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

        else{
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

    }


}
