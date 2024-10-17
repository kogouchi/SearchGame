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
    //public GameObject gravity;//重力オブジェクト取得
    //public float acceleration = -50;//加速度の大きさ
    //public float movespeed = 15;//移動スピード
    //private Vector3 movedir;//移動する向き
    //public bool flag = false;

    public GravityAttractor attractor;//GravityAttractor.csを参照
    public GameObject item;//アイテムオブジェクトの取得
    public GameObject item1;//アイテムオブジェクトの取得
    public GameObject item2;//アイテムオブジェクトの取得
    public Transform mytransform;//位置座標の取得
    public Rigidbody rb;//Rigidbodyの取得
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mytransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        ////プレイヤー操作キーの割り当て＋移動する向き(normalizedさせる)
        //movedir = new Vector3(
        //    //"Horizontal"　←→　AD　など
        //    Input.GetAxisRaw("Horizontal"),
        //    0,
        //    //"Vertical"　↑↓　WS　など
        //    Input.GetAxisRaw("Vertical")).normalized;//.normalizedでベクトルの正規化
    }

    //重力の処理
    void FixedUpdate()
    {
        attractor.Attract(mytransform, rb);

        //rb.MovePosition(rb.position + transform.TransformDirection(movedir * (movespeed * Time.deltaTime)));

        ////万有引力の法則を用いたもの-----------------
        ////→このスクリプトに当てられたオブジェクトに重力を持たせる
        ////Playerに向かう向きを取得→そのためPlayerBodyのデータを引数で取得
        //Vector3 gravityup = (mytransform.position - gravity.transform.position).normalized;//.normalizedでベクトルの正規化
        //Vector3 bodyup = mytransform.up;

        ////移動キーが入力された場合
        //if (Input.GetAxisRaw("Horizontal") != 0 && Input.GetAxisRaw("Vertical") != 0)
        //{
        //    Debug.Log("押された");
        //    //加速度を与える
        //    rb.AddForce(gravityup * acceleration);
        //    //-------------------------------------------

        //    //進行方向を向く回転の計算
        //    //Quaternion.FromToRotation(開始方向、終了方向)
        //    Quaternion targetRotation = Quaternion.FromToRotation(
        //        bodyup, gravityup) * mytransform.rotation;

        //    //2点間補完→Quaternion.Slerp 2点間を滑らかに移動させるための関数
        //    //現在のオブジェクトの角度から目標の角度までゆっくりと回転させる
        //    mytransform.rotation = Quaternion.Slerp(mytransform.rotation, targetRotation, 90 * Time.deltaTime);
        //}
    }

    //オブジェクト同士が触れた場合
    private void OnCollisionEnter(Collision collision)
    {
        //アイテムの削除
        if (collision.gameObject.tag == "Item") Destroy(item);
        if (collision.gameObject.tag == "Item") Destroy(item1);
        if (collision.gameObject.tag == "Item") Destroy(item2);
    }
}
