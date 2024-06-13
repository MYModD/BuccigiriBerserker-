using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq; // LINQを使用するために必要

public class PlayerLockon : MonoBehaviour
{
    [SerializeField]
    Camera _lockcamera;

    [SerializeField]
    GameObject _player;

    private float _search_distance = 80f;
    // 前のフレームで視錐台内にあったオブジェクトのリスト
    List<Transform> previousVisibleObjects = new List<Transform>();


    // Start is called before the first frame update
    void Start()
    {
        //list = GeometryUtility.CalculateFrustumPlanes(_lockcamera);
        //_enemyobjCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // 視錐台の平面を取得
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(_lockcamera);

        // 現在のシーン内のすべてのGameObjectを取得
        List<Transform> allObjects = new List<Transform>();

        // 視錐台内にあるGameObjectを格納するリストを作成
        List<Transform> visibleObjects = new List<Transform>();

        RaycastHit[] _hits = Physics.SphereCastAll(
        _player.transform.position,
        _search_distance,
        _player.transform.forward,
        0.01f, LayerMask.GetMask("Enemy"));

        foreach (RaycastHit _hit in _hits)
        {
            // ヒットしたオブジェクトがEnemyレイヤーに含まれる場合のみリストに追加
            if (_hit.collider.gameObject.CompareTag("Enemy"))
            {
                allObjects.Add(_hit.collider.transform);

                // ここで、ヒットしたオブジェクトに対する追加の処理を行うこともできます
                _hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.red;
            }
        }
        // すべてのGameObjectに対して視錐台の内側にあるかどうかをテスト
        foreach (Transform obj in allObjects)
        {
            Renderer renderer = obj.GetComponent<Renderer>();
            if (renderer != null)
            {
                // オブジェクトの境界ボックスが視錐台と交差するかどうかを確認
                if (GeometryUtility.TestPlanesAABB(planes, renderer.bounds))
                {
                    // 視錐台内にあるオブジェクトをリストに追加
                    visibleObjects.Add(obj);
                }
            }
        }

        // 可視オブジェクトに対して何かしらの処理を行う
        foreach (Transform obj in visibleObjects)
        {
            // 例えば、可視オブジェクトの色を変更するなど
            obj.GetComponent<Renderer>().material.color = Color.blue;
        }

        // 前のフレームで視錐台内にあったオブジェクトのうち、
        // 現在のフレームではなくなったオブジェクトをリストから削除
        foreach (Transform obj in previousVisibleObjects)
        {
            if (!visibleObjects.Contains(obj))
            {
                // オブジェクトが視錐台から外れたので、リストから削除
                // 例えば、オブジェクトの色を元に戻すなどの処理を行うこともできます
                obj.GetComponent<Renderer>().material.color = Color.white;
            }
        }

        // 前のフレームで視錐台内にあったオブジェクトのリストを更新
        previousVisibleObjects = visibleObjects;
    }
}
       
    












    

