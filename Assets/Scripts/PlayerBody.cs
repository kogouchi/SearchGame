using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Playerの位置座標、Rigidbodyを得る
/// →Playerに向かう向きを取得させるため
/// Unity上ですること Player
/// 【Rigidbody】 Use Gravity チェックオフ
/// 【Rigidbody】 Constraints Freeze Rotation チェックオン
/// </summary>
public class GravityBody : MonoBehaviour
{
    public GravityAttractor attractor;//GravityAttractor.csを参照
    private Transform mytransform;//位置座標の取得
    private Rigidbody rb;//Rigidbodyの取得

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mytransform = transform;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        //GravityAttractor.csのAttract関数処理
        attractor.Attract(mytransform, rb);//transformとrigidbodyの情報を渡す
    }
}
