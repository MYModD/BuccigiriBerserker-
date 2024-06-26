using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Rendering;

public class FireMissile : MonoBehaviour
{
    [Header("ターゲット位置")]
    public List<Transform> targetObjectList;

    [Header("lockOnManager参照")]
    public LockOnManager lockOnManager;

    [Header("発射音クラス参照")]
    public Fire1SE fire1SE;

    [Header("発射位置")]
    [SerializeField] private Transform muzzlePosition;

    [Header("クールダウン時間")]
    [SerializeField] private float cooldownFire;

    private IObjectPool<Missile> objectPool;

    private float nextTimeToShoot; // 次の発射時間を計算するための変数

    // Start is called before the first frame update
    void Start()
    {
        PooledMissile pooledMissile = GetComponent<PooledMissile>(); // FireMissileはPooledMissileを含むオブジェクトにアタッチされている必要がある
        objectPool = pooledMissile.objectPool;
    }

    // Update is called once per frame
    void Update()
    {
        targetObjectList = lockOnManager.targetsInCone;

        bool testBool = Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Submit"); // スペースキーが押されたかどうかをチェック

        if (testBool && Time.time > nextTimeToShoot)
        {
            // 次に発射できる時間を計算
            nextTimeToShoot = Time.time + cooldownFire;

            foreach (Transform target in lockOnManager.targetsInCone)
            {

                Debug.Log($"{"発射したよ"}+{target.name}");
                
                // Missileクラスのオブジェクトを取得
                Missile missileObject = objectPool.Get();

                if (missileObject == null)
                {
                    Debug.Log("オブジェクトが取得できませんでした");
                }

                missileObject.target = target; // 取得したミサイルのターゲットを設定

                // SetPositionAndRotationで位置と回転を設定
                missileObject.transform.SetPositionAndRotation(muzzlePosition.position, muzzlePosition.rotation);

                Debug.LogWarning($"{missileObject.name} {missileObject.transform.position}");

                fire1SE.fire1SE(); // 発射音を再生
            }

            //lockOnManager.targetsInCone.Clear();
        }
    }
}
