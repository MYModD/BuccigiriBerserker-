using Unity.VisualScripting;
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


    private float nextTimeToShoot;//つぎの時間計算するやつ


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

        //bulletInstance.gameObject.SetActive(false);   下の方が処理軽いのでコメント化

        bulletInstance.GetComponent<Bullet>().enabled = false;
        bulletInstance.GetComponent<MeshRenderer>().enabled = false;
        bulletInstance.GetComponent<SphereCollider>().enabled = false;
        bulletInstance.GetComponent<Rigidbody>().isKinematic = true;

        return bulletInstance;
    }


    // プールから貸し出す時の処理
    private void OnGetFromPool(Bullet bulletObject)
    {
        //bulletObject.gameObject.SetActive(true); 下の方が処理軽いのでコメント化

        bulletObject.GetComponent<Bullet>().enabled = true;
        bulletObject.GetComponent<MeshRenderer>().enabled = true;
        bulletObject.GetComponent<SphereCollider>().enabled = true;
        bulletObject.GetComponent<Rigidbody>().isKinematic = false;

        

        Debug.Log("Bullet activated: " + bulletObject.gameObject.name);
    }


    //プールに返却する時の処理
    private void OnReleaseToPool(Bullet pooledObject)
    {
        //pooledObject.gameObject.SetActive(false);下の方が処理軽いのでコメント化

        pooledObject.GetComponent<Bullet>().enabled = false;
        pooledObject.GetComponent<MeshRenderer>().enabled = false;
        pooledObject.GetComponent<SphereCollider>().enabled = false;
        pooledObject.GetComponent<Rigidbody>().isKinematic = true;

        //print("返却");
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
        Debug.Log(Random.insideUnitCircle);


<<<<<<< HEAD

        bool testBool = Input.GetKey(KeyCode.G) || Input.GetButtonDown("submit");

        
        
       

=======
        bool testBool = Input.GetKey(KeyCode.G) || Input.GetButtonDown("Fire2");
>>>>>>> parent of d59c711 (縺ｪ縺翫＠)
        if (testBool && Time.time > nextTimeToShoot && objectPool != null)
        {
            //bullertクラスのオブジェクト？を取得
            Bullet bulletObject = objectPool.Get();
            if (bulletObject == null) return;


            //SetPositionAndRotationのほうが大量に生成したとき軽いらしい、デモ版これでした
            bulletObject.transform.SetPositionAndRotation(muzzlePosition.position, muzzlePosition.rotation);

            
            //var hoge = transform.forward * Quaternion
            
            
            //弾丸に前進*velocityのベクトル？力を加える forceModeをこれにするとMass関係なく飛ぶ
            bulletObject.GetComponent<Rigidbody>().AddForce(bulletObject.transform.forward * muzzleVelocity, ForceMode.Acceleration);



            //発射されたら今の時間にクールダウンを追加する 賢いスクリプト
            nextTimeToShoot = Time.time + cooldownFire;
        }



    }
}

