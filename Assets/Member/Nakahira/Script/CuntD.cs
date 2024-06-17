using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CuntD : MonoBehaviour
{
   
    public string tagname; // タグ名を指定するための変数
    public TextMeshProUGUI countText; // カウントを表示するテキスト要素

    
    void Start()
    {
        
        GameObject[] tagObjects = GameObject.FindGameObjectsWithTag(tagname);

        // ゲームオブジェクトの総数を取得
        int count = tagObjects.Length;

        // 総数を表示するテキストを更新する
        countText.text = "/ " + count.ToString();
    }


    // Update is called once per frame
    void Update()
    {
       
    }
}
