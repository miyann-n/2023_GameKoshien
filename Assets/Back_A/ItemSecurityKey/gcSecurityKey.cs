using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gcSecurityKey : MonoBehaviour
{
    public bool getSecurityKey;
    // Start is called before the first frame update
    void Start()
    {
        getSecurityKey = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) {
            Debug.Log("2");
            getSecurityKey = true;
        } 
    }
}
