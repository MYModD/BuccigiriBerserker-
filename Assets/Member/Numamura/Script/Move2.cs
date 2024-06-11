using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2 : MonoBehaviour
{
    
    public float _moveSpeed = 5f; // �v���C���[�̈ړ����x
    public float _returnSpeed = 2f; // ���̈ʒu�ɖ߂鑬�x

    private Vector3 _targetPosition; // �ڕW�ʒu
    private bool _isMoving = false; // �v���C���[���ړ������ǂ����̃t���O

    void Update()
    {
        // ���͂��󂯎��A�ڕW�ʒu���X�V
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(moveHorizontal, 0f, moveVertical).normalized;
        if (moveDirection.magnitude >= 0.1f)
        {
            _isMoving = true;
            _targetPosition = transform.position + moveDirection;
        }
        else
        {
            _isMoving = false;
        }

        // �v���C���[���ړ�������
        if (_isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _moveSpeed * Time.deltaTime);
        }
        else
        {
            // ���̈ʒu�ɖ߂�
            transform.position = Vector3.MoveTowards(transform.position, transform.parent.position, _returnSpeed * Time.deltaTime);
        }
    }
}

