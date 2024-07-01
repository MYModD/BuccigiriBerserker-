using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboCount : MonoBehaviour
{
   
    public Text ComboCountText; // UIテキストオブジェクト
    public int ComboValue;
    private bool _ComboCheck = default;
    private int checkdestroy;

    public bool _toScore = default;
    public LifebarManager lifebarmanager;
    public DestroyEnemyCount destroyEnemyCount;
    void Start()
    {
        checkdestroy = destroyEnemyCount.value;
        ComboValue = 0;
        ComboCountText = GetComponent<Text>();
        _toScore = false;
        UpdateUI(); // UIを更新して初期設定時間を表示
    }

    void Update()
    {
        _ComboCheck = lifebarmanager._ComboReset;

        if(checkdestroy < destroyEnemyCount.value)
        {
            ComboValue++;
            _toScore = true;
            checkdestroy = destroyEnemyCount.value;
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


