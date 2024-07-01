using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageDestroy : MonoBehaviour
{
    // Update is called once per frame
    public GameObject _player;

    // プレイヤーとの最大距離
    public float _maxDistance = 7000f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    void Update()
    {
        if (_player != null)
        {
            // プレイヤーのz座標を取得
            float playerZ = _player.transform.position.z;

            // 自分のz座標を取得
            float myZ = transform.position.z;

            // プレイヤーとの距離を計算
            float distance = Mathf.Abs(playerZ - myZ);

            // プレイヤーとの距離が最大距離より大きい場合
            if (distance >= _maxDistance)
            {
                // 自分を破壊する
                Destroy(gameObject);
            }
        }
    }
}
    

