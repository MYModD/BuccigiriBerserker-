using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float totalTime = 180.0f; // タイマーの初期設定時間（秒）
    private float timeLeft; // 現在の残り時間

    private float timemin;
    private float timesec;
    public Text countdownText; // UIテキストオブジェクト

    void Start()
    {
        timeLeft = totalTime;
        
        countdownText = GetComponent<Text>();
        UpdateUI(); // UIを更新して初期設定時間を表示
    }

    void Update()
    {
        // 残り時間を減らす
        timeLeft -= Time.deltaTime;
        timemin = timeLeft / 60;
        timesec = timeLeft % 60;
        Debug.Log(timemin);
        Debug.Log(timesec);

        // タイマーが0以下になったら、指定した処理を実行する（ここでは例としてDebug.Log）
        if (timeLeft <= 0.0f)
        {
            timeLeft = 0.0f;
            timemin = 0.0f;
            timesec = 0.0f;
            Debug.Log("Time's up!");
            // ここにゲームオーバー処理などを実装する
        }



        // UIを更新する
        UpdateUI();
    }

    void UpdateUI()
    {
        // UIテキストに残り時間を表示する
        if (countdownText != null)
        {
            if (timesec > 9)
            {
                //countdownText.text = Mathf.CeilToInt(timeLeft).ToString();
                countdownText.text = Mathf.FloorToInt(timemin).ToString() + ":" + Mathf.FloorToInt(timesec).ToString();
            }
            if(timesec < 10)
            {
                countdownText.text = Mathf.FloorToInt(timemin).ToString() + ":" + "0" + Mathf.FloorToInt(timesec).ToString();
            }
        }
    }
}


