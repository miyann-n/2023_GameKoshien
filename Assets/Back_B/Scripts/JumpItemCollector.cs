using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.CorgiEngine;
public class JumpItemCollector : MonoBehaviour
{
    public CharacterJump characterJump;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("JumpPowerUP"))
        {
            characterJump.isItemCollected = true;
        }
    }
}
