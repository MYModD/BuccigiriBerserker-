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
        // GameManager����ResultData���擾����
        Result.ResultData resultData = GameObject.FindGameObjectWithTag("GameController").GetComponent<Result.ResultData>();

        print(resultData.gameResult);
        print(resultData.destroyedEnemies);
        print(resultData.remainingTime);
        // ���ʂ�\������
        resultText.text = resultData.gameResult;
        enemiesDestroyedText.text = "Destroyed Enemies: " + resultData.destroyedEnemies.ToString();
        //this.gameObject.SetActive(true);
        timeText.text = "Time: " + FormatTime(resultData.remainingTime);

        // GameManager�̃C���X�^���X��j������i�s�v�ɂȂ�����j������j
        Destroy(Result.Instance.gameObject);
    }

    string FormatTime(float seconds)
    {
        int minutes = Mathf.FloorToInt(seconds / 60); // �����擾
        int remainingSeconds = Mathf.FloorToInt(seconds % 60); // �b���擾

        return string.Format("{0:00}:{1:00}", minutes, remainingSeconds);
    }
}
