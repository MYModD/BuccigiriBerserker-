using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Result : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI EnemyText;
    [SerializeField] private TextMeshProUGUI TimerText;
    [SerializeField] private TextMeshProUGUI GamejudgeText;
    [SerializeField] private float gameTime = 180f; // ゲームの時間（秒）を設定（3分 = 180秒）

    private bool timeUp = false;
    private bool allEnemiesDefeated = false;
    private int initialEnemyCount;
    private int destroyedEnemyCount;

    // 結果を保持するデータクラス
    public class ResultData
    {
        public int destroyedEnemies;
        public float remainingTime;
        public string gameResult;

        public ResultData(int destroyedEnemies, float remainingTime, string gameResult)
        {
            this.destroyedEnemies = destroyedEnemies;
            this.remainingTime = remainingTime;
            this.gameResult = gameResult;
        }
    }

    // GameManager のインスタンスを保持する静的なプロパティ
    private static Result instance;
    public static Result Instance { get { return instance; } }

    void Awake()
    {
        // インスタンスが既に存在する場合は破棄する
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // インスタンスを設定する
        instance = this;

        // シーン遷移時に破棄されないようにする
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        // 敵の初期数と破壊した敵の数を設定する
        CuntD cntd = GameObject.FindGameObjectWithTag("EnemyNumber").GetComponent<CuntD>();
        CuntUD cntud = GameObject.FindGameObjectWithTag("EnemyNumber").GetComponent<CuntUD>();
        initialEnemyCount = cntd.Initial_Value;
        destroyedEnemyCount = cntud.DestoroyEnemies;
    }

    void Update()
    {
        if (!timeUp && !allEnemiesDefeated)
        {
            gameTime -= Time.deltaTime;

            // 残り時間が0以下になったら時間切れの処理を実行
            if (gameTime <= 0)
            {
                gameTime = 0;
                timeUp = true;
                ShowTimeUpUI();
            }
        }
    }

    // 敵を倒したかどうかをチェックする
    public void EnemyDestroyed()
    {
        initialEnemyCount--;

        if (initialEnemyCount <= 0 && !allEnemiesDefeated)
        {
            allEnemiesDefeated = true;
            ShowAllEnemiesDefeatedUI();
        }
    }

    void ShowTimeUpUI()
    {
        // 結果データを作成し、GameManager自体をシーン間で維持する
        ResultData resultData = new ResultData(destroyedEnemyCount, gameTime, "Time Up!");
        DontDestroyOnLoad(this.gameObject);

        // ResultSceneに遷移する
        SceneManager.LoadScene("NewResultScene");
    }

    void ShowAllEnemiesDefeatedUI()
    {
        // 結果データを作成し、GameManager自体をシーン間で維持する
        ResultData resultData = new ResultData(destroyedEnemyCount, gameTime, "All Enemies Destroyed!");
        DontDestroyOnLoad(this.gameObject);

        // ResultSceneに遷移する
        SceneManager.LoadScene("NewResultScene");
    }
}
