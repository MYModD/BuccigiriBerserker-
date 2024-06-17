using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CuntUD : MonoBehaviour
{
    public string tagname; // タグ名を指定するための変数
    public TextMeshProUGUI countTexts; // カウントを表示するテキスト要素
    private int count; // カウントする数
    //private float timer = 0.3f; // 1秒ごとに減少させるためのタイマー
    //private float currentTime = 0f; // 現在の経過時間
    private int previousCount; // 前回のカウント数
    private int currentCount; // 現在のカウント数

    void Start()
    {
        // タグ名に対応するゲームオブジェクトの配列を取得
        GameObject[] tagObjects = GameObject.FindGameObjectsWithTag(tagname);

        // ゲームオブジェクトの総数を取得
        count = tagObjects.Length;

        // 総数を表示するテキストを更新する
        UpdateCountText();
    }
    void Update()
    {
        // 現在のカウント数を取得
        currentCount = CountObjectsWithTag();

        // カウントが減少した場合のみ更新する
        if (currentCount < previousCount)
        {
            previousCount = currentCount; // 前回のカウントを更新
            UpdateCountText(); // テキストを更新
            print("a");
        }
    }
    private int CountObjectsWithTag()
    {
        GameObject[] tagObjects = GameObject.FindGameObjectsWithTag(tagname);
        return tagObjects.Length;
        print("d");
    }
    void UpdateCountText()
    {
        print("s");
        countTexts.text = "" + count.ToString(); // テキストを更新する
    }
}
