using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float stopDistance;
    [SerializeField] private float retreatDistance; // プレイヤーから離れる距離を設定

    private void Update()
    {
        // プレイヤーとの距離を計算
        float distanceToPlayer = Vector3.Distance(transform.position, target.position);

        // プレイヤーとの距離が離れる距離よりも小さい場合に後退する
        if (distanceToPlayer < retreatDistance)
        {
            // オブジェクトの方向をプレイヤーから離れた方向に向ける
            Vector3 directionToPlayer = (transform.position - target.position).normalized;
            // 後退する
            transform.position += directionToPlayer * moveSpeed * Time.deltaTime;
        }
    }
}