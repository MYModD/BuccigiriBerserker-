using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class Result : MonoBehaviour
{
    [SerializeField] private float gameTime; // �Q�[���̎��ԁi�b�j��ݒ�i3�� = 180�b�j
    private bool timeUp = false;
    private bool allEnemiesDefeatedCheck = false;
    private bool allEnemiesDefeated = false;
    private int cntenemy;
    private int cntdestoroy;
    [HideInInspector] public string _strDestoryEnemy;
    [HideInInspector] public string _strTime;
    [HideInInspector] public string _gamejudge;
    CuntUD cntud;
    CuntD cntd;
    void Start()
    {
        DontDestroyOnLoad(this);
        cntud = GameObject.FindGameObjectWithTag("EnemyNumber").GetComponent<CuntUD>();
        cntd = GameObject.FindGameObjectWithTag("EnemyNumber").GetComponent<CuntD>();
        cntenemy = cntd.Initial_Value;
        cntdestoroy = cntud.DestoroyEnemies;
    }
    void Update()
    {
        if (cntenemy <= cntdestoroy)
            allEnemiesDefeated = true;

        // �G��S���|�����ꍇ�̏�������
        if (!allEnemiesDefeatedCheck && allEnemiesDefeated)
        {
            allEnemiesDefeatedCheck = true;
            _strTime = "Time: " + FormatTime(gameTime);
            _strDestoryEnemy = "DestroyEnemies: " + cntdestoroy.ToString();
            _gamejudge = "All Enemy Destoryed!!";
            ShowAllEnemiesDefeatedUI();
        }
        gameTime -= Time.deltaTime;
        Debug.Log("Remaining Time: " + gameTime); // �f�o�b�O���O��ǉ����Ċm�F
        if (!timeUp && !allEnemiesDefeatedCheck)
        {
            if (gameTime <= 0)
            {
                gameTime = 0;
                CheckGameTime();
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            cntdestoroy += 1;
        }
    }

    void CheckGameTime()
    {
        // ���Ԃ��[���ɂȂ����ꍇ�̏�������
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
        SceneManager.LoadScene("NewResultScene");
    }
    void ShowAllEnemiesDefeatedUI()
    {
        SceneManager.LoadScene("NewResultScene");
    }
    string FormatTime(float seconds)
    {
        int minutes = Mathf.FloorToInt(seconds / 60); // �����擾
        int remainingSeconds = Mathf.FloorToInt(seconds % 60); // �b���擾
        return string.Format("{0:00}:{1:00}", minutes, remainingSeconds);
    }
}