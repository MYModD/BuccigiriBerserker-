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



    /// <summary>
    /// �`�悷����̂�����update
    /// </summary>
    void Update()
    {
        // �^�[�Q�b�g���X�g���X�V
        UpdateTargets();

    }

    // �^�[�Q�b�g���X�g���X�V���郁�\�b�h
    private void UpdateTargets()
    {
        // �J�����̎����䕽�ʂ��擾
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(_camera);

        targetsInCamera.Clear();
        targetsInCone.Clear();
       
        Collider[] hits = GetSphereOverlapHits();    //collider���Ԃ�l

        foreach (Collider hit in hits)
        {
            // �q�b�g�����I�u�W�F�N�g������
            ProcessHit(hit, planes);
            
        }
    }

    /// <summary>
    /// ����͈͓̔��̃q�b�g�����R���C�_�[���擾���郁�\�b�h
    /// </summary>
    private Collider[] GetSphereOverlapHits()
    {
        return Physics.OverlapSphere(
            _camera.transform.position,
            _searchRadius,
            LayerMask.GetMask("Enemy")                        //���C���[�}�X�N��enemy����tag��enemy�̂Ƃ�
        );
    }



    /// <summary>
    /// �q�b�g�����I�u�W�F�N�g���������郁�\�b�h  
    /// </summary>
    /// <param name="hit">�R���C�_�[�^ �I�u�W�F�N�g�����ʂ���</param>
    /// <param name="planes">�J�����̐}�`��Plane�^�ŕ\��������</param>
     
    private void ProcessHit(Collider hit, Plane[] planes)
    {
        if (hit.CompareTag("Enemy"))
        {
            Transform target = hit.transform;
            Renderer renderer = target.GetComponent<Renderer>();

            if (renderer != null && IsInFrustum(renderer, planes))
            {
                targetsInCamera.Add(target);              //�J�����͈͓��̃��X�g�ɂ����

                if (IsInCone(target))
                {
                    targetsInCone.Add(target);            //�R�[�����̃��X�g�ɂ����
                }
            }
        }
    }


    /// <summary>
    /// �I�u�W�F�N�g����������ɂ��邩�ǂ������m�F���郁�\�b�h
    /// </summary>
    private bool IsInFrustum(Renderer renderer, Plane[] planes)
    {
        return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);    //testPlanesAABB�ŃJ�����̌`��colider��bounds�Ō����Ă��邩�𔻒f����
    }

    /// <summary>
    /// �I�u�W�F�N�g���~�����ɂ��邩�ǂ������m�F���郁�\�b�h
    /// </summary>
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

            
            //�R�[����̉~����`��
            Gizmos.color = Color.yellow;    
            
            GizmosExtensions.DrawWireCircle(_camera.transform.position + (_camera.transform.forward * _searchRadius), _coneAngle,20,Quaternion.Euler(90,0,0));
            
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