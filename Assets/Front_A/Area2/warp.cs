using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class warp : MonoBehaviour
{
    public GameObject player;
   // public string a;
    // Start is called before the first frame update
    void Start()
    {
        
        player = GameObject.FindWithTag("Player");
      //  Object.DontDestroyOnLoad(this.player);
    }

    // Update is called once per frame
    void Update()
    {
          
    }

    //エリア移動処理
    public void OnTriggerEnter2D(Collider2D other)
    {
      //  a = "Area2-5";
        
        SceneManager.LoadSceneAsync("Area2-3", LoadSceneMode.Additive); //"シーンの名前"
                                                                        //SceneManager.sceneLoaded += GameSceneLoaded; 
        SceneManager.UnloadSceneAsync("Area2-5");
     


    }   

        void GameSceneLoaded(Scene next, LoadSceneMode mode)
        { 
      //  var player = GameObject.FindWithTag("Player");
        if (player == null) { Debug.Log(" null"); }
        player.transform.position = new Vector2(-40, -5); // 2dならvector2？
        Debug.Log(SceneManager.GetActiveScene().name);
            SceneManager.sceneLoaded -= GameSceneLoaded;
        }


}

