using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player�̈ʒu���W�ARigidbody�𓾂�
/// ��Player�Ɍ������������擾�����邽��
/// Unity��ł��邱�� Player
/// �yRigidbody�z Use Gravity �`�F�b�N�I�t
/// �yRigidbody�z Constraints Freeze Rotation �`�F�b�N�I��
/// </summary>
public class PlayerBody : MonoBehaviour
{
    //public GameObject gravity;//�d�̓I�u�W�F�N�g�擾
    //public float acceleration = -50;//�����x�̑傫��
    //public float movespeed = 15;//�ړ��X�s�[�h
    //private Vector3 movedir;//�ړ��������
    //public bool flag = false;

    public GravityAttractor attractor;//GravityAttractor.cs���Q��
    public GameObject item;//�A�C�e���I�u�W�F�N�g�̎擾
    public GameObject item1;//�A�C�e���I�u�W�F�N�g�̎擾
    public GameObject item2;//�A�C�e���I�u�W�F�N�g�̎擾
    public Transform mytransform;//�ʒu���W�̎擾
    public Rigidbody rb;//Rigidbody�̎擾
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mytransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        ////�v���C���[����L�[�̊��蓖�ā{�ړ��������(normalized������)
        //movedir = new Vector3(
        //    //"Horizontal"�@�����@AD�@�Ȃ�
        //    Input.GetAxisRaw("Horizontal"),
        //    0,
        //    //"Vertical"�@�����@WS�@�Ȃ�
        //    Input.GetAxisRaw("Vertical")).normalized;//.normalized�Ńx�N�g���̐��K��
    }

    //�d�͂̏���
    void FixedUpdate()
    {
        attractor.Attract(mytransform, rb);

        //rb.MovePosition(rb.position + transform.TransformDirection(movedir * (movespeed * Time.deltaTime)));

        ////���L���̖͂@����p��������-----------------
        ////�����̃X�N���v�g�ɓ��Ă�ꂽ�I�u�W�F�N�g�ɏd�͂���������
        ////Player�Ɍ������������擾�����̂���PlayerBody�̃f�[�^�������Ŏ擾
        //Vector3 gravityup = (mytransform.position - gravity.transform.position).normalized;//.normalized�Ńx�N�g���̐��K��
        //Vector3 bodyup = mytransform.up;

        ////�ړ��L�[�����͂��ꂽ�ꍇ
        //if (Input.GetAxisRaw("Horizontal") != 0 && Input.GetAxisRaw("Vertical") != 0)
        //{
        //    Debug.Log("�����ꂽ");
        //    //�����x��^����
        //    rb.AddForce(gravityup * acceleration);
        //    //-------------------------------------------

        //    //�i�s������������]�̌v�Z
        //    //Quaternion.FromToRotation(�J�n�����A�I������)
        //    Quaternion targetRotation = Quaternion.FromToRotation(
        //        bodyup, gravityup) * mytransform.rotation;

        //    //2�_�ԕ⊮��Quaternion.Slerp 2�_�Ԃ����炩�Ɉړ������邽�߂̊֐�
        //    //���݂̃I�u�W�F�N�g�̊p�x����ڕW�̊p�x�܂ł������Ɖ�]������
        //    mytransform.rotation = Quaternion.Slerp(mytransform.rotation, targetRotation, 90 * Time.deltaTime);
        //}
    }

    //�I�u�W�F�N�g���m���G�ꂽ�ꍇ
    private void OnCollisionEnter(Collision collision)
    {
        //�A�C�e���̍폜
        if (collision.gameObject.tag == "Item") Destroy(item);
        if (collision.gameObject.tag == "Item") Destroy(item1);
        if (collision.gameObject.tag == "Item") Destroy(item2);
    }
}
