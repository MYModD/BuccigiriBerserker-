using UnityEngine;

public class MultipleTrailRendererController : MonoBehaviour
{
    public float minRotationAngle = -45f; // 最小の回転角度
    public float maxRotationAngle = 45f;  // 最大の回転角度
    public TrailRenderer[] trailRenderers; // TrailRendererの配列

    void Update()
    {
        // 親オブジェクトの現在の回転角度を取得する
        float currentRotation = transform.rotation.eulerAngles.z;

        // 回転角度が指定された範囲内にあるかどうかをチェックする
        if (currentRotation >= minRotationAngle && currentRotation <= maxRotationAngle)
        {
            // 指定範囲内にいる場合は全てのTrailRendererを無効にする
            foreach (TrailRenderer renderer in trailRenderers)
            {
                if (renderer != null && renderer.enabled)
                {
                    renderer.enabled = false;
                }
            }
        }
        else
        {
            // 指定範囲外にいる場合は全てのTrailRendererを有効にする
            foreach (TrailRenderer renderer in trailRenderers)
            {
                if (renderer != null && !renderer.enabled)
                {
                    renderer.enabled = true;
                }
            }
        }
    }
}
