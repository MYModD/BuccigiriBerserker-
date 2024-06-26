using UnityEngine;

public class Retry_Player : MonoBehaviour
{
    private PlayerLife playerLife;
    public GameObject[] childObjects; // TransformではなくGameObjectの配列に修正

    void Start()
    {
        playerLife = GetComponent<PlayerLife>();
        SetMeshRenderersEnabled(true); // 初期状態ではメッシュレンダラーを表示する
    }

    void Update()
    {
        // プレイヤーの_IsRetryフラグに応じてメッシュレンダラーの表示・非表示を切り替える
        if (playerLife._IsRetry)
        {
            SetMeshRenderersEnabled(false); // メッシュレンダラーを非表示にする
        }
        else
        {
            SetMeshRenderersEnabled(true); // メッシュレンダラーを表示する
        }
    }

    // メッシュレンダラーの表示・非表示を一括で設定するメソッド
    private void SetMeshRenderersEnabled(bool enabled)
    {
        foreach (GameObject obj in childObjects)
        {
            MeshRenderer childRenderer = obj.GetComponent<MeshRenderer>();
            if (childRenderer != null)
            {
                childRenderer.enabled = enabled;
            }
            else
            {
                Debug.LogWarning("MeshRenderer not found on child object: " + obj.name);
            }
        }
    }

}
