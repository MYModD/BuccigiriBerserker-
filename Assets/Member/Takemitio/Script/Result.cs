using UnityEngine;
using UnityEngine.UI;
<<<<<<< HEAD

public class GameManager : MonoBehaviour
{
    public Text infoText;
    [SerializeField]private float gameTime = 180f; // �Q�[���̎��ԁi�b�j��ݒ�i3�� = 180�b�j
    private bool timeUp = false;
    private bool allEnemiesDefeated = false;

    private int cntenemy;
    //CuntUD cntud;



    void Start()
    {
        // �Q�[���J�n���Ɏ��Ԃ̃J�E���g�_�E�����J�n����
        Invoke("CheckGameTime", gameTime);
=======
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
    void Start()
    {
        // �Q�[���J�n���Ɏ��Ԃ̃J�E���g�_�E�����J�n����
        //Invoke("CheckGameTime", gameTime);
        cntud = GameObject.FindGameObjectWithTag("EnemyNumber").GetComponent<CuntUD>();
        cntenemy = cntud.currentCount;
        cntdestoroy = cntud.DestoroyEnemies;
>>>>>>> main
    }

    void Update()
    {
<<<<<<< HEAD
        // �G��S���|�����ꍇ�̏�������
        if (!allEnemiesDefeated)
        {
            allEnemiesDefeated = true;
            ShowAllEnemiesDefeatedUI();
        }
=======
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
        if(Input.GetKeyDown(KeyCode.A))
        {
            cntenemy -= 1;
        }
>>>>>>> main
    }

    void CheckGameTime()
    {
        // ���Ԃ��[���ɂȂ����ꍇ�̏�������
<<<<<<< HEAD
        if (!timeUp)
=======
        if (!timeUp && !allEnemiesDefeatedCheck)
>>>>>>> main
        {
            timeUp = true;
            ShowTimeUpUI();
        }
    }

<<<<<<< HEAD
    //bool AllEnemiesDefeated()
    //{
    //    // �G��S���|�������ǂ����𔻒肷�鏈���i��Ƃ��āAEnemyManager���Ǘ�����G�̐���0�ɂȂ����Ƃ���j
    //    //return EnemyManager.Instance.EnemyCount == 0;
    //}

    void ShowTimeUpUI()
    {
        // �uTime's Up!�v��UI��\�����鏈���i��Ƃ��āAText�R���|�[�l���g�̕\����؂�ւ���j
        infoText.text = "Time's Up!";
        infoText.gameObject.SetActive(true);
=======
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
>>>>>>> main
    }

    void ShowAllEnemiesDefeatedUI()
    {
        // �uAll enemies defeated!�v��UI��\�����鏈���i��Ƃ��āAText�R���|�[�l���g�̕\����؂�ւ���j
<<<<<<< HEAD
        infoText.text = "All enemies defeated!";
        infoText.gameObject.SetActive(true);
=======
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
>>>>>>> main
    }
}
