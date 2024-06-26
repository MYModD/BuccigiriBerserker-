using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Result : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI EnemyText;
    [SerializeField] private TextMeshProUGUI TimerText;
    [SerializeField] private TextMeshProUGUI GamejudgeText;
    [SerializeField] private float gameTime = 180f; // �Q�[���̎��ԁi�b�j��ݒ�i3�� = 180�b�j

    private bool timeUp = false;
    private bool allEnemiesDefeated = false;
    private int initialEnemyCount;
    private int destroyedEnemyCount;

    // ���ʂ�ێ�����f�[�^�N���X
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

    // GameManager �̃C���X�^���X��ێ�����ÓI�ȃv���p�e�B
    private static Result instance;
    public static Result Instance { get { return instance; } }

    void Awake()
    {
        // �C���X�^���X�����ɑ��݂���ꍇ�͔j������
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // �C���X�^���X��ݒ肷��
        instance = this;

        // �V�[���J�ڎ��ɔj������Ȃ��悤�ɂ���
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        // �G�̏������Ɣj�󂵂��G�̐���ݒ肷��
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

            // �c�莞�Ԃ�0�ȉ��ɂȂ����玞�Ԑ؂�̏��������s
            if (gameTime <= 0)
            {
                gameTime = 0;
                timeUp = true;
                ShowTimeUpUI();
            }
        }
    }

    // �G��|�������ǂ������`�F�b�N����
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
        // ���ʃf�[�^���쐬���AGameManager���̂��V�[���Ԃňێ�����
        ResultData resultData = new ResultData(destroyedEnemyCount, gameTime, "Time Up!");
        DontDestroyOnLoad(this.gameObject);

        // ResultScene�ɑJ�ڂ���
        SceneManager.LoadScene("NewResultScene");
    }

    void ShowAllEnemiesDefeatedUI()
    {
        // ���ʃf�[�^���쐬���AGameManager���̂��V�[���Ԃňێ�����
        ResultData resultData = new ResultData(destroyedEnemyCount, gameTime, "All Enemies Destroyed!");
        DontDestroyOnLoad(this.gameObject);

        // ResultScene�ɑJ�ڂ���
        SceneManager.LoadScene("NewResultScene");
    }
}
