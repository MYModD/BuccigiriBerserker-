using Unity.VisualScripting;
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


    private float nextTimeToShoot;//���̎��Ԍv�Z������


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

        //bulletInstance.gameObject.SetActive(false);   ���̕��������y���̂ŃR�����g��

        bulletInstance.GetComponent<Bullet>().enabled = false;
        bulletInstance.GetComponent<MeshRenderer>().enabled = false;
        bulletInstance.GetComponent<SphereCollider>().enabled = false;
        bulletInstance.GetComponent<Rigidbody>().isKinematic = true;

        return bulletInstance;
    }


    // �v�[������݂��o�����̏���
    private void OnGetFromPool(Bullet bulletObject)
    {
        //bulletObject.gameObject.SetActive(true); ���̕��������y���̂ŃR�����g��

        bulletObject.GetComponent<Bullet>().enabled = true;
        bulletObject.GetComponent<MeshRenderer>().enabled = true;
        bulletObject.GetComponent<SphereCollider>().enabled = true;
        bulletObject.GetComponent<Rigidbody>().isKinematic = false;

        

        Debug.Log("Bullet activated: " + bulletObject.gameObject.name);
    }


    //�v�[���ɕԋp���鎞�̏���
    private void OnReleaseToPool(Bullet pooledObject)
    {
        //pooledObject.gameObject.SetActive(false);���̕��������y���̂ŃR�����g��

        pooledObject.GetComponent<Bullet>().enabled = false;
        pooledObject.GetComponent<MeshRenderer>().enabled = false;
        pooledObject.GetComponent<SphereCollider>().enabled = false;
        pooledObject.GetComponent<Rigidbody>().isKinematic = true;

        //print("�ԋp");
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


<<<<<<< HEAD

        bool testBool = Input.GetKey(KeyCode.G) || Input.GetButtonDown("submit");

        
        
       

=======
        bool testBool = Input.GetKey(KeyCode.G) || Input.GetButtonDown("Fire2");
>>>>>>> parent of d59c711 (なおし)
        if (testBool && Time.time > nextTimeToShoot && objectPool != null)
        {
            //bullert�N���X�̃I�u�W�F�N�g�H���擾
            Bullet bulletObject = objectPool.Get();
            if (bulletObject == null) return;


            //SetPositionAndRotation�̂ق�����ʂɐ��������Ƃ��y���炵���A�f���ł���ł���
            bulletObject.transform.SetPositionAndRotation(muzzlePosition.position, muzzlePosition.rotation);

            
            //var hoge = transform.forward * Quaternion
            
            
            //�e�ۂɑO�i*velocity�̃x�N�g���H�͂������� forceMode������ɂ����Mass�֌W�Ȃ����
            bulletObject.GetComponent<Rigidbody>().AddForce(bulletObject.transform.forward * muzzleVelocity, ForceMode.Acceleration);



            //���˂��ꂽ�獡�̎��ԂɃN�[���_�E����ǉ����� �����X�N���v�g
            nextTimeToShoot = Time.time + cooldownFire;
        }



    }
}

