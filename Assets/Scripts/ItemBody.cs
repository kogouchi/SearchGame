using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Itemの位置座標、Rigidbodyを得る
/// →Itemに向かう向きを取得させるため
/// Unity上ですること Item
/// 【Rigidbody】 Use Gravity チェックオフ
/// 【Rigidbody】 Constraints Freeze Rotation チェックオン
/// </summary>
public class ItemBody : MonoBehaviour
{
    public GravityAttractor attractor;//GravityAttractor.csを参照
    private Transform mytransform;//位置座標の取得
    private Rigidbody rb;//Rigidbodyの取得
    private bool contact = false;//ture 接触した falase 接触してない

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
        if(!contact)
        //GravityAttractor.csのAttract関数処理
        attractor.Attract(mytransform, rb);//transformとrigidbodyの情報を渡す
    }

    //オブジェクト同士が触れた場合
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Planet") contact = false;
    }
}
