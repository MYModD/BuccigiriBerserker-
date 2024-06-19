using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Rendering;

public class PooledMissile : MonoBehaviour
{
    //�e�ۂ̃X�N���v�g���R�s�[���������Ȃ̂ł��Ƃł��܂�
    //�����ڕW�^�[�Q�b�g�ɂł��Ă��Ȃ��̂ł����������


    [Header("class�Q��")]
    [SerializeField] private Missile missilePrefab;
    
    [Header("�ŏ��̐�����")]
    [SerializeField] private int defaultCapacity = 20;

    [Header("�ő吔")]
    [SerializeField] private int maxSize = 100;

    public IObjectPool<Missile> objectPool; //Missile�N���X�^�݈̂���

    public List<Transform> testList = new List<Transform>();

    public List<Missile> missileList = new List<Missile>();
    public List<MeshRenderer> renderList = new List<MeshRenderer>();
    public List<Rigidbody> rigidbodyList = new List<Rigidbody>();
    public List<CapsuleCollider> coliderList = new List<CapsuleCollider>();


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
            testList.Add(missile.transform);
            missileList.Add(missile.GetComponent<Missile>());
            renderList.Add(missile.GetComponent<MeshRenderer>());
            rigidbodyList.Add(missile.GetComponent<Rigidbody>());
            coliderList.Add(missile.GetComponent<CapsuleCollider>());
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

    


}
