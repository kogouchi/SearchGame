using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Item�̈ʒu���W�ARigidbody�𓾂�
/// ��Item�Ɍ������������擾�����邽��
/// Unity��ł��邱�� Item
/// �yRigidbody�z Use Gravity �`�F�b�N�I�t
/// �yRigidbody�z Constraints Freeze Rotation �`�F�b�N�I��
/// </summary>
public class ItemBody : MonoBehaviour
{
    public GravityAttractor attractor;//GravityAttractor.cs���Q��
    private Transform mytransform;//�ʒu���W�̎擾
    private Rigidbody rb;//Rigidbody�̎擾
    private bool contact = false;//ture �ڐG���� falase �ڐG���ĂȂ�

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mytransform = transform;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if(!contact)
        //GravityAttractor.cs��Attract�֐�����
        attractor.Attract(mytransform, rb);//transform��rigidbody�̏���n��
    }

    //�I�u�W�F�N�g���m���G�ꂽ�ꍇ
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Planet") contact = false;
    }
}
