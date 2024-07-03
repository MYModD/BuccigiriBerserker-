using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class Result : MonoBehaviour
{
    [SerializeField] private float gameTime; // ゲームの時間（秒）を設定（3分 = 180秒）
    private bool timeUp = false;
    private bool allEnemiesDefeatedCheck = false;
    private bool allEnemiesDefeated = false;
    private int cntenemy = 100;
    private int cntdestoroy = 0;
    public GameObject _destory;
    [HideInInspector] public string _strDestoryEnemy;
    [HideInInspector] public string _strTime;
    [HideInInspector] public string _gamejudge;
    CuntUD cntud;
    CuntD cntd;
    private DestroyEnemyCount _destroyEnemyCount;
    void Start()
    {
        _destroyEnemyCount = _destory.GetComponent<DestroyEnemyCount>();
        DontDestroyOnLoad(this);
        cntud = GameObject.FindGameObjectWithTag("EnemyNumber").GetComponent<CuntUD>();
        cntd = GameObject.FindGameObjectWithTag("EnemyNumber").GetComponent<CuntD>();
        cntenemy = cntd.Initial_Value;
        cntdestoroy = _destroyEnemyCount.value;
    }
    void Update()
    {
        if (cntenemy <= cntdestoroy)
        {
            print("EnemyAllDestory");
            allEnemiesDefeated = true;
        }

        // 敵を全部倒した場合の条件判定
        if (!allEnemiesDefeatedCheck && allEnemiesDefeated)
        {
            allEnemiesDefeatedCheck = true;
            _strTime = "Time: " + FormatTime(gameTime);
            _strDestoryEnemy = "DestroyEnemies: " + cntdestoroy.ToString();
            _gamejudge = "All Enemy Destoryed!!";
            ShowAllEnemiesDefeatedUI();
        }
        gameTime -= Time.deltaTime;
        //Debug.Log("Remaining Time: " + gameTime); // デバッグログを追加して確認
        if (!timeUp && !allEnemiesDefeatedCheck)
        {
            if (gameTime <= 0)
            {
                gameTime = 0;
                CheckGameTime();
            }
        }
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    cntdestoroy += 1;
        //}
    }

    void CheckGameTime()
    {
        // 時間がゼロになった場合の条件判定
        if (!timeUp && !allEnemiesDefeatedCheck)
        {
            timeUp = true;
            _strTime = "Time: " + FormatTime(gameTime);
            _strDestoryEnemy = "DestroyEnemies: " + cntdestoroy.ToString();
            _gamejudge = "Time UP!";
            ShowTimeUpUI();
        }
    }

    void ShowTimeUpUI()
    {
        SceneManager.LoadScene("ResultScene");
    }
    void ShowAllEnemiesDefeatedUI()
    {
        SceneManager.LoadScene("ResultScene");
    }
    string FormatTime(float seconds)
    {
        int minutes = Mathf.FloorToInt(seconds / 60); // 分を取得
        int remainingSeconds = Mathf.FloorToInt(seconds % 60); // 秒を取得
        return string.Format("{0:00}:{1:00}", minutes, remainingSeconds);
    }
}