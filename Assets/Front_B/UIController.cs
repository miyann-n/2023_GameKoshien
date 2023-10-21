using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject PanelUIObj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void InactivatePanel()
    {
        //Panelを消す
        PanelUIObj.SetActive(false);
    }
}