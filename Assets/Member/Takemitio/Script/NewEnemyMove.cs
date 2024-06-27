using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemyMove : MonoBehaviour
{
    [Header("移動させる距離")]
    [SerializeField] private float distanceToLeft; // 左に移動する距離
    [Header("移動速度")]
    [SerializeField] private float moveSpeed; // 移動速度
    [Header("誰に対して距離を保つか")]
    [SerializeField] private Transform target;
    [Header("TARGETの間に保つ距離")]
    [SerializeField] private float stopDistance;

    private bool reachedTarget = false; // ターゲットに到達したかどうかのフラグ
    private Vector3 targetPosition; // 目標位置

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        // 左に移動する目標位置を計算
        targetPosition = transform.position + Vector3.left * distanceToLeft;
    }

    private void Update()
    {
        // 目標位置に向かって移動
        if (!reachedTarget)
        {
            // 目標位置に向かって移動
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // オブジェクトとターゲットオブジェクトの距離判定
            float squaredDistance = (transform.position - target.position).sqrMagnitude;
            if (squaredDistance <= stopDistance * stopDistance)
            {
                reachedTarget = true; // ターゲットに到達したらフラグを立てる
            }
        }

        // ターゲットに向かって移動
        Vector3 targetPos = target.position;
        targetPos.y = transform.position.y;

        // オブジェクトとターゲットオブジェクトの距離判定
        float squaredDist = (transform.position - target.position).sqrMagnitude;
        if (squaredDist <= stopDistance * stopDistance)
        {
            transform.position = transform.position - transform.forward * moveSpeed * 2 * Time.deltaTime;
        }
    }
}