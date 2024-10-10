using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public GameObject player;//プレイヤーの取得
    public float yoffset;//y軸方向オフセット
    public float zoffset;//z軸方向オフセット

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");//プレイヤーという名前を探す
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤー位置座標を取得
        float x = player.transform.position.x;
        float y = player.transform.position.y;
        float z = player.transform.position.z;
        //カメラ位置座標を変更
        transform.position = new Vector3(x, y + yoffset, z + zoffset);
    }
}
