using System.Collections.Generic;
using UnityEngine;
using Utils;

public class LockOnManager : MonoBehaviour
{
    // カメラの視界に入っているターゲットのリスト
    public List<Transform> targetsInCamera = new List<Transform>();
    // 錐体内に入っているターゲットのリスト
    public List<Transform> targetsInCone = new List<Transform>();

    [SerializeField]
    private Camera _camera;

    [SerializeField]
    private float _searchRadius = 95f; // 球状の範囲の半径

    [SerializeField, Range(0f, 180f)]
    private float _coneAngle = 45f; // 円錐の角度

    public float Z;

    void Update()
    {
        // ターゲットリストを更新
        UpdateTargets();

        // カメラの視界に入っているターゲットを赤色にする
        for (int i = 0; i < targetsInCamera.Count; i++)
        {
            targetsInCamera[i].GetComponent<MeshRenderer>().material.color = Color.red;
        }

        // 円錐内に入っているターゲットを青色にする
        for (int j = 0; j < targetsInCone.Count; j++)
        {
            targetsInCone[j].GetComponent<MeshRenderer>().material.color = Color.blue;
        }
    }

    // ターゲットリストを更新するメソッド
    private void UpdateTargets()
    {
        // カメラの視錐台平面を取得
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(_camera);

        targetsInCamera.Clear();
        targetsInCone.Clear();

        // 球状の範囲内のヒットしたコライダーを取得
        Collider[] hits = GetSphereOverlapHits();

        foreach (Collider hit in hits)
        {
            // ヒットしたオブジェクトを処理
            ProcessHit(hit, planes);
            hit.gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
        }
    }

    // 球状の範囲内のヒットしたコライダーを取得するメソッド
    private Collider[] GetSphereOverlapHits()
    {
        return Physics.OverlapSphere(
            _camera.transform.position,
            _searchRadius,
            LayerMask.GetMask("Enemy")
        );
    }

    // ヒットしたオブジェクトを処理するメソッド
    private void ProcessHit(Collider hit, Plane[] planes)
    {
        if (hit.CompareTag("Enemy"))
        {
            Transform target = hit.transform;
            Renderer renderer = target.GetComponent<Renderer>();

            if (renderer != null && IsInFrustum(renderer, planes))
            {
                targetsInCamera.Add(target);

                if (IsInCone(target))
                {
                    targetsInCone.Add(target);
                }
            }
        }
    }

    // オブジェクトが視錐台内にあるかどうかを確認するメソッド
    private bool IsInFrustum(Renderer renderer, Plane[] planes)
    {
        return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
    }

    // オブジェクトが円錐内にあるかどうかを確認するメソッド
    private bool IsInCone(Transform target)
    {
        Vector3 cameraPosition = _camera.transform.position;
        Vector3 cameraForward = _camera.transform.forward;

        Vector3 toObject = target.position - cameraPosition;
        float distanceToObject = toObject.magnitude;

        if (distanceToObject <= _searchRadius)
        {
            Vector3 toObjectNormalized = toObject.normalized;
            float angle = Vector3.Angle(cameraForward, toObjectNormalized);
            return angle <= _coneAngle / 2;
        }
        return false;
    }

    // デバッグ用のギズモを描画するメソッド
    void OnDrawGizmos()
    {
        if (_camera != null)
        {
            // 球状の範囲を描画
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(_camera.transform.position, _searchRadius);

            Gizmos.color = Color.yellow;

            var hoge = transform.position.z + Z;
            var hoge2 = new Vector3(transform.position.x, transform.position.y, hoge);
            GizmosExtensions.DrawWireCircle(hoge2, _coneAngle,20,Quaternion.Euler(-90,0,0));
            
            // 円錐の範囲を描画
            Gizmos.color = Color.red;
            Vector3 forward = _camera.transform.forward * _searchRadius;
            Vector3 up = Quaternion.Euler(0, _coneAngle / 2, 0) * forward;
            Vector3 down = Quaternion.Euler(0, -_coneAngle / 2, 0) * forward;

            Gizmos.DrawLine(_camera.transform.position, _camera.transform.position + forward);
            Gizmos.DrawLine(_camera.transform.position, _camera.transform.position + up);
            Gizmos.DrawLine(_camera.transform.position, _camera.transform.position + down);

            Gizmos.DrawLine(_camera.transform.position + up, _camera.transform.position + down);
        }
    }
}
