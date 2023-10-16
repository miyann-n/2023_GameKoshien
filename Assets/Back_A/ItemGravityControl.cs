using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGravityControl : MonoBehaviour
{
    public MaterialMove materialMove;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision) 
    {
        if(collision.gameObject.tag == "Player")
        {
            //「拾う」というUIを出す処理
            //アイテム説明等のUIを表示する処理
            materialMove.isCheckObjectMove = true;
            Destroy(this.gameObject);
        }
    }
}
