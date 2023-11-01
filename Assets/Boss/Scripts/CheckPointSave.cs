using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;

public class CheckPointSave : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveData()
    {
        //other.gameObject.SetActive(false);
        Debug.Log("yyy");
        MMEventManager.TriggerEvent(new MMGameEvent("SaveToMemory"));
        MMEventManager.TriggerEvent(new MMGameEvent("SaveToFile"));
        }
    
}
