using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Rendering;

public class FireMissle : MonoBehaviour
{
    private IObjectPool<Missile> objectPool;

    [Header("�^�[�Q�b�g�ڕW")]
    public List<Transform> targetObjectList = new List<Transform>();

    [Header("���ˈʒu")]
    [SerializeField] private Transform muzzlePosition;
    [Header("�N�[���^�C��")]
    [SerializeField] private float cooldownFire;


    private float nextTimeToShoot; // ���̎��Ԍv�Z������

    // Start is called before the first frame update
    void Start()
    {
        PooledMissile pooledMissile = GetComponent<PooledMissile>();//FireMissle��PooledMissile�������I�u�W�F�N�g�ɂȂ��ƃ_������
        objectPool = pooledMissile.objectPool;

        var pipelineAsset = GraphicsSettings.renderPipelineAsset;

        if (pipelineAsset == null)
        {
            Debug.Log("Using Built-in Render Pipeline");
        }
        else if (pipelineAsset.GetType().ToString().Contains("HDRenderPipelineAsset"))
        {
            Debug.Log("Using High Definition Render Pipeline (HDRP)");
        }
        else if (pipelineAsset.GetType().ToString().Contains("UniversalRenderPipelineAsset"))
        {
            Debug.Log("Using Universal Render Pipeline (URP)");
        }
        else
        {
            Debug.Log("Unknown Render Pipeline");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bool testBool = Input.GetKey(KeyCode.Space) || Input.GetButtonDown("Fire2");//����������Â炷����̂ł��ƂŒ����܂�

        if (testBool && Time.time > nextTimeToShoot && objectPool != null)
        {
            foreach (Transform target in targetObjectList)
            {
                // Missile�N���X�̃I�u�W�F�N�g���擾
                Missile missileObject = objectPool.Get();
                if (missileObject == null) Debug.Log("�I�u�W�F�N�g���Ȃ���");


                missileObject.target = target;//�Ƃ肠��������� 

                // SetPositionAndRotation�̂ق�����ʂɐ��������Ƃ��y��
                missileObject.transform.SetPositionAndRotation(muzzlePosition.position, muzzlePosition.rotation);

                // ���˂��ꂽ�獡�̎��ԂɃN�[���_�E����ǉ�����
                nextTimeToShoot = Time.time + cooldownFire;
            }

        }
    }

    
}
