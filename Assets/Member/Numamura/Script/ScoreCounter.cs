using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public Text ScoreCountText; // UIテキストオブジェクト
    public int ScoreValue;
    private int ScoreRate;

    public ComboCount ComboCount;
    // Start is called before the first frame update
    void Start()
    {
        ScoreValue = 0;
        ScoreCountText = GetComponent<Text>();
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        ScoreRate = ComboCount.ComboValue;

        if (ComboCount._toScore == true)
        {
            ScoreValue = ScoreValue + ScoreRate * 500;
            ComboCount._toScore = false;
        }

            UpdateUI();

    }
    
    void UpdateUI()
    {
        // UIテキストに残り時間を表示する
        if (ScoreCountText != null)
        {
            ScoreCountText.text = "SCORE:" + ScoreValue.ToString();

        }
    }

}
