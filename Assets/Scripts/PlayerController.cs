using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�v���C���[�R���g���[���[����
public class PlayerController : MonoBehaviour
{
    public float movespeed = 15;
    private Vector3 movedir;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        movedir = new Vector3(
            Input.GetAxisRaw("Horizontal"),//�J�[�\���L�[ ����
            0,
            Input.GetAxisRaw("Vertical")).normalized;//�J�[�\���L�[ ����
        //.normalized�Ńx�N�g���̐��K��
    }

    void FixedUpdate()
    {
        //MovePosition()���w�肵������̍��W�Ɍ������Ĉړ�����
        //TransformDirection()���@��������̃x�N�g���̌�����ύX�ł���
        //���X�P�[���ƈʒu���W�ɉe������Ȃ�
        rb.MovePosition(rb.position + transform.TransformDirection(movedir * (movespeed * Time.deltaTime)));
    }
}
