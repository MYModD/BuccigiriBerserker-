using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CuntUD : MonoBehaviour
{

  

    // Misail_Hit2 スクリプトがアタッチされているオブジェクトのうち、SetActive(false)に設定されているものの数をカウントする
    private Misail_Hit2 misailHit2; // Misail_Hit2 スクリプトへの参照


    //[SerializeField] private string tagname; // タグ名を指定するための変数
    [SerializeField] private TextMeshProUGUI countTexts; // カウントを表示するテキスト要素
    [SerializeField] private TextMeshProUGUI homekotoba;
    public int CountText; // 現在のカウント数
                          //private int count; // カウントする数
                          //private int previousCount; // 前回のカウント数
    private int inactiveMisailHit2Count;
    private int counthome;
    public int DestoroyEnemies;
    private int juu = 10;
    private int saisyo = 0;
    public Misail_Hit2 Enemydec;
    private int maedec;

    void Start()
    {
        //Misail_Hit2 Eneyd = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Misail_Hit2>();
        //misailHit2 = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Misail_Hit2>();
        inactiveMisailHit2Count = 0;
        //Misail_Hit2 Enemydec = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Misail_Hit2>();

       
        // タグ名に対応するゲームオブジェクトの配列を取得
        //GameObject[] tagObjects = GameObject.FindGameObjectsWithTag(tagname);
        // Enemydecを初期化する（例としてFindObjectOfTypeを使用する）
        //Enemydec = FindObjectOfType<Misail_Hit2>();
        // ゲームオブジェクトの総数を取得
        DestoroyEnemies = saisyo;

        //maedec = Enemydec.DesEne;
        //Debug.Log(Enemydec.DesEne);
        // 初期のカウントを設定する
        //CountText = count;
        //previousCount = CountText;
        countTexts.text = "0";
        // テキストを更新して初期表示を設定する
        UpdateCountText();

    }
    void Update()
    {


        //Misail_Hit2 Enemydec = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Misail_Hit2>();
        //敵が倒された時
        if (inactiveMisailHit2Count > maedec)
        {
            Debug.Log(inactiveMisailHit2Count);
            DestoroyEnemies += 1;
            counthome += 1;
            homekotoba.text = "";
            maedec = inactiveMisailHit2Count;
            UpdateCountText();
        }
        // 現在のカウント数を取得
        //CountText = CountObjectsWithTag();
        if (counthome == juu)
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
    public void UpdateCountText()
    {
        //countTexts.text = misailHit2._desEne.ToString(); // Misail_Hit2 の DesEne を参照して UI を更新する
        countTexts.text = misailHit2._desEne.ToString();

    }
}
