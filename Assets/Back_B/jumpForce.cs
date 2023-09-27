using UnityEngine;

public class jamp : MonoBehaviour
{
    public bool isItemACollected = false; // 変数1: アイテムAを獲得しているかどうかを判定するbool型の変数 (デフォルトでfalse)
    public float jumpSpeed; // 変数2: ジャンプのスピードを設定する変数
    public float B = 1.0f; // 値Bを保持する変数(いらないやつ)

    void Update()
    {
        // 変数1がtrueなら
        if (isItemACollected)
        {
            // 値B(ジャンプ力)を変数2 * 1.5 * Vector2.up
            B = jumpSpeed * 1.5f * Vector2.up.y;
        }
        else
        {
            // 変数1がfalseなら、値B(ジャンプ力)を変数2 * Vector2.up
            B = jumpSpeed  * Vector2.up.y;
        }

        // 値Bをデバッグコンソールに出力する
         if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("Zキーが押されました。値B: " + B);
        }


        
    }
}
