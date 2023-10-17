using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovie : MonoBehaviour
{
    // Start is called before the first frame update
    public int i;
    void Start()
    {
        for(int i = 1000; i > 0; --i)
        { 
            transform.position += transform.TransformDirection(Vector3.forward * 5);
            Debug.Log(i);
        }

    }

    // Update is called once per frame
    void Update()
    {
      
       
    
    }

        
    
}
