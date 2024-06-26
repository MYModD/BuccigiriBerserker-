using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BusterControl : MonoBehaviour
{
    public Image gaugeImage; // �i��������Image�R���|�[�l���g�������ɃA�T�C�����܂�
    public float fillSpeed = 0.5f; // �Q�[�W�����܂鑬�x
    private float targetFillAmount = 1f; // �Q�[�W�����܂�ڕW�l

    void Start()
    {
        if (gaugeImage != null)
        {
            gaugeImage.fillAmount = 0f; // ������Ԃ�0�ɐݒ�
        }
    }

    void Update()
    {
        if (gaugeImage != null && gaugeImage.fillAmount < targetFillAmount)
        {
            // ���Ԍo�߂ɉ����ăQ�[�W�𑝉�
            gaugeImage.fillAmount += fillSpeed * Time.deltaTime;
        }
    }
}
