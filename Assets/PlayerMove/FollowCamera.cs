using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public GameObject player;//�v���C���[�̎擾
    public float yoffset;//y�������I�t�Z�b�g
    public float zoffset;//z�������I�t�Z�b�g

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");//�v���C���[�Ƃ������O��T��
    }

    // Update is called once per frame
    void Update()
    {
        //�v���C���[�ʒu���W���擾
        float x = player.transform.position.x;
        float y = player.transform.position.y;
        float z = player.transform.position.z;
        //�J�����ʒu���W��ύX
        transform.position = new Vector3(x, y + yoffset, z + zoffset);
    }
}
