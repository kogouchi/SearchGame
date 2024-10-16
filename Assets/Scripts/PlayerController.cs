using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�v���C���[�R���g���[���[����
//�w�肵���ꏊ�Ɉړ��{������ς���
public class PlayerController : MonoBehaviour
{
    public float movespeed = 15;//�ړ��X�s�[�h
    private Vector3 movedir;//�ړ��������
    private Rigidbody rb;//Rigidbody�̎擾

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //�v���C���[����L�[�̊��蓖�ā{�ړ��������(normalized������)
        movedir = new Vector3(
            //"Horizontal"�@�����@AD�@�Ȃ�
            Input.GetAxisRaw("Horizontal"),
            0,
            //"Vertical"�@�����@WS�@�Ȃ�
            Input.GetAxisRaw("Vertical")).normalized;//.normalized�Ńx�N�g���̐��K��
    }

    void FixedUpdate()
    {
        //MovePosition()���w�肵������̍��W�Ɍ������Ĉړ�����
        //TransformDirection()���@��������̃x�N�g���̌�����ύX�ł���@���X�P�[���ƈʒu���W�ɉe������Ȃ�
        rb.MovePosition(rb.position + transform.TransformDirection(movedir * (movespeed * Time.deltaTime)));
    }
}
