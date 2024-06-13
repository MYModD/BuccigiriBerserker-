using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyListTest : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;

    [SerializeField]
    private GameObject _player;

    [SerializeField]
    private float _searchDistance = 95f;

    [SerializeField, Range(0f, 180f)]
    private float _coneAngle = 45f;

    public List<Transform> _filteredObjects = new List<Transform>();

    void FixedUpdate()
    {
        // ����͈͓̔��ɂ���Q�[���I�u�W�F�N�g���擾
        RaycastHit[] hits = Physics.SphereCastAll(
            _player.transform.position,
            _searchDistance,
            Vector3.up, //���󂾂���֌W�Ȃ����
            0.01f,
            LayerMask.GetMask("Enemy")
        );

        List<Transform> allObjects = new List<Transform>();

        foreach (RaycastHit hit in hits)
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                allObjects.Add(hit.collider.transform);
            }
        }

        // �J�����̒��S����J�����̌����ɉ~���͈̔͂�����ăt�B���^�����O
        _filteredObjects.Clear();

        Vector3 cameraPosition = _camera.transform.position;
        Vector3 cameraForward = _camera.transform.forward;

        foreach (Transform obj in allObjects)
        {
            // �J��������I�u�W�F�N�g�ւ̃x�N�g�����v�Z
            Vector3 toObject = obj.position - cameraPosition;
            float distanceToObject = toObject.magnitude;

            // �������w�肵���͈͓����m�F
            if (distanceToObject <= _searchDistance)
            {
                // �I�u�W�F�N�g�ւ̃x�N�g���𐳋K��
                Vector3 toObjectNormalized = toObject.normalized;

                // �J�����̑O���x�N�g���ƃI�u�W�F�N�g�ւ̃x�N�g���̊Ԃ̊p�x���v�Z
                float angle = Vector3.Angle(cameraForward, toObjectNormalized);

                // �p�x���~���͈͓̔��Ɏ��܂邩�𔻒�
                if (angle <= _coneAngle / 2)
                {
                    _filteredObjects.Add(obj);
                }
            }
        }

        // �t�B���^�����O���ꂽ�I�u�W�F�N�g�̏����i��F�F��ύX�j
        foreach (Transform obj in _filteredObjects)
        {
            obj.GetComponent<Renderer>().material.color = Color.blue;
        }

        // �~���͈͊O�̃I�u�W�F�N�g�̐F�����ɖ߂�
        foreach (Transform obj in allObjects)
        {
            if (!_filteredObjects.Contains(obj))
            {
                obj.GetComponent<Renderer>().material.color = Color.red;
            }
        }
    }
}
