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
    public GameObject planet;//planetの取得
    public float gravity = -50;//加速度の大きさ
    //public GravityAttractor attractor;//GravityAttractor.csを参照
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
        //attractor.Attract(mytransform, rb);//transformとrigidbodyの情報を渡す
        {
            //Playerに向かう向きを取得→そのためPlayerBodyのデータを引数で取得
            Vector3 gravityup = (mytransform.position - planet.transform.position).normalized;//.normalizedでベクトルの正規化
            //Vector3 bodyup = transform.up;

            //加速度を与える
            rb.AddForce(gravityup * gravity);
        }
    }

    //オブジェクト同士が触れた場合
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Planet")
        {
            contact = false;//重力を消す
            //rb.constraints = RigidbodyConstraints.FreezeAll;//位置座標、回転座標を固定
        }
    }
}
