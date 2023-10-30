using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubbleMouse : MonoBehaviour
{

    public RubbleAttack rubbleAttack;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseUp(){
        Debug.Log("クリック離し");
        rubbleAttack.isCheckLeftClick = false;
    }

    public void OnMouseDrag(){
        rubbleAttack.isCheckLeftClick = true;
        Debug.Log("クリック確認");
            
    }
}
