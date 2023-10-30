using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireArm : MonoBehaviour
{
    // Start is called before the first frame update
    public float firearmSpeedf = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
        Vector2 force = new Vector2(firearmSpeedf,0f);
        rb.AddForce(force);
    }
}
