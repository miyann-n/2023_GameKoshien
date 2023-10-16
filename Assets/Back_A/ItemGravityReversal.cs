using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGravityReversal : MonoBehaviour
{
    // Start is called before the first frame update
    public GravityReversalPlayer gravityReversalPlayer;
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
            gravityReversalPlayer.isCheckReversalDate = true;
            Destroy(this.gameObject);
        }
    }
}
