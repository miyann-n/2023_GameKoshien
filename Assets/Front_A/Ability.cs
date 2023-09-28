using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Ability : MonoBehaviour
{

    public Sprite newSpriteMove;
    public Sprite newSpriteJump;
    public Sprite newSpriteReverse;
    private Image image;


    // Use this for initialization
    void Start()
    {
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
            image.sprite = newSpriteMove;
        }
        // 2 キーが押された時
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            // 画像を切り替えます
            image.sprite = newSpriteJump;
        }
        // 3 キーが押された時
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            // 画像を切り替えます
            image.sprite = newSpriteReverse;
        }
    }
}