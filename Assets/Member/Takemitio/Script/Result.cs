using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text infoText;
    [SerializeField]private float gameTime = 180f; // ゲームの時間（秒）を設定（3分 = 180秒）
    private bool timeUp = false;
    private bool allEnemiesDefeated = false;
    private int cntenemy;
    //CuntUD cntud;

    void Start()
    {
        // ゲーム開始時に時間のカウントダウンを開始する
        Invoke("CheckGameTime", gameTime);
        //cntenemy = cntud.currentCount;
    }

    void Update()
    {
        // 敵を全部倒した場合の条件判定
        if (!allEnemiesDefeated )
        {
            allEnemiesDefeated = true;
            ShowAllEnemiesDefeatedUI();
        }
    }

    void CheckGameTime()
    {
        // 時間がゼロになった場合の条件判定
        if (!timeUp)
        {
            timeUp = true;
            ShowTimeUpUI();
        }
    }

    //bool AllEnemiesDefeated()
    //{
    //    // 敵を全部倒したかどうかを判定する処理（例として、EnemyManagerが管理する敵の数が0になったとする）
    //    //return EnemyManager.Instance.EnemyCount == 0;
    //}

    void ShowTimeUpUI()
    {
        // 「Time's Up!」のUIを表示する処理（例として、Textコンポーネントの表示を切り替える）
        infoText.text = "Time's Up!";
        infoText.gameObject.SetActive(true);
    }

    void ShowAllEnemiesDefeatedUI()
    {
        // 「All enemies defeated!」のUIを表示する処理（例として、Textコンポーネントの表示を切り替える）
        infoText.text = "All enemies defeated!";
        infoText.gameObject.SetActive(true);
    }
}
