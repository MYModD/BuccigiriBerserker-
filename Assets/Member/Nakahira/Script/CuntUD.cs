using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CuntUD : MonoBehaviour
{
    public string tagname; // タグ名を指定するための変数
    public TextMeshProUGUI countTexts; // カウントを表示するテキスト要素
    private int count; // カウントする数
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
        //Vector3 targetPos = player.position;
    }
    void UpdateCountText()
    {
        countTexts.text = "" + count.ToString(); // テキストを更新する
    }
}
