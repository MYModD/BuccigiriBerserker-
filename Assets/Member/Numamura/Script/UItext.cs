using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UItext : MonoBehaviour
{
    public float missileCou;
    public Text uitext;

    void Start()
    {
        missileCou = 50;
        UpdateUI(); // UIを更新して初期設定時間を表示
    }

    void Update()
    {
        

        // UIを更新する
        UpdateUI();
    }

    void UpdateUI()
    {
        // UIテキストに残り時間を表示する
        if (uitext != null)
        {
            
                uitext.text = "×" + missileCou;
            
            
        }
    }
}


