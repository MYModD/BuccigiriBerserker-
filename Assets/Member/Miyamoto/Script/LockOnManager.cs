using System.Collections.Generic;
using UnityEngine;
using Utils;

public class LockOnManager : MonoBehaviour
{
    // �J�����̎��E�ɓ����Ă���^�[�Q�b�g�̃��X�g
    public List<Transform> targetsInCamera = new List<Transform>();
    // ���̓��ɓ����Ă���^�[�Q�b�g�̃��X�g
    public List<Transform> targetsInCone = new List<Transform>();

    [SerializeField, Header("�Ȃ�̃J����")]
    private Camera _camera;

    [SerializeField, Header("spherecast�̔��a")]
    private float _searchRadius = 95f; 

    [SerializeField, Range(0f, 180f)]
    [Header("�R�[���̊p�x")]
    private float _coneAngle = 45f; 

    [SerializeField]
    [Header("�R�[���̒����A���a")]
    private float _coneRange;

     private Vector3 DrawOrigin = new Vector3 (90,0,0);    //�R�[���̉~���������邽�߂̂�� offset

    
    private void OnValidate()
    {
        if (_coneRange > _searchRadius)//coneRange��spherecast�ȉ��ɂ��鐧��X�N���v�g
        {
            _coneRange = _searchRadius;
        }
    }
    void Update()
    {
        // �^�[�Q�b�g���X�g���X�V
        UpdateTargets();
        DebugMatarialChange();


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
    /// <param name="target">�m�F����I�u�W�F�N�g��Transform</param>
    /// <returns>�I�u�W�F�N�g���~�����ɂ���ꍇ��true�A����ȊO�̏ꍇ��false</returns>
    private bool IsInCone(Transform target)
    {

        Vector3 cameraPosition = _camera.transform.position;  // �J�����̈ʒu���擾
        Vector3 cameraForward = _camera.transform.forward;   // �J�����̑O�����x�N�g�����擾

        Debug.Log($"{cameraPosition}+{cameraForward}");      // �f�o�b�O�p�ɃJ�����̈ʒu�ƕ��������O�ɏo��

        Vector3 toObject = target.position - cameraPosition; // �J�����ʒu����^�[�Q�b�g�ʒu�ւ̃x�N�g�����v�Z

        // �^�[�Q�b�g�܂ł̋������v�Z
        float distanceToObject = toObject.magnitude;                     // �x�N�g���̒����i�����j

        if (distanceToObject <= _coneRange)                           // �^�[�Q�b�g���������a���ɂ��邩�ǂ������m�F
        {
            Vector3 toObjectNormalized = toObject.normalized;                // �^�[�Q�b�g�ւ̃x�N�g���𐳋K���i�����݂̂��擾�j

            float angle = Vector3.Angle(cameraForward, toObjectNormalized); // �J�����̑O�����ƃ^�[�Q�b�g�ւ̕����Ƃ̊p�x���v�Z
            return angle <= _coneAngle / 2;                                // �p�x���R�[���̔����̊p�x�ȉ��ł����true��Ԃ�
        }

        // �^�[�Q�b�g���������a�O�ɂ���ꍇ��false��Ԃ�
        return false;
    }


    /// <summary>
    /// �f�o�b�O�p�̃M�Y����`�悷�郁�\�b�h unity���̃��\�b�h
    /// </summary>
    void OnDrawGizmos()
    {
        if (_camera != null)
        {
            // ����͈̔͂�`��
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(_camera.transform.position, _searchRadius);


            //�R�[����̉~����`��
            Gizmos.color = Color.yellow;
            var hoge = DrawOrigin + transform.rotation.eulerAngles;
            hoge.z = 0;                                                         //magicnum Z������0�ɂ���
            GizmosExtensions.DrawWireCircle(_camera.transform.position + (_camera.transform.forward * _coneRange), _coneAngle, 20, Quaternion.Euler(hoge));

            // �R�[���͈̔͂�`��
            Gizmos.color = Color.red;
            Vector3 forward = _camera.transform.forward * _coneRange;
            Vector3 up = Quaternion.Euler(0, _coneAngle / 2, 0) * forward;
            Vector3 down = Quaternion.Euler(0, -_coneAngle / 2, 0) * forward;

            Gizmos.DrawLine(_camera.transform.position, _camera.transform.position + forward);
            Gizmos.DrawLine(_camera.transform.position, _camera.transform.position + up);
            Gizmos.DrawLine(_camera.transform.position, _camera.transform.position + down);
            Gizmos.DrawLine(_camera.transform.position + up, _camera.transform.position + down);
        }
    }

    /// <summary>
    /// debug�p�Ƀ}�e���A���ς��邾�� ���������
    /// </summary>
    private void DebugMatarialChange()
    {
        for (int i = 0; i < targetsInCamera.Count; i++) 
        {
            targetsInCamera[i].GetComponent<MeshRenderer>().material.color = Color.blue;
        }
        for (int i = 0; i < targetsInCone.Count; i++)
        {
            targetsInCone[i].GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }
}
