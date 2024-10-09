using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//惑星となる球の動作
public class Planetmove : MonoBehaviour
{
    public float movespeed;//回転するスピード
    public float msx, msy;//スピードではなく数の変更をする↑

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;//フレームレートを60に設定
        movespeed = 0.1f;
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
            transform.rotation = Quaternion.Euler(new Vector3(transform.eulerAngles.x, movespeed, transform.eulerAngles.z));
            movespeed += 0.001f;
        }
        //左キーが押された場合
        if (Input.GetKey(KeyCode.LeftArrow))
        {

        }
        //上キーが押された場合
        if (Input.GetKey(KeyCode.UpArrow))
        {

        }
        //下キーが押された場合
        if (Input.GetKey(KeyCode.DownArrow))
        {

        }
    }
}
