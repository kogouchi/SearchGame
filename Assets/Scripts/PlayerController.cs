using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//プレイヤーコントローラー処理
//指定した場所に移動＋向きを変える
public class PlayerController : MonoBehaviour
{
    public float movespeed = 15;//移動スピード
    private Vector3 movedir;//移動する向き
    private Rigidbody rb;//Rigidbodyの取得

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤー操作キーの割り当て＋移動する向き(normalizedさせる)
        movedir = new Vector3(
            //"Horizontal"　←→　AD　など
            Input.GetAxisRaw("Horizontal"),
            0,
            //"Vertical"　↑↓　WS　など
            Input.GetAxisRaw("Vertical")).normalized;//.normalizedでベクトルの正規化
    }

    void FixedUpdate()
    {
        //MovePosition()→指定した特定の座標に向かって移動する
        //TransformDirection()→法線や方向のベクトルの向きを変更できる　※スケールと位置座標に影響されない
        rb.MovePosition(rb.position + transform.TransformDirection(movedir * (movespeed * Time.deltaTime)));
    }
}
