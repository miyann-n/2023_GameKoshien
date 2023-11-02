using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;

public class SaveFilesDeleted : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTouched(){
        MMSaveLoadManager.DeleteAllSaveFiles();
        string _saveFolderName = "InventoryEngine";
        MMSaveLoadManager.DeleteSaveFolder (_saveFolderName);

    }
}


