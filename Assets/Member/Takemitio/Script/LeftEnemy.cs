using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftEnemy : MonoBehaviour
{
    [Header("���Ɉړ������鋗��")]
    [SerializeField] private float distanceToLeft; // ���Ɉړ����鋗��
    [Header("�ړ����x")]
    [SerializeField] private float moveSpeed; // �ړ����x
    [Header("�N�ɑ΂��ċ�����ۂ�")]
    [SerializeField] private Transform target;
    [Header("TARGET�̊Ԃɕۂ���")]
    [SerializeField] private float stopDistance;

    private bool reachedTarget = false; // �^�[�Q�b�g�ɓ��B�������ǂ����̃t���O
    private Vector3 targetPosition; // �ڕW�ʒu

    private void Start()
    {
        // ���Ɉړ�����ڕW�ʒu���v�Z
        targetPosition = transform.position + Vector3.left * distanceToLeft;
    }

    private void Update()
    {
        // �ڕW�ʒu�Ɍ������Ĉړ�
        if (!reachedTarget)
        {
            // �ڕW�ʒu�Ɍ������Ĉړ�
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // �I�u�W�F�N�g�ƃ^�[�Q�b�g�I�u�W�F�N�g�̋�������
            float leftdistance = Vector3.Distance(transform.position, target.position);
            if (leftdistance <= stopDistance)
            {
                reachedTarget = true; // �^�[�Q�b�g�ɓ��B������t���O�𗧂Ă�
            }
        }
    

    // �^�[�Q�b�g�Ɍ������Ĉړ�
    Vector3 targetPos = target.position;
        targetPos.y = transform.position.y;
        //transform.LookAt(targetPos);

        // �I�u�W�F�N�g�ƃ^�[�Q�b�g�I�u�W�F�N�g�̋�������
        float distance = Vector3.Distance(transform.position, target.position);
        if (distance <= stopDistance)
        {
            transform.position = transform.position + transform.forward * moveSpeed * 2 * Time.deltaTime;
        }
    }
}
