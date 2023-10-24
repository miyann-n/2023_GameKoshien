using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gcGravityReversal : MonoBehaviour
{
    public bool getGravityReversal;
    // Start is called before the first frame update
    void Start()
    {
        getGravityReversal = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey (KeyCode.F)) {
            Debug.Log("2");
            getGravityReversal = true;
        } 
    }
}