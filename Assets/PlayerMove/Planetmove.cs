using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�f���ƂȂ鋅�̓���
public class Planetmove : MonoBehaviour
{
    public float speed = 1.0f, x_rotation = 0.0f, y_rotation = 0.0f;//�X�s�[�h�ł͂Ȃ����̕ύX�����遪

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 30;//�t���[�����[�g��60�ɐݒ�
    }

    // Update is called once per frame
    void Update()
    {
        RotatePlanet();//�ړ�����
    }

    //�ړ�����
    void RotatePlanet()
    {
        //�E�L�[�������ꂽ�ꍇ
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(new Vector3(transform.eulerAngles.x, y_rotation, transform.eulerAngles.z));
            y_rotation += speed;
            Debug.Log("�E�L�[�������ꂽ");
        }
        //���L�[�������ꂽ�ꍇ
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(new Vector3(transform.eulerAngles.x, y_rotation, transform.eulerAngles.z));
            y_rotation -= speed;
            Debug.Log("���L�[�������ꂽ");
        }
        //��L�[�������ꂽ�ꍇ
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.rotation = Quaternion.Euler(new Vector3(x_rotation, transform.eulerAngles.y, transform.eulerAngles.z));
            x_rotation += speed;
            Debug.Log("��L�[�������ꂽ");
        }
        //���L�[�������ꂽ�ꍇ
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.rotation = Quaternion.Euler(new Vector3(x_rotation, transform.eulerAngles.y, transform.eulerAngles.z));
            x_rotation -= speed;
            Debug.Log("���L�[�������ꂽ");
        }
    }
}
