using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickEvent : MonoBehaviour
{

    public MaterialMove materialMove;

    public void ObjectClick(){
        
        if(materialMove.isCheckAbilityWake){
            if(materialMove.isCheckObjectMove){
                materialMove.isCheckObjectMove = false;
            }
            else{
                materialMove.isCheckObjectMove = true;
            }
        }
        
    }
}
