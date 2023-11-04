using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.CorgiEngine;
public class JumpItemCollector : MonoBehaviour
{
    public CharacterJump characterJump;
    bool isEntering = false;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "JumpPowerUP"){
            isEntering = true;
        }
    }

    private void Update() {
        if(isEntering && Input.GetKeyDown(KeyCode.F))
        {
            characterJump.isItemCollected = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "JumpPowerUP"){
            isEntering = false;
        }
    }

}
