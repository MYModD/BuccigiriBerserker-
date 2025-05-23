using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class OldResult : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI EnemyText;
    [SerializeField] private TextMeshProUGUI TimerText;
    [SerializeField] private TextMeshProUGUI GamejudgeText;
    [SerializeField] private GameObject Button;
    [SerializeField] private float gameTime; // ゲームの時間（秒）を設定（3分 = 180秒）
    private bool timeUp = false;
    private bool allEnemiesDefeatedCheck = false;
    private bool allEnemiesDefeated = false;
    private int cntenemy;
    private int cntdestoroy;
    CuntUD cntud;
    CuntD  cntd;
    void Start()
    {
        // ゲーム開始時に時間のカウントダウンを開始する
        //Invoke("CheckGameTime", gameTime);
        cntud = GameObject.FindGameObjectWithTag("EnemyNumber").GetComponent<CuntUD>();
        cntd = GameObject.FindGameObjectWithTag("EnemyNumber").GetComponent<CuntD>();
        cntenemy = cntd.Initial_Value;
        cntdestoroy = cntud.DestoroyEnemies;
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
        gameTime -= Time.deltaTime;
        Debug.Log("Remaining Time: " + gameTime); // デバッグログを追加して確認
        if (!timeUp && !allEnemiesDefeatedCheck)
        {
            //gameTime -= (int)Time.deltaTime; // 経過時間を gameTime から減算します
            //print(gameTime);
            if (gameTime <= 0)
            {
                gameTime = 0;
                CheckGameTime();
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            cntenemy -= 1;
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

    //bool AllEnemiesDefeated()
    //{
    //    // 敵を全部倒したかどうかを判定する処理（例として、EnemyManagerが管理する敵の数が0になったとする）
    //    //return EnemyManager.Instance.EnemyCount == 0;
    //}

    void ShowTimeUpUI()
    {
        // 「Time's Up!」のUIを表示する処理（例として、Textコンポーネントの表示を切り替える）
        EnemyText.text = "DestroyEnemies: " + cntdestoroy.ToString();
        TimerText.text = "Time: " + FormatTime(gameTime);
        GamejudgeText.text = "Time Up! ";
        EnemyText.gameObject.SetActive(true);
        TimerText.gameObject.SetActive(true);
        GamejudgeText.gameObject.SetActive(true);
        Button.gameObject.SetActive(true);
    }
    void ShowAllEnemiesDefeatedUI()
    {
        //        // 「All enemies defeated!」のUIを表示する処理（例として、Textコンポーネントの表示を切り替える）
        //        infoText.text = "All enemies defeated!";
        //        infoText.gameObject.SetActive(true);
        EnemyText.text = "DestroyEnemies: " + cntdestoroy.ToString();
        TimerText.text = "Time: " + FormatTime(gameTime);
        GamejudgeText.text = "AllEnemiesDestroy!";
        EnemyText.gameObject.SetActive(true);
        TimerText.gameObject.SetActive(true);
        GamejudgeText.gameObject.SetActive(true);
        Button.gameObject.SetActive(true);
    }
    string FormatTime(float seconds)
    {
        int minutes = Mathf.FloorToInt(seconds / 60); // 分を取得
        int remainingSeconds = Mathf.FloorToInt(seconds % 60); // 秒を取得
        return string.Format("{0:00}:{1:00}", minutes, remainingSeconds);
    }
}