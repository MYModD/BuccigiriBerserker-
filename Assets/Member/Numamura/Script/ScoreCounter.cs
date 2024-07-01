using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public Text ScoreCountText; // UI�e�L�X�g�I�u�W�F�N�g
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
        // UI�e�L�X�g�Ɏc�莞�Ԃ�\������
        if (ScoreCountText != null)
        {
            ScoreCountText.text = "SCORE:" + ScoreValue.ToString();

        }
    }

}
