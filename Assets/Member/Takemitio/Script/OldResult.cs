//using UnityEngine;
//using UnityEngine.UI;
//using TMPro;

//public class GameManager : MonoBehaviour
//{
//    public Text infoText;
//    [SerializeField] private float gameTime = 180f; // �Q�[���̎��ԁi�b�j��ݒ�i3�� = 180�b�j
//    [SerializeField] private TextMeshProUGUI EnemyText;
//    [SerializeField] private TextMeshProUGUI TimerText;
//    [SerializeField] private TextMeshProUGUI GamejudgeText;
//    [SerializeField] private GameObject Button;
//    [SerializeField] private float gameTime = 180f; // �Q�[���̎��ԁi�b�j��ݒ�i3�� = 180�b�j
//    private bool timeUp = false;
//    private bool allEnemiesDefeatedCheck = false;
//    private bool allEnemiesDefeated = false;
//<<<<<<< HEAD
//    private int cntenemy;
//    //CuntUD cntud;
//=======
//>>>>>>> parent of ca91a1b (敵の動き修正)

//    CuntUD cntud;
//    void Start()
//    {
//        // �Q�[���J�n���Ɏ��Ԃ̃J�E���g�_�E�����J�n����
//        Invoke("CheckGameTime", gameTime);
//<<<<<<< HEAD
//        //cntenemy = cntud.currentCount;
//=======
//>>>>>>> parent of ca91a1b (敵の動き修正)
//        cntud = GameObject.FindGameObjectWithTag("EnemyNumber").GetComponent<CuntUD>();
//        cntenemy = cntud.currentCount;
//    }

//    void Update()
//    {
//        if (cntenemy == 0)
//            allEnemiesDefeated = true;

//        // �G��S���|�����ꍇ�̏�������
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
//    //    // �G��S���|�������ǂ����𔻒肷�鏈���i��Ƃ��āAEnemyManager���Ǘ�����G�̐���0�ɂȂ����Ƃ���j
//    //    //return EnemyManager.Instance.EnemyCount == 0;
//    //}

//    void ShowTimeUpUI()
//{
//    // �uTime's Up!�v��UI��\�����鏈���i��Ƃ��āAText�R���|�[�l���g�̕\����؂�ւ���j
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
//    // �uAll enemies defeated!�v��UI��\�����鏈���i��Ƃ��āAText�R���|�[�l���g�̕\����؂�ւ���j
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