using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Rendering;

public class FireMissile : MonoBehaviour
{
    private IObjectPool<Missile> objectPool;

    [Header("debug用InCone")]
    public List<Transform> targetObjectInCone;

    [Header("debug用InSide")]
    public Transform[] targetObjectInSide;

    public LockOnManager lockOnManager;

    [Header("発射位置")]
    [SerializeField] private Transform muzzlePosition;
    [Header("クールダウン時間")]
    [SerializeField] private float cooldownFire;

    private float nextTimeToShoot; // 次の発射時間を計算するための変数

    // Start is called before the first frame update
    void Start()
    {
        PooledMissile pooledMissile = GetComponent<PooledMissile>();//FireMissileはPooledMissileを含むオブジェクトにアタッチされている必要がある
        objectPool = pooledMissile.objectPool;

        var pipelineAsset = GraphicsSettings.renderPipelineAsset;

        if (pipelineAsset == null)
        {
            Debug.Log("Using Built-in Render Pipeline");
        }
        else if (pipelineAsset.GetType().ToString().Contains("HDRenderPipelineAsset"))
        {
            Debug.Log("Using High Definition Render Pipeline (HDRP)");
        }
        else if (pipelineAsset.GetType().ToString().Contains("UniversalRenderPipelineAsset"))
        {
            Debug.Log("Using Universal Render Pipeline (URP)");
        }
        else
        {
            Debug.Log("Unknown Render Pipeline");
        }
    }

    // Update is called once per frame
    void Update()
    {
        targetObjectInCone = lockOnManager.targetsInCone;
        targetObjectInSide = lockOnManager.targetsInSide;


        bool testBool = Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire2");//スペースキーまたはFire2ボタンが押されたかどうかをチェック

        if (testBool && Time.time > nextTimeToShoot && objectPool != null)
        {

            if (lockOnManager.isSpecial)
            {

                Debug.Log("発射条件を満たしました");
                nextTimeToShoot = Time.time + cooldownFire;
                foreach (Transform target in lockOnManager.targetsInCone)
                {
                    Debug.Log($"ターゲット: {target.name}");

                    // Missileクラスのオブジェクトを取得
                    Missile missileObject = objectPool.Get();
                    if (missileObject == null)
                    {
                        Debug.LogError("オブジェクトが取得できませんでした");
                        continue;
                    }

                    missileObject.target = target; // 取得したミサイルのターゲットを設定

                    // SetPositionAndRotationで位置と回転を設定
                    missileObject.transform.SetPositionAndRotation(muzzlePosition.position, muzzlePosition.rotation);

                    Debug.Log($"{missileObject.name} が発射されました");

                    // 次に発射できる時間を計算k

                }


            }
            else
            {
                foreach (Transform target in lockOnManager.targetsInSide)
                {
                    Debug.Log($"ターゲット: {target.name}");

                    // Missileクラスのオブジェクトを取得
                    Missile missileObject = objectPool.Get();
                    if (missileObject == null)
                    {
                        Debug.LogError("オブジェクトが取得できませんでした");
                        continue;
                    }

                    missileObject.target = target; // 取得したミサイルのターゲットを設定

                    // SetPositionAndRotationで位置と回転を設定
                    missileObject.transform.SetPositionAndRotation(muzzlePosition.position, muzzlePosition.rotation);

                    Debug.Log($"{missileObject.name} が発射されました");


                }






            }
        }
    }
}
