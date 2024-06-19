using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set_On : MonoBehaviour
{
    // ゲームオブジェクトのボックスコライダーとメッシュレンダラー
    public Collider myhako;
    public MeshRenderer mymmes;
    // プレイヤーの位置とプレイヤーとの距離
    public Transform plyer;
    public float plykyori;
    // ターゲットの位置
    //public Transform target;
    // 移動速度
    //public float moveSpeed;

    //public float stop;
    //public float mo;
    //public float st;
    //public Transform target2;
    //public Transform thisobj;
    // Start is called before the first frame update
    void Start()
    {
        // メッシュレンダラーを非表示にする
        mymmes.enabled = false;
        myhako.enabled = false;
        //GameObject[] tekif = GameObject.FindGameObjectsWithTag("teki");
        //foreach (GameObject obj in tekif)
        //{
        //    Collider collider = obj.GetComponent<Collider>();
        //    MeshRenderer meshRenderer = obj.GetComponent<MeshRenderer>();
        //}
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 targetPos = plyer.position;

        Setonp();
    }
    public void Setonp()
    {
        //Transform target3 = teki.transform.Find("tekiko");
        float distance = Vector3.Distance(transform.position, plyer.position);
        if (distance < plykyori)
        {
            //敵のしゅつげん
            myhako.enabled = true;
            mymmes.enabled = true;

            //Vector3 targetPos = target.position;
            //transform.LookAt(targetPos);
            //Vector3 targetPos2 = target2.position;
            //float distancepl = Vector3.Distance(transform.position, target.position);// このオブジェクトとターゲットの距離を計算

            //// ターゲットに向かって移動
            //if (distancepl > stop)
            //{
            //    transform.position = transform.position + transform.forward * moveSpeed * Time.deltaTime;
            //}
            //else if (distancepl < stop)
            //{
            //    // ターゲット2に向かって移動
            //    transform.LookAt(targetPos2);
            //    transform.position = transform.position + transform.forward * moveSpeed * Time.deltaTime;
            //}
        }
    }
}
