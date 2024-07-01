using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartButtonScript : MonoBehaviour
{
    private AsyncOperation GameSceneStarter;//ゲームシーンの取得
    private float SceneStopTime　= 2f;//ゲームシーンを一度止めるまでの時間
    private float TrueTimeScale = 1f;//TimeScaleの設定
    public bool isGameReady = default;//ゲームシーンの起動許可

    // Start is called before the first frame update
    void Start()
    {
        GameSceneStarter = SceneManager.LoadSceneAsync("Enemy",LoadSceneMode.Additive);//ゲームシーンを出力
        Invoke("GameSceneReadyStop",SceneStopTime);//指定時間経過したらゲームシーンを一度止める
        
    }

    

    public void GameSceneReadyStop()
    {
        GameSceneStarter.allowSceneActivation = false;//ゲームシーンを一度止める
        Time.timeScale = 0f;//シーンのオブジェクトの動きを止める
        isGameReady = true;//ゲームシーンへの切り替え準備が完了したことを伝える
    }

    public void SceneChange()
    {
        if (isGameReady)//ゲームシーンへの切り替え準備が完了している場合
        {
            GameSceneStarter.allowSceneActivation = true;//ゲームシーンを起動する
            SceneManager.UnloadSceneAsync("HowtoPlayScene");//操作説明シーンを消去する
            Time.timeScale = TrueTimeScale;//シーンのオブジェクトの動きを再開する
            return;
        }
    }
}
