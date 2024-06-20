using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Rendering;

public class PooledMissile : MonoBehaviour
{
    //弾丸のスクリプトをコピーしただけなのであとでやります
    //複数目標ターゲットにできていないのでおいおいやる


    [Header("class参照")]
    [SerializeField] private Missile missilePrefab;
    
    [Header("最初の生成数")]
    [SerializeField] private int defaultCapacity = 20;

    [Header("最大数")]
    [SerializeField] private int maxSize = 100;

    public IObjectPool<Missile> objectPool; //Missileクラス型のみ扱う

    public List<Transform> testList = new List<Transform>();

   


    void Awake()
    {
        objectPool = new  UnityEngine.Pool.ObjectPool<Missile>(
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

        //missileInstance.gameObject.SetActive(false); 下の方が処理軽いのでコメント化

        missileInstance.GetComponent<Missile>().enabled = false;
        missileInstance.GetComponent<MeshRenderer>().enabled = false;
        missileInstance.GetComponent<Rigidbody>().isKinematic = true;
        missileInstance.GetComponent<CapsuleCollider>().enabled = false;

        return missileInstance;
    }

    // プールから貸し出す時の処理
    private void OnGetFromPool(Missile missileObject)
    {
        //missileObject.gameObject.SetActive(true);下の方が処理軽いのでコメント化

        missileObject.GetComponent<Missile>().enabled = true;
        missileObject.GetComponent<MeshRenderer>().enabled = true;
        missileObject.GetComponent<Rigidbody>().isKinematic = false;
        missileObject.GetComponent<CapsuleCollider>().enabled = true;


        Debug.Log("Missile activated: " + missileObject.gameObject.name);
    }

    // プールに返却する時の処理
    private void OnReleaseToPool(Missile pooledObject)
    {
        //pooledObject.gameObject.SetActive(false);下の方が処理軽いのでコメント化

        pooledObject.GetComponent<Missile>().enabled = false;
        pooledObject.GetComponent<MeshRenderer>().enabled = false;
        pooledObject.GetComponent<Rigidbody>().isKinematic = true;
        pooledObject.GetComponent<CapsuleCollider>().enabled = false;

        //Debug.Log("Missile returned to pool: " + pooledObject.gameObject.name);
    }

    // プールの許容量を超えた時の削除処理
    private void OnDestroyPooledObject(Missile pooledObject)
    {
        Destroy(pooledObject.gameObject);
        Debug.LogError("Maximum pool size exceeded, destroying missile: " + pooledObject.gameObject.name);
    }

    #endregion

    


}
