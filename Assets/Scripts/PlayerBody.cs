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
public class PlayerBody : MonoBehaviour
{
    public GravityAttractor attractor;//GravityAttractor.csを参照
    public GameObject item;//アイテムオブジェクトの取得
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
        //何らかのキーが押された場合(キーを押していない時に勝手に動いてしまうため)
        if(Input.anyKey)
        //GravityAttractor.csのAttract関数処理
        attractor.Attract(mytransform, rb);//transformとrigidbodyの情報を渡す
    }

    //オブジェクト同士が触れた場合
    private void OnCollisionEnter(Collision collision)
    {
        //アイテムの削除
        if (collision.gameObject.tag == "Item") Destroy(item);
    }
}
