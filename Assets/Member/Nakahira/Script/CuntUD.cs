using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CuntUD : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI countTexts; // 現在の破壊した敵の数を表示するテキスト要素
    [SerializeField] private TextMeshProUGUI falseObjectCountText; // フォールスなオブジェクトの数を表示するテキスト要素
    [SerializeField] private TextMeshProUGUI homekotoba; // エクセレントの表示

    private int inactiveMisailHit2Count; // フォールスな Misail_Hit2 コンポーネントの数
    public int DestoroyEnemies; // 破壊した敵の数
    private int counthome; // カウンタ
    private int juu = 10; // エクセレントの表示のための閾値
    private int saisyo = 0; // 破壊した敵の初期値
    private int maedec = 0; // 前回の非アクティブな Misail_Hit2 コンポーネントの数

    void Start()
    {
        // 初期化処理
        inactiveMisailHit2Count = 0;
        DestoroyEnemies = saisyo;
        countTexts.text = DestoroyEnemies.ToString();
        falseObjectCountText.text = inactiveMisailHit2Count.ToString();
        homekotoba.text = "";
    }

    void Update()
    {
        // 現在の非アクティブな Misail_Hit2 コンポーネントの数をカウント
        Misail_Hit2[] allMisailHit2 = FindObjectsOfType<Misail_Hit2>();
        int currentInactiveCount = 0;

        foreach (Misail_Hit2 script in allMisailHit2)
        {
            if (!script.gameObject.activeSelf)
            {
                currentInactiveCount++;
            }
        }

        // 非アクティブな Misail_Hit2 コンポーネントの数が増えた場合
        if (currentInactiveCount > maedec)
        {
            DestoroyEnemies++; // 破壊した敵の数を増やす
            counthome++; // カウンタを増やす
            homekotoba.text = ""; // エクセレントの表示をリセット
            maedec = currentInactiveCount; // 前回の非アクティブな Misail_Hit2 コンポーネントの数を更新
            UpdateCountText(); // UI を更新
        }

        // エクセレントの表示
        if (counthome == juu)
        {
            homekotoba.text = "Excellent!";
            counthome = 0;
        }
    }

    void UpdateCountText()
    {
        countTexts.text = DestoroyEnemies.ToString(); // 破壊した敵の数を表示
        falseObjectCountText.text = maedec.ToString(); // 非アクティブな Misail_Hit2 コンポーネントの数を表示
    }


    //[SerializeField] private TextMeshProUGUI countTexts;
    //[SerializeField] private TextMeshProUGUI homekotoba;

    //public int DestoroyEnemies;
    //private int counthome;
    //private int juu = 10;
    //private int saisyo = 0;
    //private int maedec = 0; // maedec を初期化

    //void Start()
    //{
    //    Misail_Hit2[] allMisailHit2 = FindObjectsOfType<Misail_Hit2>();
    //    int inactiveMisailHit2Count = 0;

    //    // 非アクティブな Misail_Hit2 コンポーネントをカウント
    //    foreach (Misail_Hit2 script in allMisailHit2)
    //    {
    //        if (!script.gameObject.activeSelf)
    //        {
    //            inactiveMisailHit2Count++;
    //        }
    //    }

    //    Debug.Log("非アクティブな Misail_Hit2 コンポーネントを持つオブジェクトの数: " + inactiveMisailHit2Count);

    //    // ゲームオブジェクトの総数を取得
    //    DestoroyEnemies = saisyo;

    //    countTexts.text = "0";
    //    UpdateCountText(); // テキストを初期表示

    //    // 初期の maedec を設定
    //    maedec = inactiveMisailHit2Count;
    //}

    //void Update()
    //{
    //    Misail_Hit2[] allMisailHit2 = FindObjectsOfType<Misail_Hit2>();
    //    int inactiveMisailHit2Count = 0;

    //    // 非アクティブな Misail_Hit2 コンポーネントをカウント
    //    foreach (Misail_Hit2 script in allMisailHit2)
    //    {
    //        if (!script.gameObject.activeSelf)
    //        {
    //            inactiveMisailHit2Count++;
    //        }
    //    }

    //    Debug.Log("非アクティブな Misail_Hit2 コンポーネントを持つオブジェクトの数: " + inactiveMisailHit2Count);

    //    // 敵が倒された時の処理
    //    if (inactiveMisailHit2Count > maedec)
    //    {
    //        DestoroyEnemies += 1;
    //        counthome += 1;
    //        homekotoba.text = "";
    //        maedec = inactiveMisailHit2Count;
    //        UpdateCountText();
    //    }

    //    // Excellent! の表示
    //    if (counthome == juu)
    //    {
    //        homekotoba.text = "Excellent!";
    //        counthome = 0;
    //    }
    //}

    //void UpdateCountText()
    //{
    //    countTexts.text = DestoroyEnemies.ToString(); // 現在のカウントでテキストを更新する
    //}





    // Misail_Hit2[] allMisailHit2;
    // // Misail_Hit2 スクリプトがアタッチされているオブジェクトのうち、SetActive(false)に設定されているものの数をカウントする



    //public int inactiveMisailHit2Coun;



    ////[SerializeField] private string tagname; // タグ名を指定するための変数
    //[SerializeField] private TextMeshProUGUI countTexts; // カウントを表示するテキスト要素
    // [SerializeField] private TextMeshProUGUI homekotoba;
    // public int CountText; // 現在のカウント数
    // //private int count; // カウントする数
    // //private int previousCount; // 前回のカウント数
    // private int counthome;
    // public int DestoroyEnemies;
    // private int juu = 10;
    // private int saisyo = 0;
    // public Misail_Hit2 Enemydec;
    // private int maedec;
    // void Start()
    // {

    //     Misail_Hit2[] allMisailHit2 = FindObjectsOfType<Misail_Hit2>();
    //     int inactiveMisailHit2Count = 0;
    //     //Misail_Hit2 Enemydec = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Misail_Hit2>();


    //     // タグ名に対応するゲームオブジェクトの配列を取得
    //     //GameObject[] tagObjects = GameObject.FindGameObjectsWithTag(tagname);
    //     // Enemydecを初期化する（例としてFindObjectOfTypeを使用する）
    //     //Enemydec = FindObjectOfType<Misail_Hit2>();
    //     // ゲームオブジェクトの総数を取得
    //     DestoroyEnemies = saisyo;

    //     //maedec = Enemydec.DesEne;
    //     //Debug.Log(Enemydec.DesEne);
    //     // 初期のカウントを設定する
    //     //CountText = count;
    //     //previousCount = CountText;
    //     countTexts.text = "0";
    //     // テキストを更新して初期表示を設定する
    //     UpdateCountText();

    // }
    // void Update()
    // {
    //     Misail_Hit2[] allMisailHit2 = FindObjectsOfType<Misail_Hit2>();
    //     foreach (Misail_Hit2 script in allMisailHit2)
    //     {
    //         if (!script.gameObject.activeSelf)
    //         {
    //             maedec = inactiveMisailHit2Count;
    //             inactiveMisailHit2Count++;
    //         }
    //     }

    //     Debug.Log("非アクティブな Misail_Hit2 コンポーネントを持つオブジェクトの数: " + inactiveMisailHit2Count);
    //     //敵が倒された時
    //     if (inactiveMisailHit2Count > maedec)
    //     {
    //         Debug.Log("非アクティブな Misail_Hit2 コンポーネントを持つオブジェクトの数: " + inactiveMisailHit2Count);
    //         DestoroyEnemies += 1;
    //         counthome += 1;
    //         homekotoba.text = "";
    //         maedec = inactiveMisailHit2Count;
    //         UpdateCountText();
    //     }
    //     // 現在のカウント数を取得
    //     //CountText = CountObjectsWithTag();
    //     if (counthome == juu)
    //     {
    //         homekotoba.text = "Excellent!";
    //         counthome = 0;
    //     }
    //     //// カウントが減少した場合のみ更新する
    //     //if (CountText < previousCount)
    //     //{
    //     //    counthome += 1;
    //     //    homekotoba.text = "";
    //     //    DestoroyEnemies += 1;
    //     //    previousCount = CountText; // 前回のカウントを更新
    //     //    UpdateCountText(); // テキストを更新

    //     //}
    // }

    // //private int CountObjectsWithTag()
    // //{
    // //    GameObject[] tagObjects = GameObject.FindGameObjectsWithTag(tagname);
    // //    return tagObjects.Length;
    // //}
    // void UpdateCountText()
    // {
    //     countTexts.text = "" + DestoroyEnemies.ToString(); // 現在のカウントでテキストを更新する

    // }
}
