using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI EnemyText;
    [SerializeField] private TextMeshProUGUI TimerText;
    [SerializeField] private TextMeshProUGUI GamejudgeText;
    [SerializeField] private GameObject Button;
    [SerializeField] private float gameTime = 180f; // �Q�[���̎��ԁi�b�j��ݒ�i3�� = 180�b�j
    private bool timeUp = false;
    private bool allEnemiesDefeatedCheck = false;
    private bool allEnemiesDefeated = false;
    private int cntenemy;
    CuntUD cntud;
    void Start()
    {
        // �Q�[���J�n���Ɏ��Ԃ̃J�E���g�_�E�����J�n����
        Invoke("CheckGameTime", gameTime);
        cntud = GameObject.FindGameObjectWithTag("EnemyNumber").GetComponent<CuntUD>();
      cntenemy = cntud.currentCount;
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
    }

    void CheckGameTime()
    {
        // ���Ԃ��[���ɂȂ����ꍇ�̏�������
        if (!timeUp)
        {
            timeUp = true;
            ShowTimeUpUI();
        }
    }

    void ShowTimeUpUI()
    {
        // �uTime's Up!�v��UI��\�����鏈���i��Ƃ��āAText�R���|�[�l���g�̕\����؂�ւ���j
        EnemyText.text = "99";
        TimerText.text = "Time's Up!";
        GamejudgeText.text = "All enemies defeated! ";
        EnemyText.gameObject.SetActive(true);
        TimerText.gameObject.SetActive(true);
        GamejudgeText.gameObject.SetActive(true);
        Button.gameObject.SetActive(true);
    }

    void ShowAllEnemiesDefeatedUI()
    {
        // �uAll enemies defeated!�v��UI��\�����鏈���i��Ƃ��āAText�R���|�[�l���g�̕\����؂�ւ���j
        EnemyText.text = "99";
        TimerText.text = "Time's Up!";
        GamejudgeText.text = "All enemies defeated! ";
        EnemyText.gameObject.SetActive(true);
        TimerText.gameObject.SetActive(true);
        GamejudgeText.gameObject.SetActive(true);
        Button.gameObject.SetActive(true);
    }
}
