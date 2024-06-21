using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class PooledGun : MonoBehaviour
{
    [Header("class�Q��")]
    [SerializeField] private Bullet gunPrefab;
    [Header("�e�ۂ̑���")]
    [SerializeField] private float muzzleVelocity = 100f;
    [Header("���ˈʒu")]
    [SerializeField] private Transform muzzlePosition;
    [Header("�N�[���^�C��")]
    [SerializeField] private float cooldownFire;
    [Header("�΂炯��̗�")]
    [Range(0, 0.1f)]
    [SerializeField] private float spreadAmount = 0.1f;

    private IObjectPool<Bullet> objectPool; // bullet�N���X�^�݈̂���

    [Header("�ŏ��̐������ɉ�����")]
    [Header("missile��timer��ς���")]
    [SerializeField] private int defaultCapacity = 20;
    [Header("�ő吔")]
    [SerializeField] private int maxSize = 100;

    private float nextTimeToShoot; // ���̎��Ԍv�Z������

    void Awake()
    {
        objectPool = new ObjectPool<Bullet>(
            CreateProjectile,
            OnGetFromPool,
            OnReleaseToPool,
            OnDestroyPooledObject,
            true, defaultCapacity, maxSize
        );

        // �ŏ��ɑ�ʂɐ������Ďg����
        for (int i = 0; i < defaultCapacity; i++)
        {
            Bullet projectile = CreateProjectile();
            objectPool.Release(projectile);
        }
    }

    #region �I�u�W�F�N�g�v�[���̏���

    // �������s���֐�
    private Bullet CreateProjectile()
    {
        Bullet bulletInstance = Instantiate(gunPrefab);
        bulletInstance.ObjectPool = objectPool;

        bulletInstance.GetComponent<Bullet>().enabled = false;
        bulletInstance.GetComponent<MeshRenderer>().enabled = false;
        bulletInstance.GetComponent<SphereCollider>().enabled = false;
        bulletInstance.GetComponent<Rigidbody>().isKinematic = true;

        return bulletInstance;
    }

    // �v�[������݂��o�����̏���
    private void OnGetFromPool(Bullet bulletObject)
    {
        bulletObject.GetComponent<Bullet>().enabled = true;
        bulletObject.GetComponent<MeshRenderer>().enabled = true;
        bulletObject.GetComponent<SphereCollider>().enabled = true;
        bulletObject.GetComponent<Rigidbody>().isKinematic = false;

        Debug.Log("Bullet activated: " + bulletObject.gameObject.name);
    }

    // �v�[���ɕԋp���鎞�̏���
    private void OnReleaseToPool(Bullet pooledObject)
    {
        pooledObject.GetComponent<Bullet>().enabled = false;
        pooledObject.GetComponent<MeshRenderer>().enabled = false;
        pooledObject.GetComponent<SphereCollider>().enabled = false;
        pooledObject.GetComponent<Rigidbody>().isKinematic = true;
    }

    // �v�[���̋��e�ʂ𒴂������̍폜����
    private void OnDestroyPooledObject(Bullet pooledObject)
    {
        Destroy(pooledObject);
        Debug.LogError("�ő吔�𒴂����̂ō폜�����");
    }

    #endregion

    private void FixedUpdate()
    {
        Debug.Log(Random.insideUnitCircle);



        bool testBool = Input.GetKey(KeyCode.G) || Input.GetButtonDown("submit");

        
        
       

        if (testBool && Time.time > nextTimeToShoot && objectPool != null)
        {
            Bullet bulletObject = objectPool.Get();
            if (bulletObject == null) return; Debug.LogError("�ʂ�null���ɂ�");

            // �΂炯��
            Vector3 randomSpread = new Vector3(
                Random.Range(-spreadAmount, spreadAmount),
                Random.Range(-spreadAmount, spreadAmount),
                Random.Range(-spreadAmount, spreadAmount)
            );
            Vector3 shootDirection = muzzlePosition.forward + randomSpread;


            //SetPositionAndRotation�̂ق����y���炵��������
            bulletObject.transform.SetPositionAndRotation(muzzlePosition.position, Quaternion.LookRotation(shootDirection));


            //force���[�h��Acceleration�ɂ���Əd���֌W�Ȃ����
            bulletObject.GetComponent<Rigidbody>().AddForce(shootDirection.normalized * muzzleVelocity, ForceMode.Acceleration);

            nextTimeToShoot = Time.time + cooldownFire;
        }
    }
}
