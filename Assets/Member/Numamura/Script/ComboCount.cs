using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboCount : MonoBehaviour
{
   
    public Text ComboCountText; // UIテキストオブジェクト
    public int ComboValue;
    private bool _ComboCheck;


    public LifebarManager lifebarmanager;
    void Start()
    {

        ComboValue = 0;
        ComboCountText = GetComponent<Text>();
        UpdateUI(); // UIを更新して初期設定時間を表示
    }

    void Update()
    {
        _ComboCheck = lifebarmanager._ComboReset;

        if(Input.GetKeyDown(KeyCode.Y))
        {
            ComboValue++;
        }

        if(_ComboCheck == true)
        {
            ComboValue = 0;
            lifebarmanager._ComboReset = false;
        }

        // UIを更新する
        UpdateUI();
    }

    void UpdateUI()
    {
        // UIテキストに残り時間を表示する
        if (ComboCountText != null)
        {
            
                ComboCountText.text = ComboValue.ToString() + "COMBO";
            
            
        }
    }
}


