using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float totalTime = 180.0f; // �^�C�}�[�̏����ݒ莞�ԁi�b�j
    private float timeLeft; // ���݂̎c�莞��

    private float timemin;
    private float timesec;
    public Text countdownText; // UI�e�L�X�g�I�u�W�F�N�g

    void Start()
    {
        timeLeft = totalTime;
        
        countdownText = GetComponent<Text>();
        UpdateUI(); // UI���X�V���ď����ݒ莞�Ԃ�\��
    }

    void Update()
    {
        // �c�莞�Ԃ����炷
        timeLeft -= Time.deltaTime;
        timemin = timeLeft / 60;
        timesec = timeLeft % 60;
        Debug.Log(timemin);
        Debug.Log(timesec);

        // �^�C�}�[��0�ȉ��ɂȂ�����A�w�肵�����������s����i�����ł͗�Ƃ���Debug.Log�j
        if (timeLeft <= 0.0f)
        {
            timeLeft = 0.0f;
            timemin = 0.0f;
            timesec = 0.0f;
            Debug.Log("Time's up!");
            // �����ɃQ�[���I�[�o�[�����Ȃǂ���������
        }



        // UI���X�V����
        UpdateUI();
    }

    void UpdateUI()
    {
        // UI�e�L�X�g�Ɏc�莞�Ԃ�\������
        if (countdownText != null)
        {
            if (timesec > 9)
            {
                //countdownText.text = Mathf.CeilToInt(timeLeft).ToString();
                countdownText.text = Mathf.FloorToInt(timemin).ToString() + ":" + Mathf.FloorToInt(timesec).ToString();
            }
            if(timesec < 10)
            {
                countdownText.text = Mathf.FloorToInt(timemin).ToString() + ":" + "0" + Mathf.FloorToInt(timesec).ToString();
            }
        }
    }
}


