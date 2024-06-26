using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CuntD : MonoBehaviour
{
   
    //[SerializeField] private string tagname; // タグ名を指定するための変数
    [SerializeField] private TextMeshProUGUI currentCount; // カウントを表示するテキスト要素
    [SerializeField] public int Initial_Value;
    
    void Start()
    {
        
        //GameObject[] tagObjects = GameObject.FindGameObjectsWithTag(tagname);

        // ゲームオブジェクトの総数を取得
        int count =Initial_Value;

        // 総数を表示するテキストを更新する
        currentCount.text = "/ " + Initial_Value.ToString();
    }


    // Update is called once per frame
    void Update()
    {
       
    }
}
