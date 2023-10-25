using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            Scene scene = SceneManager.GetSceneByName("Area2-3");
            SceneManager.LoadSceneAsync("Area2-3",LoadSceneMode.Additive); //"シーンの名前"   
            if (!scene.isLoaded) Debug.Log("noLoad");
            if (scene.isLoaded) Debug.Log("Load");
            //wait(scene);
            StartCoroutine(wait(scene));
            if (!scene.isLoaded) Debug.Log("noLoad");
            if (scene.isLoaded) Debug.Log("Load");

            SceneManager.UnloadSceneAsync("Area2-5");
           //SceneManager.sceneLoaded += GameSceneLoaded; 
            this.transform.position = new Vector2(-40, -5); // 2dならvector2？
            Debug.Log(SceneManager.GetActiveScene().name);
        }
    }
    IEnumerator wait(Scene scene)
    {
        Debug.Log("OK");
        while (!scene.isLoaded)
        {
            Thread.Sleep(50);
        }
        if (!scene.isLoaded) Debug.Log("noLoad");
        if (scene.isLoaded) Debug.Log("Load");
        Scene newScene = SceneManager.GetSceneAt(1);
        SceneManager.SetActiveScene(newScene);
        yield break;
    }
}
