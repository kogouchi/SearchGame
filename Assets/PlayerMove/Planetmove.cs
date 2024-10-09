using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//惑星となる球の動作
public class Planetmove : MonoBehaviour
{
    public float speed = 1.0f, x_rotation = 0.0f, y_rotation = 0.0f;//スピードではなく数の変更をする↑

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 30;//フレームレートを60に設定
    }

    // Update is called once per frame
    void Update()
    {
        RotatePlanet();//移動動作
    }

    //移動動作
    void RotatePlanet()
    {
        //右キーが押された場合
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(new Vector3(transform.eulerAngles.x, y_rotation, transform.eulerAngles.z));
            y_rotation += speed;
            Debug.Log("右キーが押された");
        }
        //左キーが押された場合
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(new Vector3(transform.eulerAngles.x, y_rotation, transform.eulerAngles.z));
            y_rotation -= speed;
            Debug.Log("左キーが押された");
        }
        //上キーが押された場合
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.rotation = Quaternion.Euler(new Vector3(x_rotation, transform.eulerAngles.y, transform.eulerAngles.z));
            x_rotation += speed;
            Debug.Log("上キーが押された");
        }
        //下キーが押された場合
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.rotation = Quaternion.Euler(new Vector3(x_rotation, transform.eulerAngles.y, transform.eulerAngles.z));
            x_rotation -= speed;
            Debug.Log("下キーが押された");
        }
    }
}
