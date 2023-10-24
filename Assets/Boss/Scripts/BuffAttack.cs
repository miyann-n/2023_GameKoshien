using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.CorgiEngine;
using MoreMountains.Tools;
using MoreMountains.Feedbacks;
using UnityEngine.Serialization;

public class BuffAttack : MonoBehaviour
{
    private GameObject playerObj;
    private CharacterAbility JumpBuff;
    private float JumpHeight;
    public bool bossArea;

    // Start is called before the first frame update
    void Start()
    {
        playerObj = GameObject.FindWithTag("Player"); //
        JumpBuff = playerObj.GetComponent<CharacterJump>();
        //JumpBuff.JumpHeight = 2.4f;
        //JumpBuff.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
