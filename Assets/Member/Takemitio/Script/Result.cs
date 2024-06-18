using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText; // Text �I�u�W�F�N�g�ւ̎Q��
    private int score = 0; // �|�����G�̐�

    void Start()
    {
        // �����X�R�A�̕\��
        UpdateScoreText();
    }

    public void AddScore(int amount)
    {
        score += amount; // �X�R�A�𑝂₷
        UpdateScoreText(); // Text ���X�V
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString(); // �X�R�A�� Text �ɕ\��
    }
}
