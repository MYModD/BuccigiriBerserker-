using System.Collections.Generic;
using UnityEngine;
using Utils;

public class LockOnManager : MonoBehaviour
{
    // カメラの視界に入っているターゲットのリスト
    public List<Transform> targetsInCamera = new List<Transform>();
    // 錐体内に入っているターゲットのリスト
    public List<Transform> targetsInCone = new List<Transform>();

    [SerializeField, Header("なんのカメラ")]
    private Camera _camera;

    [SerializeField, Header("spherecastの半径")]
    private float _searchRadius = 95f; 

    [SerializeField, Range(0f, 180f)]
    [Header("コーンの角度")]
    private float _coneAngle = 45f; 

    [SerializeField]
    [Header("コーンの長さ、半径")]
    private float _coneRange;

     private Vector3 DrawOrigin = new Vector3 (90,0,0);    //コーンの円周を向けるためのやつ offset

    
    private void OnValidate()
    {
        if (_coneRange > _searchRadius)//coneRangeをspherecast以下にする制御スクリプト
        {
            _coneRange = _searchRadius;
        }
    }
    void Update()
    {
        // ターゲットリストを更新
        UpdateTargets();
        DebugMatarialChange();


    }

    // ターゲットリストを更新するメソッド
    private void UpdateTargets()
    {
        // カメラの視錐台平面を取得
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(_camera);

        targetsInCamera.Clear();
        targetsInCone.Clear();

        Collider[] hits = GetSphereOverlapHits();    //colliderが返り値

        foreach (Collider hit in hits)
        {
            // ヒットしたオブジェクトを処理
            ProcessHit(hit, planes);

        }
    }

    /// <summary>
    /// 球状の範囲内のヒットしたコライダーを取得するメソッド
    /// </summary>
    private Collider[] GetSphereOverlapHits()
    {
        return Physics.OverlapSphere(
            _camera.transform.position,
            _searchRadius,
            LayerMask.GetMask("Enemy")                        //レイヤーマスクがenemyかつtagがenemyのとき
        );
    }



    /// <summary>
    /// ヒットしたオブジェクトを処理するメソッド  
    /// </summary>
    /// <param name="hit">コライダー型 オブジェクトを識別する</param>
    /// <param name="planes">カメラの図形をPlane型で表したもの</param>

    private void ProcessHit(Collider hit, Plane[] planes)
    {
        if (hit.CompareTag("Enemy"))
        {
            Transform target = hit.transform;
            Renderer renderer = target.GetComponent<Renderer>();

            if (renderer != null && IsInFrustum(renderer, planes))
            {
                targetsInCamera.Add(target);              //カメラ範囲内のリストにいれる

                if (IsInCone(target))
                {
                    targetsInCone.Add(target);            //コーン内のリストにいれる
                }
            }
        }
    }


    /// <summary>
    /// オブジェクトが視錐台内にあるかどうかを確認するメソッド
    /// </summary>
    private bool IsInFrustum(Renderer renderer, Plane[] planes)
    {
        return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);    //testPlanesAABBでカメラの形とcoliderのboundsで見えているかを判断する
    }

    /// <summary>
    /// オブジェクトが円錐内にあるかどうかを確認するメソッド
    /// </summary>
    /// <param name="target">確認するオブジェクトのTransform</param>
    /// <returns>オブジェクトが円錐内にある場合はtrue、それ以外の場合はfalse</returns>
    private bool IsInCone(Transform target)
    {

        Vector3 cameraPosition = _camera.transform.position;  // カメラの位置を取得
        Vector3 cameraForward = _camera.transform.forward;   // カメラの前方向ベクトルを取得

        Debug.Log($"{cameraPosition}+{cameraForward}");      // デバッグ用にカメラの位置と方向をログに出力

        Vector3 toObject = target.position - cameraPosition; // カメラ位置からターゲット位置へのベクトルを計算

        // ターゲットまでの距離を計算
        float distanceToObject = toObject.magnitude;                     // ベクトルの長さ（距離）

        if (distanceToObject <= _coneRange)                           // ターゲットが検索半径内にあるかどうかを確認
        {
            Vector3 toObjectNormalized = toObject.normalized;                // ターゲットへのベクトルを正規化（方向のみを取得）

            float angle = Vector3.Angle(cameraForward, toObjectNormalized); // カメラの前方向とターゲットへの方向との角度を計算
            return angle <= _coneAngle / 2;                                // 角度がコーンの半分の角度以下であればtrueを返す
        }

        // ターゲットが検索半径外にある場合はfalseを返す
        return false;
    }


    /// <summary>
    /// デバッグ用のギズモを描画するメソッド unity側のメソッド
    /// </summary>
    void OnDrawGizmos()
    {
        if (_camera != null)
        {
            // 球状の範囲を描画
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(_camera.transform.position, _searchRadius);


            //コーン上の円周を描画
            Gizmos.color = Color.yellow;
            var hoge = DrawOrigin + transform.rotation.eulerAngles;
            hoge.z = 0;                                                         //magicnum Z軸だけ0にする
            GizmosExtensions.DrawWireCircle(_camera.transform.position + (_camera.transform.forward * _coneRange), _coneAngle, 20, Quaternion.Euler(hoge));

            // コーンの範囲を描画
            Gizmos.color = Color.red;
            Vector3 forward = _camera.transform.forward * _coneRange;
            Vector3 up = Quaternion.Euler(0, _coneAngle / 2, 0) * forward;
            Vector3 down = Quaternion.Euler(0, -_coneAngle / 2, 0) * forward;

            Gizmos.DrawLine(_camera.transform.position, _camera.transform.position + forward);
            Gizmos.DrawLine(_camera.transform.position, _camera.transform.position + up);
            Gizmos.DrawLine(_camera.transform.position, _camera.transform.position + down);
            Gizmos.DrawLine(_camera.transform.position + up, _camera.transform.position + down);
        }
    }

    /// <summary>
    /// debug用にマテリアル変えるだけ いずれ消す
    /// </summary>
    private void DebugMatarialChange()
    {
        for (int i = 0; i < targetsInCamera.Count; i++) 
        {
            targetsInCamera[i].GetComponent<MeshRenderer>().material.color = Color.blue;
        }
        for (int i = 0; i < targetsInCone.Count; i++)
        {
            targetsInCone[i].GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }
}
