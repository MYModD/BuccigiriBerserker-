using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set_On : MonoBehaviour
{
    // �Q�[���I�u�W�F�N�g�̃{�b�N�X�R���C�_�[�ƃ��b�V�������_���[
    public BoxCollider myhako;
    public MeshRenderer mymmes;
    // �v���C���[�̈ʒu�ƃv���C���[�Ƃ̋���
    public Transform plyer;
    public float plykyori;
    // �^�[�Q�b�g�̈ʒu
    public Transform target;
    // �ړ����x
    public float moveSpeed;

    public float stop;
    public float mo;
    public float st;
    public Transform target2;
    public Transform thisobj;
    // Start is called before the first frame update
    void Start()
    {
        // ���b�V�������_���[���\���ɂ���
        mymmes.enabled = false;
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

        Vector3 targetPos = plyer.position;

        Setonp();
    }
    public void Setonp()
    {
        //Transform target3 = teki.transform.Find("tekiko");
        float distance = Vector3.Distance(transform.position, plyer.position);
        if (distance < plykyori)
        {
            //�G�̂������
            myhako.enabled = true;
            mymmes.enabled = true;

            Vector3 targetPos = target.position;
            transform.LookAt(targetPos);
            Vector3 targetPos2 = target2.position;
            float distancepl = Vector3.Distance(transform.position, target.position);// ���̃I�u�W�F�N�g�ƃ^�[�Q�b�g�̋������v�Z

            // �^�[�Q�b�g�Ɍ������Ĉړ�
            if (distancepl > stop)
            {
                transform.position = transform.position + transform.forward * moveSpeed * Time.deltaTime;
            }
            else if (distancepl < stop)
            {
                // �^�[�Q�b�g2�Ɍ������Ĉړ�
                transform.LookAt(targetPos2);
                transform.position = transform.position + transform.forward * moveSpeed * Time.deltaTime;
            }
        }
    }
}