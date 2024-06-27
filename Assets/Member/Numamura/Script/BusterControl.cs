using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BusterControl : MonoBehaviour
{
    public Image gaugeImage; // �i��������Image�R���|�[�l���g�������ɃA�T�C�����܂�
    public float fillSpeed = 0.1f; // �Q�[�W�����܂鑬�x
    private float targetFillAmount = 1f; // �Q�[�W�����܂�ڕW�l

    public bool _BusterGaugeCheck = default;
    public bool _Beamshot = default;
    void Start()
    {
        if (gaugeImage != null)
        {
            gaugeImage.fillAmount = 0f; // ������Ԃ�0�ɐݒ�
        }

        _BusterGaugeCheck = false;
        _Beamshot = false;
    }

    void Update()
    {
        if (gaugeImage != null && gaugeImage.fillAmount < targetFillAmount && _BusterGaugeCheck == false)
        {
            // ���Ԍo�߂ɉ����ăQ�[�W�𑝉�
            gaugeImage.fillAmount += fillSpeed * Time.deltaTime;
        }
         
        if(gaugeImage.fillAmount == 1)
        {
            _BusterGaugeCheck = true;
        }

        if (gaugeImage.fillAmount == 0)
        {
            _BusterGaugeCheck = false;
            _Beamshot = false;
        }

        if (_BusterGaugeCheck == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _Beamshot = true;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _Beamshot = true;
            }
        }

        if (_Beamshot == true)
        { 
                if (gaugeImage != null && gaugeImage.fillAmount >= 0)
                {
                    // ���Ԍo�߂ɉ����ăQ�[�W������
                    gaugeImage.fillAmount -= fillSpeed * 2 * Time.deltaTime;
                }
            
        }
    }
}
