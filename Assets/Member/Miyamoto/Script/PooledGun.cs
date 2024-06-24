using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class PooledGun : MonoBehaviour
{
<<<<<<< HEAD
    [Header("class�Q��")][SerializeField] private Bullet gunPrefab;
    [Header("�e�ۂ̑���")][SerializeField] private float muzzleVelocity = 100f;
    [Header("���ˈʒu")][SerializeField] private Transform muzzlePosition;
    [Header("�N�[���^�C��")][SerializeField] private float cooldownFire;

    private IObjectPool<Bullet> objectPool;   //bullet�N���X�^�݈̂���

    [Header("�ŏ��̐������ɉ�����")]
    [Header("missle��timer��ς���")][SerializeField] private int defaultCapacity = 20;
    [Header("�ő吔")][SerializeField] private int maxSize = 100;


    private float nextTimeToShoot;//���̎��Ԍv�Z������

=======
    [Header("クラス参照")]
    [SerializeField] private Bullet gunPrefab;
    [Header("弾の速度")]
    [SerializeField] private float muzzleVelocity = 100f;
    [Header("発射位置")]
    [SerializeField] private Transform muzzlePosition;
    [Header("クールダウン時間")]
    [SerializeField] private float cooldownFire;
    [Header("拡散量の範囲")]
    [Range(0, 0.1f)]
    [SerializeField] private float spreadAmount = 0.1f;

    private IObjectPool<Bullet> objectPool; // Bulletクラスだけを保持

    [Header("初期の弾の数を設定")]
    [SerializeField] private int defaultCapacity = 20;
    [Header("最大容量")]
    [SerializeField] private int maxSize = 100;

    private float nextTimeToShoot; // 次の発射時間を計算するための変数
>>>>>>> origin/Marged4.4.4.4

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

<<<<<<< HEAD

        //�ŏ��ɑ�ʂɐ������Ďg����
=======
        // 初期に弾を生成してプールに入れる
>>>>>>> origin/Marged4.4.4.4
        for (int i = 0; i < defaultCapacity; i++)
        {
            Bullet projectile = CreateProjectile();
            objectPool.Release(projectile);
        }
    }

<<<<<<< HEAD
    #region �I�u�W�F�N�g�v�[���̏���


    //�������s���֐�
=======
    #region オブジェクトプールの関数

    // 弾を生成する関数
>>>>>>> origin/Marged4.4.4.4
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

<<<<<<< HEAD

    // �v�[������݂��o�����̏���
=======
    // プールから取得した時の処理
>>>>>>> origin/Marged4.4.4.4
    private void OnGetFromPool(Bullet bulletObject)
    {
        //bulletObject.gameObject.SetActive(true); ���̕��������y���̂ŃR�����g��

        bulletObject.GetComponent<Bullet>().enabled = true;
        bulletObject.GetComponent<MeshRenderer>().enabled = true;
        bulletObject.GetComponent<SphereCollider>().enabled = true;
        bulletObject.GetComponent<Rigidbody>().isKinematic = false;

        

        Debug.Log("Bullet activated: " + bulletObject.gameObject.name);
    }

<<<<<<< HEAD

    //�v�[���ɕԋp���鎞�̏���
=======
    // プールに戻す時の処理
>>>>>>> origin/Marged4.4.4.4
    private void OnReleaseToPool(Bullet pooledObject)
    {
        //pooledObject.gameObject.SetActive(false);���̕��������y���̂ŃR�����g��

        pooledObject.GetComponent<Bullet>().enabled = false;
        pooledObject.GetComponent<MeshRenderer>().enabled = false;
        pooledObject.GetComponent<SphereCollider>().enabled = false;
        pooledObject.GetComponent<Rigidbody>().isKinematic = true;

        //print("�ԋp");
    }

<<<<<<< HEAD
    // �v�[���̋��e�ʂ𒴂������̍폜����
    private void OnDestroyPooledObject(Bullet pooledObject)
    {
        Destroy(pooledObject);
        Debug.LogError("�ő吔�𒴂����̂ō폜�����");
=======
    // プールのオブジェクトを破棄する処理
    private void OnDestroyPooledObject(Bullet pooledObject)
    {
        Destroy(pooledObject);
        Debug.LogError("最大容量を超えたためオブジェクトを破棄しました");
>>>>>>> origin/Marged4.4.4.4
    }

    #endregion


    private void FixedUpdate()
    {
        Debug.Log(Random.insideUnitCircle);

<<<<<<< HEAD

<<<<<<< HEAD

        bool testBool = Input.GetKey(KeyCode.G) || Input.GetButtonDown("submit");

        
        
       
=======
        bool testBool = Input.GetKey(KeyCode.G) || Input.GetButtonDown("Submit");
>>>>>>> origin/Marged4.4.4.4

=======
        bool testBool = Input.GetKey(KeyCode.G) || Input.GetButtonDown("Fire2");
>>>>>>> parent of d59c711 (なおし)
        if (testBool && Time.time > nextTimeToShoot && objectPool != null)
        {
            //bullert�N���X�̃I�u�W�F�N�g�H���擾
            Bullet bulletObject = objectPool.Get();
<<<<<<< HEAD
            if (bulletObject == null) return;


            //SetPositionAndRotation�̂ق�����ʂɐ��������Ƃ��y���炵���A�f���ł���ł���
            bulletObject.transform.SetPositionAndRotation(muzzlePosition.position, muzzlePosition.rotation);

            
            //var hoge = transform.forward * Quaternion
            
            
            //�e�ۂɑO�i*velocity�̃x�N�g���H�͂������� forceMode������ɂ����Mass�֌W�Ȃ����
            bulletObject.GetComponent<Rigidbody>().AddForce(bulletObject.transform.forward * muzzleVelocity, ForceMode.Acceleration);


=======
            if (bulletObject == null)
            {
                Debug.LogError("弾がnullです");
                return;
            }

            // 拡散量
            Vector3 randomSpread = new Vector3(
                Random.Range(-spreadAmount, spreadAmount),
                Random.Range(-spreadAmount, spreadAmount),
                Random.Range(-spreadAmount, spreadAmount)
            );
            Vector3 shootDirection = muzzlePosition.forward + randomSpread;

            // SetPositionAndRotationで位置と回転を設定
            bulletObject.transform.SetPositionAndRotation(muzzlePosition.position, Quaternion.LookRotation(shootDirection));

            // forceを使って弾を発射
            bulletObject.GetComponent<Rigidbody>().AddForce(shootDirection.normalized * muzzleVelocity, ForceMode.Acceleration);
>>>>>>> origin/Marged4.4.4.4

            //���˂��ꂽ�獡�̎��ԂɃN�[���_�E����ǉ����� �����X�N���v�g
            nextTimeToShoot = Time.time + cooldownFire;
        }



    }
}

