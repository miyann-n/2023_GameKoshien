using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; // コレ重要

public class LastScene : MonoBehaviour 
{
    private string lastScene ; //現在のシーン

    public void CachScene () {
        lastScene = SceneManager.GetActiveScene().name;
        Debug.Log(lastScene);
    }

}
