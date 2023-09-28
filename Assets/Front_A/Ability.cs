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
        // SpriteRenderer�R���|�[�l���g���擾���܂�
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        // 1 �L�[�������ꂽ��
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // �摜��؂�ւ��܂�
            image.sprite = newSpriteMove;
        }
        // 2 �L�[�������ꂽ��
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            // �摜��؂�ւ��܂�
            image.sprite = newSpriteJump;
        }
        // 3 �L�[�������ꂽ��
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            // �摜��؂�ւ��܂�
            image.sprite = newSpriteReverse;
        }
    }
}