using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenechange : MonoBehaviour
{
    public string LoadScene;
    // Start is called before the first frame update
    public void BtnOnClick()
    {
        SceneManager.LoadScene(LoadScene);
    
    }
}
