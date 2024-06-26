using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CuntUD : MonoBehaviour
{
   
    public string tagname; // タグ名を指定するための変数
    public TextMeshProUGUI countTexts; // カウントを表示するテキスト要素
    public TextMeshProUGUI homekotoba;
    private int count; // カウントする数
    private int previousCount; // 前回のカウント数
    public int currentCount; // 現在のカウント数
    private int counthome;
    public int DestoroyEnemies;
    private int juu = 10;
    void Start()
    {

        // タグ名に対応するゲームオブジェクトの配列を取得
        GameObject[] tagObjects = GameObject.FindGameObjectsWithTag(tagname);

        // ゲームオブジェクトの総数を取得
        count = tagObjects.Length;

        // 初期のカウントを設定する
        currentCount = count;
        previousCount = currentCount;

        // テキストを更新して初期表示を設定する
        UpdateCountText();

    }
    void Update()
    {
      
        // 現在のカウント数を取得
        currentCount = CountObjectsWithTag();
        if(counthome == juu)
        {
            homekotoba.text = "Excellent!";
            counthome = 0;
        }
        // カウントが減少した場合のみ更新する
        if (currentCount < previousCount)
        {
            counthome += 1;
            homekotoba.text = "";
            DestoroyEnemies += 1;
            previousCount = currentCount; // 前回のカウントを更新
            UpdateCountText(); // テキストを更新
            print("a");
        }
    }

    private int CountObjectsWithTag()
    {
        GameObject[] tagObjects = GameObject.FindGameObjectsWithTag(tagname);
        return tagObjects.Length;
    }
    void UpdateCountText()
    {
        countTexts.text = "" + currentCount.ToString(); // 現在のカウントでテキストを更新する
        
    }
}
