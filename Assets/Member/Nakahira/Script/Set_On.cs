using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set_On : MonoBehaviour
{

    public Collider myhako;
    private NewEnemyMove enemymove;
    private EneMisa missile;
    // �v���C���[�̈ʒu�ƃv���C���[�Ƃ̋���
    public Transform plyer;
    public float plykyori;

    void Start()
    {
        // ������
        enemymove = GetComponent<NewEnemyMove>();
        missile = GetComponent<EneMisa>();
        myhako.enabled = false;
    }

    void Update()
    {
        // �v���C���[�Ƃ̋������v�Z
        float sqrDistance = (transform.position - plyer.position).sqrMagnitude;

        // �������w�肵���͈͓��ł���ΓG�̃I�u�W�F�N�g��L����
        if (sqrDistance < plykyori * plykyori)
        {
            myhako.enabled = true;
            enemymove.enabled = true;
            missile.enabled = true;
        }
        //else
        //{
        //    // �͈͊O�ł���ΓG�̃I�u�W�F�N�g�𖳌���
        //    myhako.enabled = false;
        //    enemymove.enabled = false;
        //    missile.enabled = false;
        //}
    }

    //// �Q�[���I�u�W�F�N�g�̃{�b�N�X�R���C�_�[�ƃ��b�V�������_���[
    //public Collider myhako;
    //private NewEnemyMove enemymove;
    //private EneMisa missile;
    //// �v���C���[�̈ʒu�ƃv���C���[�Ƃ̋���
    //public Transform plyer;
    //public float plykyori;

    //void Start()
    //{
    //    // ������
    //    enemymove = GetComponent<NewEnemyMove>();
    //    missile = GetComponent<EneMisa>();
    //    myhako.enabled = false;
    //}

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.transform == plyer)
    //    {
    //        // �v���C���[���͈͓��ɓ��������ɏ�����L����
    //        myhako.enabled = true;
    //        enemymove.enabled = true;
    //        missile.enabled = true;
    //    }
    //}

    //void OnTriggerExit(Collider other)
    //{
    //    if (other.transform == plyer)
    //    {
    //        // �v���C���[���͈͊O�ɏo�����ɏ����𖳌���
    //        myhako.enabled = false;
    //        enemymove.enabled = false;
    //        missile.enabled = false;
    //    }
    //}
    //// �Q�[���I�u�W�F�N�g�̃{�b�N�X�R���C�_�[�ƃ��b�V�������_���[
    //public Collider myhako;
    //private NewEnemyMove enemymove;
    //private EneMisa missile;
    ////public MeshRenderer mymmes;
    //// �v���C���[�̈ʒu�ƃv���C���[�Ƃ̋���
    //public Transform plyer;
    //public float plykyori;

    //void Start()
    //{
    //    // ���b�V�������_���[���\���ɂ���
    //    //mymmes.enabled = false;
    //    enemymove = gameObject.GetComponent<NewEnemyMove>();
    //    missile = gameObject.GetComponent<EneMisa>();
    //    myhako.enabled = false;

    //}

    //// Update is called once per frame
    //void Update()
    //{



    //    Setonp();
    //}
    //public void Setonp()
    //{
    //    float sqrDistance = (transform.position - plyer.position).sqrMagnitude;
    //    print(sqrDistance);
    //    if (sqrDistance < plykyori * plykyori) // plykyori�̓����r���܂�
    //    {
    //        // �G�̏o��
    //        myhako.enabled = true;
    //        enemymove.enabled = true;
    //        missile.enabled = true;

    //    }

    //}
}
