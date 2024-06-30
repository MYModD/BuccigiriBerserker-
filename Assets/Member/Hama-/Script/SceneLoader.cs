using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


  

public class SceneLoader : MonoBehaviour
{
    private AsyncOperation sceneLoadOperation;
    private bool sceneLoaded = false;

    void Start()
    {
        // 別のシーンを非同期でロードする
        sceneLoadOperation = SceneManager.LoadSceneAsync("Enemy");
        sceneLoadOperation.allowSceneActivation = false; // シーンのアクティベーションを待機状態にする
        sceneLoadOperation.completed += OnSceneLoadComplete; // シーンのロード完了時のコールバックを設定
    }
    void Update()
    {
        Debug.Log("Loading progress: " + sceneLoadOperation.progress);
    }

    private void OnSceneLoadComplete(AsyncOperation asyncOperation)
    {
        sceneLoaded = true;
         Debug.Log("Scene loaded successfully.");
    }

    public void LoadNextScene()
    {
        if (sceneLoaded)
        {
            // ロードしたシーンに遷移する
            sceneLoadOperation.allowSceneActivation = true;
        }
        else
        {
            Debug.LogWarning("Scene is not yet loaded. Wait for the scene to load before attempting to transition.");
            // ここで適切なエラー処理やメッセージを表示することができます
        }
    }
}
