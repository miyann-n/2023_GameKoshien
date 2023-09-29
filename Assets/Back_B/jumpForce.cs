using UnityEngine;
using System.Collections;
using MoreMountains.Tools;
using MoreMountains.Feedbacks;
using UnityEngine.Serialization;

namespace MoreMountains.CorgiEngine
{

    public class jumpForce : MonoBehaviour
    {
        public bool isItemACollected = false;
        public float jumpSpeed;

        // CharacterJumpからジャンプ力を取得するプロパティ
        private float JumpHeight
        {
            get
            {
                if (isItemACollected)
                {
                    return jumpSpeed * 1.5f * Vector2.up.y;
                }
                else
                {
                    return jumpSpeed * Vector2.up.y;
                }
            }
        }

        

        void Update()
        {
    

            // 以下はCharacterJumpの一部
            // CharacterJumpのジャンプメソッドを呼び出す
            if (Input.GetKeyDown(KeyCode.Space)) 
            {
                CharacterJump characterJump = GetComponent<CharacterJump>();
                if (characterJump != null)
                {
                    characterJump.JumpStart();
                    Debug.Log("Zキーが押されました。JumpHeight: " + JumpHeight);//いらないやつ
                }
            }
     
        }
    }
}