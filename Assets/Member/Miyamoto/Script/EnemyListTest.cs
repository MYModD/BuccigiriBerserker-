using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyListTest : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;

    [SerializeField]
    private GameObject _player;

    [SerializeField]
    private float _searchDistance = 95f;

    [SerializeField, Range(0f, 180f)]
    private float _coneAngle = 45f;

    public List<Transform> _filteredObjects = new List<Transform>();

    void FixedUpdate()
    {
        // 球状の範囲内にあるゲームオブジェクトを取得
        RaycastHit[] hits = Physics.SphereCastAll(
            _player.transform.position,
            _searchDistance,
            Vector3.up, //球状だから関係ないやつ
            0.01f,
            LayerMask.GetMask("Enemy")
        );

        List<Transform> allObjects = new List<Transform>();

        foreach (RaycastHit hit in hits)
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                allObjects.Add(hit.collider.transform);
            }
        }

        // カメラの中心からカメラの向きに円錐の範囲を取ってフィルタリング
        _filteredObjects.Clear();

        Vector3 cameraPosition = _camera.transform.position;
        Vector3 cameraForward = _camera.transform.forward;

        foreach (Transform obj in allObjects)
        {
            // カメラからオブジェクトへのベクトルを計算
            Vector3 toObject = obj.position - cameraPosition;
            float distanceToObject = toObject.magnitude;

            // 距離が指定した範囲内か確認
            if (distanceToObject <= _searchDistance)
            {
                // オブジェクトへのベクトルを正規化
                Vector3 toObjectNormalized = toObject.normalized;

                // カメラの前方ベクトルとオブジェクトへのベクトルの間の角度を計算
                float angle = Vector3.Angle(cameraForward, toObjectNormalized);

                // 角度が円錐の範囲内に収まるかを判定
                if (angle <= _coneAngle / 2)
                {
                    _filteredObjects.Add(obj);
                }
            }
        }

        // フィルタリングされたオブジェクトの処理（例：色を変更）
        foreach (Transform obj in _filteredObjects)
        {
            obj.GetComponent<Renderer>().material.color = Color.blue;
        }

        // 円錐範囲外のオブジェクトの色を元に戻す
        foreach (Transform obj in allObjects)
        {
            if (!_filteredObjects.Contains(obj))
            {
                obj.GetComponent<Renderer>().material.color = Color.red;
            }
        }
    }
}
