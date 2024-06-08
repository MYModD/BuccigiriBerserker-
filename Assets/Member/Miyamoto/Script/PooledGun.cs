using UnityEngine;
using UnityEngine.Pool;

public class PooledGun : MonoBehaviour
{
    [Header("class�Q��")][SerializeField] private Bullet gunPrefab;
    [Header("�e�ۂ̑���")][SerializeField] private float muzzleVelocity = 100f;
    [Header("���ˈʒu")][SerializeField] private Transform muzzlePosition;
    [Header("�N�[���^�C��")][SerializeField] private float cooldownFire;

    private IObjectPool<Bullet> objectPool;   //bullet�N���X�^�݈̂���

    [Header("�ŏ��̐������ɉ�����")]
    [Header("missle��timer��ς���")][SerializeField] private int defaultCapacity = 20;
    [Header("�ő吔")][SerializeField] private int maxSize = 100;


    private float nextTimeToShoot ;//��ŏ���




    void Awake()
    {
        objectPool = new ObjectPool<Bullet>(

            CreateProjectile,
            OnGetFromPool,
            OnReleaseToPool,
            OnDestroyPooledObject,
            true, defaultCapacity, maxSize
            );
        //���������� �R���X�g���N�^


        //�ŏ��ɑ�ʂɐ������Ďg����
        for (int i = 0; i < defaultCapacity; i++)
        {
            Bullet projectile = CreateProjectile();
            objectPool.Release(projectile);
        }
    }

    #region �I�u�W�F�N�g�v�[���̏���

    
    //�������s���֐�
    private Bullet CreateProjectile()
    {
        Bullet bulletInstance = Instantiate(gunPrefab);
        bulletInstance.ObjectPool = objectPool;
        bulletInstance.gameObject.SetActive(false);
        return bulletInstance;
    }
    
    
    // �v�[������݂��o�����̏���
    private void OnGetFromPool(Bullet bulletObject)
    {
        bulletObject.gameObject.SetActive(true);
        Debug.Log("Bullet activated: " + bulletObject.gameObject.name);
    }


    //�v�[���ɕԋp���鎞�̏���
    private void OnReleaseToPool(Bullet pooledObject)
    {
        pooledObject.gameObject.SetActive(false);
        print("�ԋp");
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
        if(Input.GetKey(KeyCode.Space) && Time.time > nextTimeToShoot && objectPool != null)
        {
            //bullert�N���X�̃I�u�W�F�N�g�H���擾
            Bullet bulletObject = objectPool.Get();
            if (bulletObject == null) return;
            print("�ʉ�");

            //SetPositionAndRotation�̂ق�����ʂɐ��������Ƃ��y���炵���A�f���ł���ł���
            bulletObject.transform.SetPositionAndRotation(muzzlePosition.position, muzzlePosition.rotation);

            //�e�ۂɑO�i*velocity�̃x�N�g���H�͂������� forceMode������ɂ����Mass�֌W�Ȃ����
            bulletObject.GetComponent<Rigidbody>().AddForce(bulletObject.transform.forward * muzzleVelocity, ForceMode.Acceleration);



            //���˂��ꂽ�獡�̎��ԂɃN�[���_�E����ǉ�����
            nextTimeToShoot = Time.time + cooldownFire;
        }



    }
}

