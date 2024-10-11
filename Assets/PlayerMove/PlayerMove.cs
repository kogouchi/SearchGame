using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Unity上ですること
//Rigidbody 「Use Gravity」 のチェックを外す
//Rigidbody Constraints 「Freeze Rotation」 にチェックを入れる
public class PlayerMove : MonoBehaviour
{
    #region 参考サイト
    // 万有引力について→説明出来るようにする
    // https://ftvoid.com/blog/post/738
    #endregion

    public Rigidbody rb;//リジッドボディの取得
    public GameObject planet;//球体の取得
    public float accelerationScale = 5.0f;//加速度の大きさ
    public float speed = 0.05f;//移動スピード
    public float vartical;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;//フレームレートを60に設定
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        vartical = Input.GetAxis("Vertical");

        if (Mathf.Abs(horizontal) > 0.1f)
        {
            transform.Rotate(0, horizontal * speed * Time.deltaTime, 0);
        }

        Move();//移動処理
    }

    public void FixedUpdate()
    {
        //球体に向かう向きの取得
        var direction = planet.transform.position - transform.position;
        direction.Normalize();

        //加速度与える
        rb.AddForce(accelerationScale * direction, ForceMode.Acceleration);

        if(rb.velocity.magnitude < speed)
        {
            rb.AddForce(transform.forward * vartical * speed);
        }
    }

    private void Move()
    {
        Vector3 pos = this.transform.position;

        //右キーが押された場合
        if (Input.GetKey(KeyCode.RightArrow))
        {
            pos.x += speed;
            Debug.Log("右キーが押された");
        }
        //左キーが押された場合
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            pos.x -= speed;
            Debug.Log("左キーが押された");
        }
        //上キーが押された場合
        if (Input.GetKey(KeyCode.UpArrow))
        {
            pos.y += speed;
            pos.z += speed;
            Debug.Log("上キーが押された");
        }
        //下キーが押された場合
        if (Input.GetKey(KeyCode.DownArrow))
        {
            pos.y -= speed;
            pos.z -= speed;
            Debug.Log("下キーが押された");
        }
        this.transform.position = new Vector3(pos.x, pos.y, pos.z);
    }
}
