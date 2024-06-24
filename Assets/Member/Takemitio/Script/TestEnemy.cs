using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float stopDistance;
    [SerializeField] private float retreatDistance; // �v���C���[���痣��鋗����ݒ�

    private void Update()
    {
        // �v���C���[�Ƃ̋������v�Z
        float distanceToPlayer = Vector3.Distance(transform.position, target.position);

        // �v���C���[�Ƃ̋���������鋗�������������ꍇ�Ɍ�ނ���
        if (distanceToPlayer < retreatDistance)
        {
            // �I�u�W�F�N�g�̕������v���C���[���痣�ꂽ�����Ɍ�����
            Vector3 directionToPlayer = (transform.position - target.position).normalized;
            // ��ނ���
            transform.position += directionToPlayer * moveSpeed * Time.deltaTime;
        }
    }
}