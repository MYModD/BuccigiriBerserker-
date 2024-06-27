using UnityEngine;
using UnityEngine.Pool;

public class PooledGun : MonoBehaviour
{
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

    private IObjectPool<Bullet> objectPool;
    [Header("初期の弾の数を設定")]
    [SerializeField] private int defaultCapacity = 20;
    [Header("最大容量")]
    [SerializeField] private int maxSize = 100;

    private float nextTimeToShoot;

    void Awake()
    {
        objectPool = new ObjectPool<Bullet>(
            CreateProjectile,
            OnGetFromPool,
            OnReleaseToPool,
            OnDestroyPooledObject,
            true, defaultCapacity, maxSize
        );

        for (int i = 0; i < defaultCapacity; i++)
        {
            objectPool.Release(CreateProjectile());
        }
    }

    #region オブジェクトプールの関数

    private Bullet CreateProjectile()
    {
        Bullet bulletInstance = Instantiate(gunPrefab);
        bulletInstance.ObjectPool = objectPool;
        SetBulletActive(bulletInstance, false);
        return bulletInstance;
    }

    private void OnGetFromPool(Bullet bulletObject)
    {
        SetBulletActive(bulletObject, true);
        Debug.Log("Bullet activated: " + bulletObject.gameObject.name);
    }

    private void OnReleaseToPool(Bullet pooledObject)
    {
        SetBulletActive(pooledObject, false);
    }

    private void OnDestroyPooledObject(Bullet pooledObject)
    {
        Destroy(pooledObject.gameObject);
        Debug.LogError("最大容量を超えたためオブジェクトを破棄しました");
    }

    private void SetBulletActive(Bullet bullet, bool isActive)
    {
        bullet.enabled = isActive;
        bullet.GetComponent<MeshRenderer>().enabled = isActive;
        bullet.GetComponent<SphereCollider>().enabled = isActive;
        bullet.GetComponent<Rigidbody>().isKinematic = !isActive;
    }

    #endregion

    private void Update()
    {
        if ((Input.GetKey(KeyCode.G) || Input.GetButton("Submit")) && Time.time > nextTimeToShoot )
        {
            Bullet bulletObject = objectPool.Get();
            if (bulletObject == null)
            {
                Debug.LogError("弾がnullです");
                return;
            }

            Vector3 randomSpread = new Vector3(
                Random.Range(-spreadAmount, spreadAmount),
                Random.Range(-spreadAmount, spreadAmount),
                Random.Range(-spreadAmount, spreadAmount)
            );
            Vector3 shootDirection = muzzlePosition.forward + randomSpread;
            bulletObject.transform.SetPositionAndRotation(muzzlePosition.position, Quaternion.LookRotation(shootDirection));
            bulletObject.GetComponent<Rigidbody>().AddForce(shootDirection.normalized * muzzleVelocity, ForceMode.Acceleration);

            nextTimeToShoot = Time.time + cooldownFire;
        }
    }
}
