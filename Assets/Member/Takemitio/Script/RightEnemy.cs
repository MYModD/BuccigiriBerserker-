using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightEnemy : MonoBehaviour
{
    [SerializeField] private float distanceToRight; // 左に移動する距離
    [SerializeField] private float moveSpeed; // 移動速度

    [SerializeField] private Transform target;
    [SerializeField] private float stopDistance;

    private bool reachedTarget = false; // ターゲットに到達したかどうかのフラグ
    private Vector3 targetPosition; // 目標位置

    private void Start()
    {
        // 左に移動する目標位置を計算
        targetPosition = transform.position + Vector3.right * distanceToRight;
    }

    private void Update()
    {
        // 目標位置に向かって移動
        if (!reachedTarget)
        {
            // 目標位置に向かって移動
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // オブジェクトとターゲットオブジェクトの距離判定
            float leftdistance = Vector3.Distance(transform.position, target.position);
            if (leftdistance <= stopDistance)
            {
                reachedTarget = true; // ターゲットに到達したらフラグを立てる
            }
        }


        // ターゲットに向かって移動
        Vector3 targetPos = target.position;
        targetPos.y = transform.position.y;
        //transform.LookAt(targetPos);

        // オブジェクトとターゲットオブジェクトの距離判定
        float distance = Vector3.Distance(transform.position, target.position);
        if (distance <= stopDistance)
        {
            transform.position = transform.position - transform.forward * moveSpeed * 2 * Time.deltaTime;
        }
    }
}
