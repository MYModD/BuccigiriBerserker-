using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BusterControl : MonoBehaviour
{
    public Image gaugeImage; // 進捗部分のImageコンポーネントをここにアサインします
    public float fillSpeed = 0.1f; // ゲージが溜まる速度
    private float targetFillAmount = 1f; // ゲージが溜まる目標値

    public bool _BusterGaugeCheck = default;
    public bool _Beamshot = default;
    void Start()
    {
        if (gaugeImage != null)
        {
            gaugeImage.fillAmount = 0f; // 初期状態を0に設定
        }

        _BusterGaugeCheck = false;
        _Beamshot = false;
    }

    void Update()
    {
        if (gaugeImage != null && gaugeImage.fillAmount < targetFillAmount && _BusterGaugeCheck == false)
        {
            // 時間経過に応じてゲージを増加
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
                    // 時間経過に応じてゲージを減少
                    gaugeImage.fillAmount -= fillSpeed * 2 * Time.deltaTime;
                }
            
        }
    }
}
