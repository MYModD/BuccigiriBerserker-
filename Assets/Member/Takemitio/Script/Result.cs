using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI EnemyText;
    [SerializeField] private TextMeshProUGUI TimerText;
    [SerializeField] private TextMeshProUGUI GamejudgeText;
    [SerializeField] private GameObject Button;
    [SerializeField] private int gameTime = 180; // ゲームの時間（秒）を設定（3分 = 180秒）
    private bool timeUp = false;
    private bool allEnemiesDefeatedCheck = false;
    private bool allEnemiesDefeated = false;
    private int cntenemy;
    CuntUD cntud;
    void Start()
    {
        // ゲーム開始時に時間のカウントダウンを開始する
        Invoke("CheckGameTime", gameTime);
        cntud = GameObject.FindGameObjectWithTag("EnemyNumber").GetComponent<CuntUD>();
      cntenemy = cntud.currentCount;
    }

    void Update()
    {
        if (cntenemy == 0)
            allEnemiesDefeated = true;

        // 敵を全部倒した場合の条件判定
        if (!allEnemiesDefeatedCheck && allEnemiesDefeated)
        {
            allEnemiesDefeatedCheck = true;
            ShowAllEnemiesDefeatedUI();
        }

        if (!timeUp && !allEnemiesDefeatedCheck)
        {
            gameTime -= (int)Time.deltaTime; // 経過時間を gameTime から減算します
            if (gameTime <= 0)
            {
                gameTime = 0;
                CheckGameTime();
            }
        }
    }

    void CheckGameTime()
    {
        // 時間がゼロになった場合の条件判定
        if (!timeUp && !allEnemiesDefeatedCheck)
        {
            timeUp = true;
            ShowTimeUpUI();
        }
    }

    void ShowTimeUpUI()
    {
        // 「Time's Up!」のUIを表示する処理（例として、Textコンポーネントの表示を切り替える）
        EnemyText.text = "99";
        TimerText.text = "Time: " + FormatTime(gameTime);
        GamejudgeText.text = "Time Up! ";
        EnemyText.gameObject.SetActive(true);
        TimerText.gameObject.SetActive(true);
        GamejudgeText.gameObject.SetActive(true);
        Button.gameObject.SetActive(true);
    }

    void ShowAllEnemiesDefeatedUI()
    {
        // 「All enemies defeated!」のUIを表示する処理（例として、Textコンポーネントの表示を切り替える）
        EnemyText.text = "99"; // 元のコードの意図が不明なため、そのまま残します
        TimerText.text = "Time: " + FormatTime(gameTime);
        GamejudgeText.text = "AllEnemiesDestoroy!";
        EnemyText.gameObject.SetActive(true);
        TimerText.gameObject.SetActive(true);
        GamejudgeText.gameObject.SetActive(true);
        Button.gameObject.SetActive(true);
    }

    string FormatTime(int seconds)
    {
        int minutes = seconds / 60;
        int remainingSeconds = seconds % 60;
        return string.Format("{0:00}:{1:00}", minutes, remainingSeconds);
    }
}
