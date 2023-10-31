using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;

public class CheckPointLoad : MonoBehaviour
{
    // Update is called once per frame
    public void Load()
    {
        MMEventManager.TriggerEvent(new MMGameEvent("LoadFromMemory"));
        MMEventManager.TriggerEvent(new MMGameEvent("LoadFromFile"));
    }
}
