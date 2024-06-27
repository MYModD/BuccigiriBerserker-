using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ResultScene : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI EnemyText;
    [SerializeField] private TextMeshProUGUI TimerText;
    [SerializeField] private TextMeshProUGUI GamejudgeText;
    [SerializeField] private GameObject Button;
    Result _result;

    void Start()
    {
        _result = GameObject.FindGameObjectWithTag("ResultManager").GetComponent<Result>();
        EnemyText.text = _result._strDestoryEnemy;
        TimerText.text = _result._strTime;
        GamejudgeText.text = _result._gamejudge;
        GameObject.FindGameObjectWithTag("ResultManager").gameObject.SetActive(true);
    }
    void Update()
    {

    }
}

