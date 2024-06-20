using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text infoText;
    [SerializeField]private float gameTime = 180f; // �Q�[���̎��ԁi�b�j��ݒ�i3�� = 180�b�j
    private bool timeUp = false;
    private bool allEnemiesDefeated = false;
<<<<<<< HEAD
    private int cntenemy;
    //CuntUD cntud;
=======
>>>>>>> parent of ca91a1b (敵の動き修正)

    void Start()
    {
        // �Q�[���J�n���Ɏ��Ԃ̃J�E���g�_�E�����J�n����
        Invoke("CheckGameTime", gameTime);
<<<<<<< HEAD
        //cntenemy = cntud.currentCount;
=======
>>>>>>> parent of ca91a1b (敵の動き修正)
    }

    void Update()
    {
        // �G��S���|�����ꍇ�̏�������
        if (!allEnemiesDefeated)
        {
            allEnemiesDefeated = true;
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
    }

    void ShowAllEnemiesDefeatedUI()
    {
        // �uAll enemies defeated!�v��UI��\�����鏈���i��Ƃ��āAText�R���|�[�l���g�̕\����؂�ւ���j
        infoText.text = "All enemies defeated!";
        infoText.gameObject.SetActive(true);
    }
}
