using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq; // LINQ���g�p���邽�߂ɕK�v

public class PlayerLockon : MonoBehaviour
{
    [SerializeField]
    Camera _lockcamera;

    [SerializeField]
    GameObject _player;

    private float _search_distance = 80f;
    // �O�̃t���[���Ŏ�������ɂ������I�u�W�F�N�g�̃��X�g
    List<Transform> previousVisibleObjects = new List<Transform>();


    // Start is called before the first frame update
    void Start()
    {
        //list = GeometryUtility.CalculateFrustumPlanes(_lockcamera);
        //_enemyobjCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // ������̕��ʂ��擾
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(_lockcamera);

        // ���݂̃V�[�����̂��ׂĂ�GameObject���擾
        List<Transform> allObjects = new List<Transform>();

        // ��������ɂ���GameObject���i�[���郊�X�g���쐬
        List<Transform> visibleObjects = new List<Transform>();

        RaycastHit[] _hits = Physics.SphereCastAll(
        _player.transform.position,
        _search_distance,
        _player.transform.forward,
        0.01f, LayerMask.GetMask("Enemy"));

        foreach (RaycastHit _hit in _hits)
        {
            // �q�b�g�����I�u�W�F�N�g��Enemy���C���[�Ɋ܂܂��ꍇ�̂݃��X�g�ɒǉ�
            if (_hit.collider.gameObject.CompareTag("Enemy"))
            {
                allObjects.Add(_hit.collider.transform);

                // �����ŁA�q�b�g�����I�u�W�F�N�g�ɑ΂���ǉ��̏������s�����Ƃ��ł��܂�
                _hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.red;
            }
        }
        // ���ׂĂ�GameObject�ɑ΂��Ď�����̓����ɂ��邩�ǂ������e�X�g
        foreach (Transform obj in allObjects)
        {
            Renderer renderer = obj.GetComponent<Renderer>();
            if (renderer != null)
            {
                // �I�u�W�F�N�g�̋��E�{�b�N�X��������ƌ������邩�ǂ������m�F
                if (GeometryUtility.TestPlanesAABB(planes, renderer.bounds))
                {
                    // ��������ɂ���I�u�W�F�N�g�����X�g�ɒǉ�
                    visibleObjects.Add(obj);
                }
            }
        }

        // ���I�u�W�F�N�g�ɑ΂��ĉ�������̏������s��
        foreach (Transform obj in visibleObjects)
        {
            // �Ⴆ�΁A���I�u�W�F�N�g�̐F��ύX����Ȃ�
            obj.GetComponent<Renderer>().material.color = Color.blue;
        }

        // �O�̃t���[���Ŏ�������ɂ������I�u�W�F�N�g�̂����A
        // ���݂̃t���[���ł͂Ȃ��Ȃ����I�u�W�F�N�g�����X�g����폜
        foreach (Transform obj in previousVisibleObjects)
        {
            if (!visibleObjects.Contains(obj))
            {
                // �I�u�W�F�N�g�������䂩��O�ꂽ�̂ŁA���X�g����폜
                // �Ⴆ�΁A�I�u�W�F�N�g�̐F�����ɖ߂��Ȃǂ̏������s�����Ƃ��ł��܂�
                obj.GetComponent<Renderer>().material.color = Color.white;
            }
        }

        // �O�̃t���[���Ŏ�������ɂ������I�u�W�F�N�g�̃��X�g���X�V
        previousVisibleObjects = visibleObjects;
    }
}
       
    












    

