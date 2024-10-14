using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Unity��ł��邱��
//Rigidbody �uUse Gravity�v �̃`�F�b�N���O��
//Rigidbody Constraints �uFreeze Rotation�v �Ƀ`�F�b�N������
public class PlayerMove : MonoBehaviour
{
    #region �Q�l�T�C�g
    // ���L���͂ɂ��ā������o����悤�ɂ���
    // https://ftvoid.com/blog/post/738
    #endregion

    public Rigidbody rb;//���W�b�h�{�f�B�̎擾
    public GameObject planet;//���̂̎擾
    public float accelerationScale = 5.0f;//�����x�̑傫��
    public float speed = 0.05f;//�ړ��X�s�[�h
    public float vartical;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;//�t���[�����[�g��60�ɐݒ�
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

        Move();//�ړ�����
    }

    public void FixedUpdate()
    {
        //���̂Ɍ����������̎擾
        var direction = planet.transform.position - transform.position;
        direction.Normalize();

        //�����x�^����
        rb.AddForce(accelerationScale * direction, ForceMode.Acceleration);

        if(rb.velocity.magnitude < speed)
        {
            rb.AddForce(transform.forward * vartical * speed);
        }
    }

    private void Move()
    {
        Vector3 pos = this.transform.position;

        //�E�L�[�������ꂽ�ꍇ
        if (Input.GetKey(KeyCode.RightArrow))
        {
            pos.x += speed;
            Debug.Log("�E�L�[�������ꂽ");
        }
        //���L�[�������ꂽ�ꍇ
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            pos.x -= speed;
            Debug.Log("���L�[�������ꂽ");
        }
        //��L�[�������ꂽ�ꍇ
        if (Input.GetKey(KeyCode.UpArrow))
        {
            pos.y += speed;
            pos.z += speed;
            Debug.Log("��L�[�������ꂽ");
        }
        //���L�[�������ꂽ�ꍇ
        if (Input.GetKey(KeyCode.DownArrow))
        {
            pos.y -= speed;
            pos.z -= speed;
            Debug.Log("���L�[�������ꂽ");
        }
        this.transform.position = new Vector3(pos.x, pos.y, pos.z);
    }
}
