using Unity.VisualScripting;
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

    private IObjectPool<Bullet> objectPool; // Bulletクラスだけを保持

    [Header("初期の弾の数を設定")]
    [SerializeField] private int defaultCapacity = 20;
    [Header("最大容量")]
    [SerializeField] private int maxSize = 100;

    private float nextTimeToShoot; // 次の発射時間を計算するための変数

    void Awake()
    {
        objectPool = new ObjectPool<Bullet>(
            CreateProjectile,
            OnGetFromPool,
            OnReleaseToPool,
            OnDestroyPooledObject,
            true, defaultCapacity, maxSize
        );

        // 初期に弾を生成してプールに入れる
        for (int i = 0; i < defaultCapacity; i++)
        {
            Bullet projectile = CreateProjectile();
            objectPool.Release(projectile);
        }
    }

    #region オブジェクトプールの関数

    // 弾を生成する関数
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

    // プールから取得した時の処理
    private void OnGetFromPool(Bullet bulletObject)
    {
        bulletObject.GetComponent<Bullet>().enabled = true;
        bulletObject.GetComponent<MeshRenderer>().enabled = true;
        bulletObject.GetComponent<SphereCollider>().enabled = true;
        bulletObject.GetComponent<Rigidbody>().isKinematic = false;

        Debug.Log("Bullet activated: " + bulletObject.gameObject.name);
    }

    // プールに戻す時の処理
    private void OnReleaseToPool(Bullet pooledObject)
    {
        pooledObject.GetComponent<Bullet>().enabled = false;
        pooledObject.GetComponent<MeshRenderer>().enabled = false;
        pooledObject.GetComponent<SphereCollider>().enabled = false;
        pooledObject.GetComponent<Rigidbody>().isKinematic = true;
    }

    // プールのオブジェクトを破棄する処理
    private void OnDestroyPooledObject(Bullet pooledObject)
    {
        Destroy(pooledObject);
        Debug.LogError("最大容量を超えたためオブジェクトを破棄しました");
    }

    #endregion

    private void FixedUpdate()
    {
        Debug.Log(Random.insideUnitCircle);

        bool testBool = Input.GetKey(KeyCode.G) || Input.GetButtonDown("Submit");

        if (testBool && Time.time > nextTimeToShoot && objectPool != null)
        {
            Bullet bulletObject = objectPool.Get();
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

            nextTimeToShoot = Time.time + cooldownFire;
        }
    }
}
