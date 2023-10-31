using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//テスト用に作った適当なスクリプトです（本番には無関係）

public class EnemySpeed : MonoBehaviour
{
    public float EnemySpeedf = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
        Vector2 force = new Vector2(EnemySpeedf,0f);
        rb.AddForce(force);
    }
}
