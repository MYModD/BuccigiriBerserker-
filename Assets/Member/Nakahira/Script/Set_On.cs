using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set_On : MonoBehaviour
{

    public Collider myhako;
    private NewEnemyMove enemymove;
    private EneMisa missile;
    // プレイヤーの位置とプレイヤーとの距離
    public Transform plyer;
    public float plykyori;

    void Start()
    {
        // 初期化
        enemymove = GetComponent<NewEnemyMove>();
        missile = GetComponent<EneMisa>();
        myhako.enabled = false;
    }

    void Update()
    {
        // プレイヤーとの距離を計算
        float sqrDistance = (transform.position - plyer.position).sqrMagnitude;

        // 距離が指定した範囲内であれば敵のオブジェクトを有効化
        if (sqrDistance < plykyori * plykyori)
        {
            myhako.enabled = true;
            enemymove.enabled = true;
            missile.enabled = true;
        }
        //else
        //{
        //    // 範囲外であれば敵のオブジェクトを無効化
        //    myhako.enabled = false;
        //    enemymove.enabled = false;
        //    missile.enabled = false;
        //}
    }

    //// ゲームオブジェクトのボックスコライダーとメッシュレンダラー
    //public Collider myhako;
    //private NewEnemyMove enemymove;
    //private EneMisa missile;
    //// プレイヤーの位置とプレイヤーとの距離
    //public Transform plyer;
    //public float plykyori;

    //void Start()
    //{
    //    // 初期化
    //    enemymove = GetComponent<NewEnemyMove>();
    //    missile = GetComponent<EneMisa>();
    //    myhako.enabled = false;
    //}

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.transform == plyer)
    //    {
    //        // プレイヤーが範囲内に入った時に処理を有効化
    //        myhako.enabled = true;
    //        enemymove.enabled = true;
    //        missile.enabled = true;
    //    }
    //}

    //void OnTriggerExit(Collider other)
    //{
    //    if (other.transform == plyer)
    //    {
    //        // プレイヤーが範囲外に出た時に処理を無効化
    //        myhako.enabled = false;
    //        enemymove.enabled = false;
    //        missile.enabled = false;
    //    }
    //}
    //// ゲームオブジェクトのボックスコライダーとメッシュレンダラー
    //public Collider myhako;
    //private NewEnemyMove enemymove;
    //private EneMisa missile;
    ////public MeshRenderer mymmes;
    //// プレイヤーの位置とプレイヤーとの距離
    //public Transform plyer;
    //public float plykyori;

    //void Start()
    //{
    //    // メッシュレンダラーを非表示にする
    //    //mymmes.enabled = false;
    //    enemymove = gameObject.GetComponent<NewEnemyMove>();
    //    missile = gameObject.GetComponent<EneMisa>();
    //    myhako.enabled = false;

    //}

    //// Update is called once per frame
    //void Update()
    //{



    //    Setonp();
    //}
    //public void Setonp()
    //{
    //    float sqrDistance = (transform.position - plyer.position).sqrMagnitude;
    //    print(sqrDistance);
    //    if (sqrDistance < plykyori * plykyori) // plykyoriの二乗を比較します
    //    {
    //        // 敵の出現
    //        myhako.enabled = true;
    //        enemymove.enabled = true;
    //        missile.enabled = true;

    //    }

    //}
}
