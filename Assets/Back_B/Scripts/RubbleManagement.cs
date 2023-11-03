using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.CorgiEngine;

public class RubbleManagement : MonoBehaviour
{
    public bool isRubbleItemCollected;
    bool isEntering = false;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "RubbleItem"){
            isEntering = true;
            Debug.Log(isEntering);
        }
    }

    // Update is called once per frame
    void Update()
    {
       // bool isBigRubbleItemCollected = bigRubble.isBigRubbleItemCollected;
        //bool isSmallRubbleItemCollected = rubble.isSmallRubbleItemCollected;

        if(isEntering && Input.GetKeyDown(KeyCode.F))
        {
            isRubbleItemCollected = true;
            Debug.Log(isRubbleItemCollected);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "RubbleItem")
        {
            isEntering = false;
            Debug.Log(isEntering);
        }
    }
}
