using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamDirection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = GameObject.FindWithTag("Player").transform.position;
        Vector3 dir = targetPos - transform.position;
        // ベクトルの方向を回転角度に変換します
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        // オブジェクトを指定した角度に回転させます
        transform.rotation = Quaternion.AngleAxis(angle + 90f, Vector3.forward);
    }
}
