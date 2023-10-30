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
            a = 0;
        }
        // 2 �L�[�������ꂽ��
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            // �摜��؂�ւ��܂�
            a = 1;
        }
        // 3 �L�[�������ꂽ��
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            // �摜��؂�ւ��܂�
            a = 2;
        }
        // 4 �L�[�������ꂽ��
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            // �摜��؂�ւ��܂�
            a = 3;
        }

       //�}�E�X�z�C�[���̈ړ��ʂ𑫂�
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