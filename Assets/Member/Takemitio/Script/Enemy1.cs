using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApproachTarget : MonoBehaviour
{
    // ターゲットオブジェクトの Transformコンポーネントを格納する変数
    [SerializeField] private Transform target;
    // オブジェクトの移動速度を格納する変数
    [SerializeField] private float moveSpeed;
    // オブジェクトが停止するターゲットオブジェクトとの距離を格納する変数
    [SerializeField] private float stopDistance;
    // オブジェクトがターゲットに向かって移動を開始する距離を格納する変数
    [SerializeField] float moveDistance;

    // ゲーム実行中に毎フレーム実行する処理
    void Update()
    {
        // 変数 targetPos を作成してターゲットオブジェクトの座標を格納
        Vector3 targetPos = target.position;
        // 自分自身のY座標を変数 target のY座標に格納
        //（ターゲットオブジェクトのX、Z座標のみ参照）
        targetPos.y = transform.position.y;
        // オブジェクトを変数 targetPos の座標方向に向かせる
        //transform.LookAt(targetPos);

        // 変数 distance を作成してオブジェクトの位置とターゲットオブジェクトの距離を格納
        float distance = Vector3.Distance(transform.position, target.position);
        // オブジェクトとターゲットオブジェクトの距離判定
        // 変数 distance（ターゲットオブジェクトとオブジェクトの距離）が変数 moveDistance の値より小さければ
        // さらに変数 distance が変数 stopDistance の値よりも大きい場合
        if(distance <= stopDistance)
        {
            transform.position = transform.position - transform.forward * moveSpeed * 2 * Time.deltaTime;
        }
    }
}