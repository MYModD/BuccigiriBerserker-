using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set_On : MonoBehaviour
{
    // �Q�[���I�u�W�F�N�g�̃{�b�N�X�R���C�_�[�ƃ��b�V�������_���[
    public Collider myhako;
    private NewEnemyMove enemymove;
    private EneMisa missile;
    //public MeshRenderer mymmes;
    // �v���C���[�̈ʒu�ƃv���C���[�Ƃ̋���
    public Transform plyer;
    public float plykyori;
    // �^�[�Q�b�g�̈ʒu
    //public Transform target;
    // �ړ����x
    //public float moveSpeed;

    //public float stop;
    //public float mo;
    //public float st;
    //public Transform target2;
    //public Transform thisobj;
    // Start is called before the first frame update
    void Start()
    {
        // ���b�V�������_���[���\���ɂ���
        //mymmes.enabled = false;
        enemymove = gameObject.GetComponent<NewEnemyMove>();
        missile = gameObject.GetComponent<EneMisa>();
        myhako.enabled = false;
        //GameObject[] tekif = GameObject.FindGameObjectsWithTag("teki");
        //foreach (GameObject obj in tekif)
        //{
        //    Collider collider = obj.GetComponent<Collider>();
        //    MeshRenderer meshRenderer = obj.GetComponent<MeshRenderer>();
        //}
    }

    // Update is called once per frame
    void Update()
    {

        //Vector3 targetPos = plyer.position;

        Setonp();
    }
    public void Setonp()
    {
        float sqrDistance = (transform.position - plyer.position).sqrMagnitude;
        print(sqrDistance);
        if (sqrDistance < plykyori * plykyori) // plykyori�̓����r���܂�
        {
            // �G�̏o��
            myhako.enabled = true;
            enemymove.enabled = true;
            missile.enabled = true;
            //mymmes.enabled = true;
        }
        //Transform target3 = teki.transform.Find("tekiko");
        //float distance = Vector3.Distance(transform.position, plyer.position);
        //print(distance);
        //if (distance < plykyori)
        //{
        //    //�G�̂������
        //    myhako.enabled = true;
        //    enemymove.enabled = true;
        //    //mymmes.enabled = true;


        //}
    }
}
