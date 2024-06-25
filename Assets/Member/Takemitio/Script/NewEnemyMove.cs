using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemyMove : MonoBehaviour
{
    [Header("�ړ������鋗��")]
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
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
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
            float squaredDistance = (transform.position - target.position).sqrMagnitude;
            if (squaredDistance <= stopDistance * stopDistance)
            {
                reachedTarget = true; // �^�[�Q�b�g�ɓ��B������t���O�𗧂Ă�
            }
        }

        // �^�[�Q�b�g�Ɍ������Ĉړ�
        Vector3 targetPos = target.position;
        targetPos.y = transform.position.y;

        // �I�u�W�F�N�g�ƃ^�[�Q�b�g�I�u�W�F�N�g�̋�������
        float squaredDist = (transform.position - target.position).sqrMagnitude;
        if (squaredDist <= stopDistance * stopDistance)
        {
            transform.position = transform.position - transform.forward * moveSpeed * 2 * Time.deltaTime;
        }
    }
}