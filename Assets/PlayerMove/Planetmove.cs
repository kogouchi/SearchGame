using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�f���ƂȂ鋅�̓���
public class Planetmove : MonoBehaviour
{
    public float movespeed;//��]����X�s�[�h
    public float msx, msy;//�X�s�[�h�ł͂Ȃ����̕ύX�����遪

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;//�t���[�����[�g��60�ɐݒ�
        movespeed = 0.1f;
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
            transform.rotation = Quaternion.Euler(new Vector3(transform.eulerAngles.x, movespeed, transform.eulerAngles.z));
            movespeed += 0.001f;
        }
        //���L�[�������ꂽ�ꍇ
        if (Input.GetKey(KeyCode.LeftArrow))
        {

        }
        //��L�[�������ꂽ�ꍇ
        if (Input.GetKey(KeyCode.UpArrow))
        {

        }
        //���L�[�������ꂽ�ꍇ
        if (Input.GetKey(KeyCode.DownArrow))
        {

        }
    }
}
