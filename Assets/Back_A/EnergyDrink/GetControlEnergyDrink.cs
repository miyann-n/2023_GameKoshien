using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetControlEnergyDrink : MonoBehaviour
{
    public bool getEnDrink;
    // Start is called before the first frame update
    void Start()
    {
        getEnDrink = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey (KeyCode.F)) {
            Debug.Log("2");
            getEnDrink = true;
        } 
    }
}
