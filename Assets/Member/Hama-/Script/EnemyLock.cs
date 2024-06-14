using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLock : MonoBehaviour
{
    public Camera mainCamera;
    public bool _isLock ;

    private void Update()
    {
        // �I�u�W�F�N�g���J�������猩���Ă��邩�ǂ������`�F�b�N����
        CheckIfVisible();
        //Debug.Log(locksw);
    }

    void CheckIfVisible()
    {
        Vector3 objectPos = transform.position;

        Vector3 screenPos = mainCamera.WorldToViewportPoint(objectPos);
        /**
         �I�u�W�F�N�g���J�����̃r���[���ɂ��邩�ǂ������`�F�b�N
        screenpos.x >= 0 && screenpos.x <= 1 :�I�u�W�F�N�g�̂����W���r���[�|�[�g�̕����ɂ��邩�ǂ���
        screenpos.y >= 0 && screenpos.y <= 1 :�I�u�W�F�N�g�̂����W���r���[�|�[�g�̍������ɂ��邩�ǂ���
        screenpos.z > 0 :�I�u�W�F�N�g�̂����W���O���傫�������m�F����
        **/
        bool isVisible = (screenPos.x >= 0 && screenPos.x <= 1 && screenPos.y >= 0 && screenPos.y <= 1 && screenPos.z > 0);

        if (!isVisible)
        {
            // �I�u�W�F�N�g���J�����̃r���[���猩���Ȃ��Ȃ����Ƃ��̏������s��
            OnBecameInvisible();
        }

        if (isVisible)
        {
            //Debug.Log("utut");
            _isLock = true;
        }
    }

    void OnBecameInvisible()
    {
        // �I�u�W�F�N�g���r���[���猩���Ȃ��Ȃ����Ƃ��̏������L�q
        //Debug.Log("Object became invisible!");
        _isLock = false;
    }
}

