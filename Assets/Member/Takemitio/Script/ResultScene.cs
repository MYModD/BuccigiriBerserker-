using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResultSceneManager : MonoBehaviour
{
    public TextMeshProUGUI resultText;
    public TextMeshProUGUI enemiesDestroyedText;
    public TextMeshProUGUI timeText;
    [SerializeField] private GameObject Botton;

    void Start()
    {
        // GameManagerからResultDataを取得する
        Result.ResultData resultData = Result.Instance.GetComponent<Result.ResultData>();

        // 結果を表示する
        resultText.text = resultData.gameResult;
        enemiesDestroyedText.text = "Destroyed Enemies: " + resultData.destroyedEnemies.ToString();
        timeText.text = "Time: " + FormatTime(resultData.remainingTime);

        // GameManagerのインスタンスを破棄する（不要になったら破棄する）
        Destroy(Result.Instance.gameObject);
    }

    string FormatTime(float seconds)
    {
        int minutes = Mathf.FloorToInt(seconds / 60); // 分を取得
        int remainingSeconds = Mathf.FloorToInt(seconds % 60); // 秒を取得

        return string.Format("{0:00}:{1:00}", minutes, remainingSeconds);
    }
}
