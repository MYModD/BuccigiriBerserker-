using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class PooledGun : MonoBehaviour
{
    [Header("class参照")]
    [SerializeField] private Bullet gunPrefab;
    [Header("弾丸の速さ")]
    [SerializeField] private float muzzleVelocity = 100f;
    [Header("発射位置")]
    [SerializeField] private Transform muzzlePosition;
    [Header("クールタイム")]
    [SerializeField] private float cooldownFire;
    [Header("ばらけりの量")]
    [Range(0, 0.1f)]
    [SerializeField] private float spreadAmount = 0.1f;

    private IObjectPool<Bullet> objectPool; // bulletクラス型のみ扱う

    [Header("最初の生成数に応じて")]
    [Header("missileのtimerを変える")]
    [SerializeField] private int defaultCapacity = 20;
    [Header("最大数")]
    [SerializeField] private int maxSize = 100;

    private float nextTimeToShoot; // つぎの時間計算するやつ

    void Awake()
    {
        objectPool = new ObjectPool<Bullet>(
            CreateProjectile,
            OnGetFromPool,
            OnReleaseToPool,
            OnDestroyPooledObject,
            true, defaultCapacity, maxSize
        );

        // 最初に大量に生成して使い回す
        for (int i = 0; i < defaultCapacity; i++)
        {
            Bullet projectile = CreateProjectile();
            objectPool.Release(projectile);
        }
    }

    #region オブジェクトプールの処理

    // 生成を行う関数
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

    // プールから貸し出す時の処理
    private void OnGetFromPool(Bullet bulletObject)
    {
        bulletObject.GetComponent<Bullet>().enabled = true;
        bulletObject.GetComponent<MeshRenderer>().enabled = true;
        bulletObject.GetComponent<SphereCollider>().enabled = true;
        bulletObject.GetComponent<Rigidbody>().isKinematic = false;

        Debug.Log("Bullet activated: " + bulletObject.gameObject.name);
    }

    // プールに返却する時の処理
    private void OnReleaseToPool(Bullet pooledObject)
    {
        pooledObject.GetComponent<Bullet>().enabled = false;
        pooledObject.GetComponent<MeshRenderer>().enabled = false;
        pooledObject.GetComponent<SphereCollider>().enabled = false;
        pooledObject.GetComponent<Rigidbody>().isKinematic = true;
    }

    // プールの許容量を超えた時の削除処理
    private void OnDestroyPooledObject(Bullet pooledObject)
    {
        Destroy(pooledObject);
        Debug.LogError("最大数を超えたので削除するよ");
    }

    #endregion

    private void FixedUpdate()
    {
        bool testBool = Input.GetKey(KeyCode.G) || Input.GetButtonDown("Fire2");
        if (testBool && Time.time > nextTimeToShoot && objectPool != null)
        {
            Bullet bulletObject = objectPool.Get();
            if (bulletObject == null) return; Debug.LogError("玉がnullだにょ");

            // ばらけり
            Vector3 randomSpread = new Vector3(
                Random.Range(-spreadAmount, spreadAmount),
                Random.Range(-spreadAmount, spreadAmount),
                Random.Range(-spreadAmount, spreadAmount)
            );
            Vector3 shootDirection = muzzlePosition.forward + randomSpread;


            //SetPositionAndRotationのほうが軽いらしいっすよ
            bulletObject.transform.SetPositionAndRotation(muzzlePosition.position, Quaternion.LookRotation(shootDirection));


            //forceモードをAccelerationにすると重さ関係なく飛ぶ
            bulletObject.GetComponent<Rigidbody>().AddForce(shootDirection.normalized * muzzleVelocity, ForceMode.Acceleration);

            nextTimeToShoot = Time.time + cooldownFire;
        }
    }
}
