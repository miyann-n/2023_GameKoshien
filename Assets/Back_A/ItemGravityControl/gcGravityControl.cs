using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gcGravityControl : MonoBehaviour
{
    public bool getGravityControl;
    // Start is called before the first frame update
    void Start()
    {
        getGravityControl = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown (KeyCode.F)) {
            Debug.Log("2");
            getGravityControl = true;
        } 
    }
}
