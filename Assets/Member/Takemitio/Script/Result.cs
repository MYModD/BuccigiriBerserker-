using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI EnemyText;
    [SerializeField] private TextMeshProUGUI TimerText;
    [SerializeField] private TextMeshProUGUI GamejudgeText;
    [SerializeField] private GameObject Button;
    [SerializeField] private float gameTime; // �Q�[���̎��ԁi�b�j��ݒ�i3�� = 180�b�j
    private bool timeUp = false;
    private bool allEnemiesDefeatedCheck = false;
    private bool allEnemiesDefeated = false;
    private int cntenemy;
    private int cntdestoroy;
    CuntUD cntud;
    CuntD  cntd;
    void Start()
    {
        // �Q�[���J�n���Ɏ��Ԃ̃J�E���g�_�E�����J�n����
        //Invoke("CheckGameTime", gameTime);
        cntud = GameObject.FindGameObjectWithTag("EnemyNumber").GetComponent<CuntUD>();
        cntd = GameObject.FindGameObjectWithTag("EnemyNumber").GetComponent<CuntD>();
        //cntenemy = cntd.;
        cntdestoroy = cntud.DestoroyEnemies;

    }

    void Update()
    {
        if (cntenemy == 0)
            allEnemiesDefeated = true;

        // �G��S���|�����ꍇ�̏�������
        if (!allEnemiesDefeatedCheck && allEnemiesDefeated)
        {
            allEnemiesDefeatedCheck = true;
            ShowAllEnemiesDefeatedUI();
        }
        gameTime -= Time.deltaTime;
        Debug.Log("Remaining Time: " + gameTime); // �f�o�b�O���O��ǉ����Ċm�F
        if (!timeUp && !allEnemiesDefeatedCheck)
        {
            //gameTime -= (int)Time.deltaTime; // �o�ߎ��Ԃ� gameTime ���猸�Z���܂�
            //print(gameTime);
            if (gameTime <= 0)
            {
                gameTime = 0;
                CheckGameTime();
            }
        }

    }

    void CheckGameTime()
    {
        // ���Ԃ��[���ɂȂ����ꍇ�̏�������
        if (!timeUp && !allEnemiesDefeatedCheck)

        {
            timeUp = true;
            ShowTimeUpUI();
        }
    }

    void ShowTimeUpUI()
    {
        // �uTime's Up!�v��UI��\�����鏈���i��Ƃ��āAText�R���|�[�l���g�̕\����؂�ւ���j
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
        int minutes = Mathf.FloorToInt(seconds / 60); // �����擾
        int remainingSeconds = Mathf.FloorToInt(seconds % 60); // �b���擾

        return string.Format("{0:00}:{1:00}", minutes, remainingSeconds);

    }
}
