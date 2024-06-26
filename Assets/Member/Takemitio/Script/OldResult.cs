//using UnityEngine;
//using UnityEngine.UI;
//using TMPro;

//public class GameManager : MonoBehaviour
//{
//    public Text infoText;
//    [SerializeField] private float gameTime = 180f; // ゲームの時間（秒）を設定（3分 = 180秒）
//    [SerializeField] private TextMeshProUGUI EnemyText;
//    [SerializeField] private TextMeshProUGUI TimerText;
//    [SerializeField] private TextMeshProUGUI GamejudgeText;
//    [SerializeField] private GameObject Button;
//    [SerializeField] private float gameTime = 180f; // ゲームの時間（秒）を設定（3分 = 180秒）
//    private bool timeUp = false;
//    private bool allEnemiesDefeatedCheck = false;
//    private bool allEnemiesDefeated = false;
//<<<<<<< HEAD
//    private int cntenemy;
//    //CuntUD cntud;
//=======
//>>>>>>> parent of ca91a1b (謨ｵ縺ｮ蜍輔″菫ｮ豁｣)

//    CuntUD cntud;
//    void Start()
//    {
//        // ゲーム開始時に時間のカウントダウンを開始する
//        Invoke("CheckGameTime", gameTime);
//<<<<<<< HEAD
//        //cntenemy = cntud.currentCount;
//=======
//>>>>>>> parent of ca91a1b (謨ｵ縺ｮ蜍輔″菫ｮ豁｣)
//        cntud = GameObject.FindGameObjectWithTag("EnemyNumber").GetComponent<CuntUD>();
//        cntenemy = cntud.currentCount;
//    }

//    void Update()
//    {
//        if (cntenemy == 0)
//            allEnemiesDefeated = true;

//        // 敵を全部倒した場合の条件判定
//        if (!allEnemiesDefeated)
//            if (!allEnemiesDefeatedCheck && allEnemiesDefeated)
//            {
//                allEnemiesDefeated = true;
//                allEnemiesDefeatedCheck = true;
//                ShowAllEnemiesDefeatedUI();
//            }
//    }
//@@ -43,23 +45,27 @@ void CheckGameTime()
//        }
//    }

//    //bool AllEnemiesDefeated()
//    //{
//    //    // 敵を全部倒したかどうかを判定する処理（例として、EnemyManagerが管理する敵の数が0になったとする）
//    //    //return EnemyManager.Instance.EnemyCount == 0;
//    //}

//    void ShowTimeUpUI()
//{
//    // 「Time's Up!」のUIを表示する処理（例として、Textコンポーネントの表示を切り替える）
//    infoText.text = "Time's Up!";
//    infoText.gameObject.SetActive(true);
//    EnemyText.text = "99";
//    TimerText.text = "Time's Up!";
//    GamejudgeText.text = "All enemies defeated! ";
//    EnemyText.gameObject.SetActive(true);
//    TimerText.gameObject.SetActive(true);
//    GamejudgeText.gameObject.SetActive(true);
//    Button.gameObject.SetActive(true);
//}

//void ShowAllEnemiesDefeatedUI()
//{
//    // 「All enemies defeated!」のUIを表示する処理（例として、Textコンポーネントの表示を切り替える）
//    infoText.text = "All enemies defeated!";
//    infoText.gameObject.SetActive(true);
//    EnemyText.text = "99";
//    TimerText.text = "Time's Up!";
//    GamejudgeText.text = "All enemies defeated! ";
//    EnemyText.gameObject.SetActive(true);
//    TimerText.gameObject.SetActive(true);
//    GamejudgeText.gameObject.SetActive(true);
//    Button.gameObject.SetActive(true);
//}
//}