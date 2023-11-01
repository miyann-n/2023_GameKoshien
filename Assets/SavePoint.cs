using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;

public class SavePoint : MonoBehaviour
{
    private GameObject player; 
    public static string _defaultFileName = "Achievements";
	public static string _saveFolderName = "MMAchievements/";
	public static string _saveFileExtension = ".achievements";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SavePC()
    {
        player = GameObject.FindWithTag("Player");
        MMSaveLoadManager.Save(player, _defaultFileName+_saveFileExtension, _saveFolderName);
    }
}
