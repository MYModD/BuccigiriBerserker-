using UnityEngine;
using UnityEngine.Pool;

public class PooledGun : MonoBehaviour
{
    [Header("class参照")][SerializeField] private Bullet gunPrefab;
    [Header("弾丸の速さ")][SerializeField] private float muzzleVelocity = 100f;
    [Header("発射位置")][SerializeField] private Transform muzzlePosition;
    [Header("クールタイム")][SerializeField] private float cooldownFire;

    private IObjectPool<Bullet> objectPool;   //bulletクラス型のみ扱う

    [Header("最初の生成数に応じて")]
    [Header("missleのtimerを変える")][SerializeField] private int defaultCapacity = 20;
    [Header("最大数")][SerializeField] private int maxSize = 100;


    private float nextTimeToShoot ;//後で書く




    void Awake()
    {
        objectPool = new ObjectPool<Bullet>(

            CreateProjectile,
            OnGetFromPool,
            OnReleaseToPool,
            OnDestroyPooledObject,
            true, defaultCapacity, maxSize
            );
        //生成初期化 コンストラクタ


        //最初に大量に生成して使い回す
        for (int i = 0; i < defaultCapacity; i++)
        {
            Bullet projectile = CreateProjectile();
            objectPool.Release(projectile);
        }
    }

    #region オブジェクトプールの処理

    
    //生成を行う関数
    private Bullet CreateProjectile()
    {
        Bullet bulletInstance = Instantiate(gunPrefab);
        bulletInstance.ObjectPool = objectPool;
        bulletInstance.gameObject.SetActive(false);
        return bulletInstance;
    }
    
    
    // プールから貸し出す時の処理
    private void OnGetFromPool(Bullet bulletObject)
    {
        bulletObject.gameObject.SetActive(true);
        Debug.Log("Bullet activated: " + bulletObject.gameObject.name);
    }


    //プールに返却する時の処理
    private void OnReleaseToPool(Bullet pooledObject)
    {
        pooledObject.gameObject.SetActive(false);
        print("返却");
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
        if(Input.GetKey(KeyCode.Space) && Time.time > nextTimeToShoot && objectPool != null)
        {
            //bullertクラスのオブジェクト？を取得
            Bullet bulletObject = objectPool.Get();
            if (bulletObject == null) return;
            print("通過");

            //SetPositionAndRotationのほうが大量に生成したとき軽いらしい、デモ版これでした
            bulletObject.transform.SetPositionAndRotation(muzzlePosition.position, muzzlePosition.rotation);

            //弾丸に前進*velocityのベクトル？力を加える forceModeをこれにするとMass関係なく飛ぶ
            bulletObject.GetComponent<Rigidbody>().AddForce(bulletObject.transform.forward * muzzleVelocity, ForceMode.Acceleration);



            //発射されたら今の時間にクールダウンを追加する
            nextTimeToShoot = Time.time + cooldownFire;
        }



    }
}

