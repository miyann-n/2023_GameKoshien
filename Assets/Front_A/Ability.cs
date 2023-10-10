using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ability : MonoBehaviour
{

    public Sprite newSpriteMove;
    public Sprite newSpriteJump;
    public Sprite newSpriteReverse;
    public Sprite newSpritenomal;
    private Image image;

    float a;
    int b;

    // Use this for initialization
    void Start()
    {
        a = 0;
        b = 0;
        // SpriteRendererコンポーネントを取得します
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        // 1 キーが押された時
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // 画像を切り替えます
            a = 0;
        }
        // 2 キーが押された時
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            // 画像を切り替えます
            a = 1;
        }
        // 3 キーが押された時
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            // 画像を切り替えます
            a = 2;
        }
        // 4 キーが押された時
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            // 画像を切り替えます
            a = 3;
        }

       //マウスホイールの移動量を足す
        a += Input.mouseScrollDelta.y;
        
        b = (int )a % 4;
     
        if (b == 0)
        {
            image.sprite = newSpritenomal;
        }
        if (b == 1)
        {
            image.sprite = newSpriteMove;
        }
        if (b == 2)
        {
            image.sprite = newSpriteJump;
        }
        if (b == 3)
        {
            image.sprite = newSpriteReverse;
        }
    }
}