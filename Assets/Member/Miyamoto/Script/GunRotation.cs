using UnityEngine;

public class GunRotation : MonoBehaviour
{
    public Transform enemyTransform;
    [Range(0, 1f)]
    public float lerpT = 0.5f; // デフォルト値を設定

    // Update is called once per frame
    private void Update()
    {
        if (enemyTransform != null)
        {
            // 敵との位置の差を取得
            Vector3 direction = enemyTransform.position - transform.position;

            // 水平方向のみに回転させる場合（Y軸をロック）
            direction.y = 0;

            // 回転量を計算
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            // 回転をスムーズに補間
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, lerpT);
        }
    }
}
