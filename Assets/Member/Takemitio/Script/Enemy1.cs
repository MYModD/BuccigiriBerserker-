using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApproachTarget : MonoBehaviour
{
    // �^�[�Q�b�g�I�u�W�F�N�g�� Transform�R���|�[�l���g���i�[����ϐ�
    [SerializeField] private Transform target;
    // �I�u�W�F�N�g�̈ړ����x���i�[����ϐ�
    [SerializeField] private float moveSpeed;
    // �I�u�W�F�N�g����~����^�[�Q�b�g�I�u�W�F�N�g�Ƃ̋������i�[����ϐ�
    [SerializeField] private float stopDistance;
    // �I�u�W�F�N�g���^�[�Q�b�g�Ɍ������Ĉړ����J�n���鋗�����i�[����ϐ�
    [SerializeField] float moveDistance;

    // �Q�[�����s���ɖ��t���[�����s���鏈��
    void Update()
    {
        // �ϐ� targetPos ���쐬���ă^�[�Q�b�g�I�u�W�F�N�g�̍��W���i�[
        Vector3 targetPos = target.position;
        // �������g��Y���W��ϐ� target ��Y���W�Ɋi�[
        //�i�^�[�Q�b�g�I�u�W�F�N�g��X�AZ���W�̂ݎQ�Ɓj
        targetPos.y = transform.position.y;
        // �I�u�W�F�N�g��ϐ� targetPos �̍��W�����Ɍ�������
        //transform.LookAt(targetPos);

        // �ϐ� distance ���쐬���ăI�u�W�F�N�g�̈ʒu�ƃ^�[�Q�b�g�I�u�W�F�N�g�̋������i�[
        float distance = Vector3.Distance(transform.position, target.position);
        // �I�u�W�F�N�g�ƃ^�[�Q�b�g�I�u�W�F�N�g�̋�������
        // �ϐ� distance�i�^�[�Q�b�g�I�u�W�F�N�g�ƃI�u�W�F�N�g�̋����j���ϐ� moveDistance �̒l��菬�������
        // ����ɕϐ� distance ���ϐ� stopDistance �̒l�����傫���ꍇ
        if(distance <= stopDistance)
        {
            transform.position = transform.position - transform.forward * moveSpeed * 2 * Time.deltaTime;
        }
    }
}