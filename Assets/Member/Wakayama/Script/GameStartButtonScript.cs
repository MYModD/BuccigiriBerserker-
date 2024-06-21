using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartButtonScript : MonoBehaviour
{
    private AsyncOperation GameSceneStarter;//ゲームシーンの取得
    [SerializeField]private float SceneStopTime　= default;//ゲームシーンを一度止めるまでの時間

    // Start is called before the first frame update
    void Start()
    {
        GameSceneStarter = SceneManager.LoadSceneAsync("Enemy");//ゲームシーンを出力
        Invoke("GameSceneReadyStop",SceneStopTime);//指定時間経過したらゲームシーンを一度止める
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameSceneReadyStop()
    {
        GameSceneStarter.allowSceneActivation = false;//ゲームシーンを一度止める
    }

    public void SceneChange()
    {
        GameSceneStarter.allowSceneActivation = true;//ゲームシーンを起動する
        SceneManager.UnloadSceneAsync("HowtoPlayScene");//操作説明シーンを消去する
        return;
    }
}
