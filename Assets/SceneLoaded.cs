using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoade : MonoBehaviour
{
    // 移動先のシーン名をここに設定
    public string sceneToLoad;

    // シーン移動の遅延時間を設定
    public float delayInSeconds = 5f;

    void Start()
    {
        // delayInSeconds秒後に指定のシーンに移動する
        Invoke("LoadScene", delayInSeconds);
    }

    void LoadScene()
    {
        // シーンを移動
        SceneManager.LoadScene(sceneToLoad);
    }
}
