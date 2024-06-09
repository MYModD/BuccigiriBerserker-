using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PooledMissile : MonoBehaviour
{
    //�e�ۂ̃X�N���v�g���R�s�[���������Ȃ̂ł��Ƃł��܂�
    //�����ڕW�^�[�Q�b�g�ɂł��Ă��Ȃ��̂ł����������
    
    
    [Header("class�Q��")]
    [SerializeField] private Missile missilePrefab;
    [Header("�e�ۂ̑���")]
    [SerializeField] private float muzzleVelocity = 100f;
    [Header("���ˈʒu")]
    [SerializeField] private Transform muzzlePosition;
    [Header("�N�[���^�C��")]
    [SerializeField] private float cooldownFire;

    private IObjectPool<Missile> objectPool; //Missile�N���X�^�݈̂���

    [Header("�ŏ��̐������ɉ�����")]
    [Header("missile��timer��ς���")]
    [SerializeField] private int defaultCapacity = 20;
    [Header("�ő吔")]
    [SerializeField] private int maxSize = 100;

    private float nextTimeToShoot; // ���̎��Ԍv�Z������

    void Awake()
    {
        objectPool = new ObjectPool<Missile>(
            CreateProjectile,
            OnGetFromPool,
            OnReleaseToPool,
            OnDestroyPooledObject,
            true, defaultCapacity, maxSize
        );
        // ���������� �R���X�g���N�^

        // �ŏ��ɑ�ʂɐ������Ďg����
        for (int i = 0; i < defaultCapacity; i++)
        {
            Missile missile = CreateProjectile();
            objectPool.Release(missile);
        }
    }

    #region �I�u�W�F�N�g�v�[���̏���

    // �������s���֐�
    private Missile CreateProjectile()
    {
        Missile missileInstance = Instantiate(missilePrefab);
        missileInstance.ObjectPool = objectPool;
        missileInstance.gameObject.SetActive(false);
        return missileInstance;
    }

    // �v�[������݂��o�����̏���
    private void OnGetFromPool(Missile missileObject)
    {
        missileObject.gameObject.SetActive(true);
        Debug.Log("Missile activated: " + missileObject.gameObject.name);
    }

    // �v�[���ɕԋp���鎞�̏���
    private void OnReleaseToPool(Missile pooledObject)
    {
        pooledObject.gameObject.SetActive(false);
        Debug.Log("Missile returned to pool: " + pooledObject.gameObject.name);
    }

    // �v�[���̋��e�ʂ𒴂������̍폜����
    private void OnDestroyPooledObject(Missile pooledObject)
    {
        Destroy(pooledObject.gameObject);
        Debug.LogError("Maximum pool size exceeded, destroying missile: " + pooledObject.gameObject.name);
    }

    #endregion

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time > nextTimeToShoot && objectPool != null)
        {
            // Missile�N���X�̃I�u�W�F�N�g���擾
            Missile missileObject = objectPool.Get();
            if (missileObject == null) return;

            // SetPositionAndRotation�̂ق�����ʂɐ��������Ƃ��y��
            missileObject.transform.SetPositionAndRotation(muzzlePosition.position, muzzlePosition.rotation);

            // �e�ۂɑO�i*velocity�̃x�N�g���͂������� ForceMode������ɂ����Mass�֌W�Ȃ����
            missileObject.GetComponent<Rigidbody>().AddForce(missileObject.transform.forward * muzzleVelocity, ForceMode.Acceleration);

            // ���˂��ꂽ�獡�̎��ԂɃN�[���_�E����ǉ�����
            nextTimeToShoot = Time.time + cooldownFire;
        }
    }
}
