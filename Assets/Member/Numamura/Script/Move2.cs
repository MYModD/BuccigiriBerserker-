using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2 : MonoBehaviour
{
    
    public float moveSpeed = 5f; // �v���C���[�̈ړ����x
    public float returnSpeed = 2f; // ���̈ʒu�ɖ߂鑬�x

    private Vector3 targetPosition; // �ڕW�ʒu
    private bool isMoving = false; // �v���C���[���ړ������ǂ����̃t���O

    void Update()
    {
        // ���͂��󂯎��A�ڕW�ʒu���X�V
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(moveHorizontal, 0f, moveVertical).normalized;
        if (moveDirection.magnitude >= 0.1f)
        {
            isMoving = true;
            targetPosition = transform.position + moveDirection;
        }
        else
        {
            isMoving = false;
        }

        // �v���C���[���ړ�������
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
        else
        {
            // ���̈ʒu�ɖ߂�
            transform.position = Vector3.MoveTowards(transform.position, transform.parent.position, returnSpeed * Time.deltaTime);
        }
    }
}

