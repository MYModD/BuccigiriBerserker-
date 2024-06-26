using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BusterControl : MonoBehaviour
{
    public Image gaugeImage; // 進捗部分のImageコンポーネントをここにアサインします
    public float fillSpeed = 0.5f; // ゲージが溜まる速度
    private float targetFillAmount = 1f; // ゲージが溜まる目標値

    void Start()
    {
        if (gaugeImage != null)
        {
            gaugeImage.fillAmount = 0f; // 初期状態を0に設定
        }
    }

    void Update()
    {
        if (gaugeImage != null && gaugeImage.fillAmount < targetFillAmount)
        {
            // 時間経過に応じてゲージを増加
            gaugeImage.fillAmount += fillSpeed * Time.deltaTime;
        }
    }
}
