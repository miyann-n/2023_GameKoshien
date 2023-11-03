using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.CorgiEngine;
using System.IO;

public class GravityEnhanceManagement : MonoBehaviour
{
    public Energy energy;

    bool isEntering = false;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "GravityEnhanceItem"){
            isEntering = true;
        }
    }

    private void Update() {
        if(isEntering && Input.GetKeyDown(KeyCode.F))
        {
            File.WriteAllText("Assets/Back_B/Scripts/EnergyFlags.txt", "true");
            isEntering = false;
            //energy.isCheckBigObjectMove = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "GravityEnhanceItem"){
            isEntering = false;
        }
    }
}
