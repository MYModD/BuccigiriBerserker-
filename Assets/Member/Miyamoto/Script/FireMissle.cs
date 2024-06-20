using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Rendering;


public class FireMissle : MonoBehaviour
{
    private IObjectPool<Missile> objectPool;

    [Header("ターゲット目標")]
    public List<Transform> targetObjectList ;

    public LockOnManager lockOnManager;//つぎここ直す

    [Header("発射位置")]
    [SerializeField] private Transform muzzlePosition;
    [Header("クールタイム")]
    [SerializeField] private float cooldownFire;

   


    private float nextTimeToShoot; // 次の時間計算するやつ

    // Start is called before the first frame update
    void Start()
    {
        PooledMissile pooledMissile = GetComponent<PooledMissile>();//FireMissleとPooledMissileが同じオブジェクトにないとダメだよ
        objectPool = pooledMissile.objectPool;

       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        targetObjectList = lockOnManager.targetsInCone;

       


        bool testBool = Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire2");//ここ分かりづらすぎるのであとで直します

        Debug.Log(testBool);

        if (testBool && Time.time > nextTimeToShoot && objectPool != null)
        {
            foreach (Transform target in lockOnManager.targetsInCone)
            {
                // Missileクラスのオブジェクトを取得
                Missile missileObject = objectPool.Get();
                
                if (missileObject == null) Debug.Log("オブジェクトがないよ");


                missileObject.target = target;//とりあえず一つから 

                // SetPositionAndRotationのほうが大量に生成したとき軽い
                missileObject.transform.SetPositionAndRotation(muzzlePosition.position, muzzlePosition.rotation);

                Debug.LogWarning($"{missileObject.name}{missileObject.transform.position}");

                // 発射されたら今の時間にクールダウンを追加する
                nextTimeToShoot = Time.time + cooldownFire;



                lockOnManager.targetsInCone.Clear();
                Debug.LogWarning(lockOnManager.targetsInCone[0]);
            }

        }
    }

    
}
