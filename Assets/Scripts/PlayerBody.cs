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
    public GravityAttractor attractor;//GravityAttractor.cs���Q��
    public GameObject item;//�A�C�e���I�u�W�F�N�g�̎擾
    private Transform mytransform;//�ʒu���W�̎擾
    private Rigidbody rb;//Rigidbody�̎擾

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
        //���炩�̃L�[�������ꂽ�ꍇ(�L�[�������Ă��Ȃ����ɏ���ɓ����Ă��܂�����)
        if(Input.anyKey)
        //GravityAttractor.cs��Attract�֐�����
        attractor.Attract(mytransform, rb);//transform��rigidbody�̏���n��
    }

    //�I�u�W�F�N�g���m���G�ꂽ�ꍇ
    private void OnCollisionEnter(Collision collision)
    {
        //�A�C�e���̍폜
        if (collision.gameObject.tag == "Item") Destroy(item);
    }
}
