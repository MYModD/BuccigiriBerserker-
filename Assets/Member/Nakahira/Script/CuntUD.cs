using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CuntUD : MonoBehaviour
{
   
   [SerializeField] private string tagname; // タグ名を指定するための変数
    [SerializeField] private TextMeshProUGUI countTexts; // カウントを表示するテキスト要素
    [SerializeField] private TextMeshProUGUI homekotoba;
    public int CountText; // 現在のカウント数
    //private int count; // カウントする数
    //private int previousCount; // 前回のカウント数
    private int counthome;
    public int DestoroyEnemies;
    private int juu = 10;
    private int saisyo = 0;
    Misail_Hit2 Enemydec;
    private int maedec;
    void Start()
    {

        // タグ名に対応するゲームオブジェクトの配列を取得
        //GameObject[] tagObjects = GameObject.FindGameObjectsWithTag(tagname);

        // ゲームオブジェクトの総数を取得
        DestoroyEnemies = saisyo;

        maedec = Enemydec.DesEne;

        // 初期のカウントを設定する
        //CountText = count;
        //previousCount = CountText;

        // テキストを更新して初期表示を設定する
        UpdateCountText();

    }
    void Update()
    {
        //敵が倒された時
        if(Enemydec.DesEne> maedec)
        {
            DestoroyEnemies += 1;
            counthome += 1;
            homekotoba.text = "";
            maedec = Enemydec.DesEne;
            UpdateCountText();
        }
        // 現在のカウント数を取得
        //CountText = CountObjectsWithTag();
        if(counthome == juu)
        {
            homekotoba.text = "Excellent!";
            counthome = 0;
        }
        //// カウントが減少した場合のみ更新する
        //if (CountText < previousCount)
        //{
        //    counthome += 1;
        //    homekotoba.text = "";
        //    DestoroyEnemies += 1;
        //    previousCount = CountText; // 前回のカウントを更新
        //    UpdateCountText(); // テキストを更新
           
        //}
    }

    //private int CountObjectsWithTag()
    //{
    //    GameObject[] tagObjects = GameObject.FindGameObjectsWithTag(tagname);
    //    return tagObjects.Length;
    //}
    void UpdateCountText()
    {
        countTexts.text = "" + DestoroyEnemies; // 現在のカウントでテキストを更新する
        
    }
}
