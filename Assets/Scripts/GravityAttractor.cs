using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Unity��ł��邱�� Planet
/// �yRigidbody�z Use Gravity �`�F�b�N�I�t
/// �yRigidbody�z Constraints Freeze Position �`�F�b�N�I��
/// �yRigidbody�z Constraints Freeze Rotation �`�F�b�N�I��
/// </summary>
public class GravityAttractor : MonoBehaviour
{
    public float gravity = -10;//�����x�̑傫��

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //GravityBody.cs�֎Q�Ƃ�����֐�
    public void Attract(Transform body, Rigidbody rb)
    {
        //Player�Ɍ������������擾
        Vector3 gravityup = (body.position - transform.position).normalized;//.normalized�Ńx�N�g���̐��K��
        Vector3 bodyup = body.up;

        //�����x��^����
        rb.AddForce(gravityup * gravity);

        //�i�s������������]�̌v�Z
        //Quaternion.FromToRotation(�J�n�����A�I������)
        Quaternion targetRotation = Quaternion.FromToRotation(
            bodyup, gravityup) * body.rotation;

        //2�_�ԕ⊮��Quaternion.Slerp 2�_�Ԃ����炩�Ɉړ������邽�߂̊֐�
        //���݂̃I�u�W�F�N�g�̊p�x����ڕW�̊p�x�܂ł������Ɖ�]������
        body.rotation = Quaternion.Slerp(body.rotation, targetRotation, 50 * Time.deltaTime);
    }
}
