using System.Collections.Generic;
using UnityEngine;
using Utils;

public class LockOnManager : MonoBehaviour
{
    // �J�����̎��E�ɓ����Ă���^�[�Q�b�g�̃��X�g
    public List<Transform> targetsInCamera = new List<Transform>();
    // ���̓��ɓ����Ă���^�[�Q�b�g�̃��X�g
    public List<Transform> targetsInCone = new List<Transform>();

    [SerializeField]
    private Camera _camera;

    [SerializeField]
    private float _searchRadius = 95f; // ����͈̔͂̔��a

    [SerializeField, Range(0f, 180f)]
    private float _coneAngle = 45f; // �~���̊p�x

    public float Z;

    void Update()
    {
        // �^�[�Q�b�g���X�g���X�V
        UpdateTargets();

        // �J�����̎��E�ɓ����Ă���^�[�Q�b�g��ԐF�ɂ���
        for (int i = 0; i < targetsInCamera.Count; i++)
        {
            targetsInCamera[i].GetComponent<MeshRenderer>().material.color = Color.red;
        }

        // �~�����ɓ����Ă���^�[�Q�b�g��F�ɂ���
        for (int j = 0; j < targetsInCone.Count; j++)
        {
            targetsInCone[j].GetComponent<MeshRenderer>().material.color = Color.blue;
        }
    }

    // �^�[�Q�b�g���X�g���X�V���郁�\�b�h
    private void UpdateTargets()
    {
        // �J�����̎����䕽�ʂ��擾
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(_camera);

        targetsInCamera.Clear();
        targetsInCone.Clear();

        // ����͈͓̔��̃q�b�g�����R���C�_�[���擾
        Collider[] hits = GetSphereOverlapHits();

        foreach (Collider hit in hits)
        {
            // �q�b�g�����I�u�W�F�N�g������
            ProcessHit(hit, planes);
            hit.gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
        }
    }

    // ����͈͓̔��̃q�b�g�����R���C�_�[���擾���郁�\�b�h
    private Collider[] GetSphereOverlapHits()
    {
        return Physics.OverlapSphere(
            _camera.transform.position,
            _searchRadius,
            LayerMask.GetMask("Enemy")
        );
    }

    // �q�b�g�����I�u�W�F�N�g���������郁�\�b�h
    private void ProcessHit(Collider hit, Plane[] planes)
    {
        if (hit.CompareTag("Enemy"))
        {
            Transform target = hit.transform;
            Renderer renderer = target.GetComponent<Renderer>();

            if (renderer != null && IsInFrustum(renderer, planes))
            {
                targetsInCamera.Add(target);

                if (IsInCone(target))
                {
                    targetsInCone.Add(target);
                }
            }
        }
    }

    // �I�u�W�F�N�g����������ɂ��邩�ǂ������m�F���郁�\�b�h
    private bool IsInFrustum(Renderer renderer, Plane[] planes)
    {
        return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
    }

    // �I�u�W�F�N�g���~�����ɂ��邩�ǂ������m�F���郁�\�b�h
    private bool IsInCone(Transform target)
    {
        Vector3 cameraPosition = _camera.transform.position;
        Vector3 cameraForward = _camera.transform.forward;

        Vector3 toObject = target.position - cameraPosition;
        float distanceToObject = toObject.magnitude;

        if (distanceToObject <= _searchRadius)
        {
            Vector3 toObjectNormalized = toObject.normalized;
            float angle = Vector3.Angle(cameraForward, toObjectNormalized);
            return angle <= _coneAngle / 2;
        }
        return false;
    }

    // �f�o�b�O�p�̃M�Y����`�悷�郁�\�b�h
    void OnDrawGizmos()
    {
        if (_camera != null)
        {
            // ����͈̔͂�`��
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(_camera.transform.position, _searchRadius);

            Gizmos.color = Color.yellow;

            var hoge = transform.position.z + Z;
            var hoge2 = new Vector3(transform.position.x, transform.position.y, hoge);
            GizmosExtensions.DrawWireCircle(hoge2, _coneAngle,20,Quaternion.Euler(-90,0,0));
            
            // �~���͈̔͂�`��
            Gizmos.color = Color.red;
            Vector3 forward = _camera.transform.forward * _searchRadius;
            Vector3 up = Quaternion.Euler(0, _coneAngle / 2, 0) * forward;
            Vector3 down = Quaternion.Euler(0, -_coneAngle / 2, 0) * forward;

            Gizmos.DrawLine(_camera.transform.position, _camera.transform.position + forward);
            Gizmos.DrawLine(_camera.transform.position, _camera.transform.position + up);
            Gizmos.DrawLine(_camera.transform.position, _camera.transform.position + down);

            Gizmos.DrawLine(_camera.transform.position + up, _camera.transform.position + down);
        }
    }
}
