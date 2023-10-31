using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Ability : MonoBehaviour
{

    public Energy energy;
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
        a = 3;
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
            energy.isMoveObjectSet = true;
            energy.isGravityIncreaseSet = false;
            energy.isGravityInversionSet = false;
            image.sprite = newSpriteMove;
        }
        if (b == 1)
        {
            energy.isMoveObjectSet = false;
            energy.isGravityIncreaseSet = true;
            energy.isGravityInversionSet = false;
            image.sprite = newSpriteJump; 

        }
        if (b == 2)
        {
            energy.isMoveObjectSet = false;
            energy.isGravityIncreaseSet = false;
            energy.isGravityInversionSet = true;
            image.sprite = newSpriteReverse;
        }
        if (b == 3)
        {
            energy.isMoveObjectSet = false;
            energy.isGravityIncreaseSet = false;
            energy.isGravityInversionSet = false;
            image.sprite = newSpritenomal;
        }

    }
}