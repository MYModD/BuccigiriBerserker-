using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText; // Text オブジェクトへの参照
    private int score = 0; // 倒した敵の数

    void Start()
    {
        // 初期スコアの表示
        UpdateScoreText();
    }

    public void AddScore(int amount)
    {
        score += amount; // スコアを増やす
        UpdateScoreText(); // Text を更新
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString(); // スコアを Text に表示
    }
}
