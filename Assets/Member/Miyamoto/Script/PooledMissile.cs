using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PooledMissile : MonoBehaviour
{
    //弾丸のスクリプトをコピーしただけなのであとでやります
    //複数目標ターゲットにできていないのでおいおいやる
    
    
    [Header("class参照")]
    [SerializeField] private Missile missilePrefab;
    [Header("弾丸の速さ")]
    [SerializeField] private float muzzleVelocity = 100f;
    [Header("発射位置")]
    [SerializeField] private Transform muzzlePosition;
    [Header("クールタイム")]
    [SerializeField] private float cooldownFire;

    private IObjectPool<Missile> objectPool; //Missileクラス型のみ扱う

    [Header("最初の生成数に応じて")]
    [Header("missileのtimerを変える")]
    [SerializeField] private int defaultCapacity = 20;
    [Header("最大数")]
    [SerializeField] private int maxSize = 100;

    private float nextTimeToShoot; // 次の時間計算するやつ

    void Awake()
    {
        objectPool = new ObjectPool<Missile>(
            CreateProjectile,
            OnGetFromPool,
            OnReleaseToPool,
            OnDestroyPooledObject,
            true, defaultCapacity, maxSize
        );
        // 生成初期化 コンストラクタ

        // 最初に大量に生成して使い回す
        for (int i = 0; i < defaultCapacity; i++)
        {
            Missile missile = CreateProjectile();
            objectPool.Release(missile);
        }
    }

    #region オブジェクトプールの処理

    // 生成を行う関数
    private Missile CreateProjectile()
    {
        Missile missileInstance = Instantiate(missilePrefab);
        missileInstance.ObjectPool = objectPool;
        missileInstance.gameObject.SetActive(false);
        return missileInstance;
    }

    // プールから貸し出す時の処理
    private void OnGetFromPool(Missile missileObject)
    {
        missileObject.gameObject.SetActive(true);
        Debug.Log("Missile activated: " + missileObject.gameObject.name);
    }

    // プールに返却する時の処理
    private void OnReleaseToPool(Missile pooledObject)
    {
        pooledObject.gameObject.SetActive(false);
        Debug.Log("Missile returned to pool: " + pooledObject.gameObject.name);
    }

    // プールの許容量を超えた時の削除処理
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
            // Missileクラスのオブジェクトを取得
            Missile missileObject = objectPool.Get();
            if (missileObject == null) return;

            // SetPositionAndRotationのほうが大量に生成したとき軽い
            missileObject.transform.SetPositionAndRotation(muzzlePosition.position, muzzlePosition.rotation);

            // 弾丸に前進*velocityのベクトル力を加える ForceModeをこれにするとMass関係なく飛ぶ
            missileObject.GetComponent<Rigidbody>().AddForce(missileObject.transform.forward * muzzleVelocity, ForceMode.Acceleration);

            // 発射されたら今の時間にクールダウンを追加する
            nextTimeToShoot = Time.time + cooldownFire;
        }
    }
}
