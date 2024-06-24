using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set_On : MonoBehaviour
{
    // ゲームオブジェクトのボックスコライダーとメッシュレンダラー
    public Collider myhako;
    private NewEnemyMove enemymove;
    private EneMisa missile;
    //public MeshRenderer mymmes;
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
        //mymmes.enabled = false;
        enemymove = gameObject.GetComponent<NewEnemyMove>();
        missile = gameObject.GetComponent<EneMisa>();
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

        //Vector3 targetPos = plyer.position;

        Setonp();
    }
    public void Setonp()
    {
        float sqrDistance = (transform.position - plyer.position).sqrMagnitude;
        print(sqrDistance);
        if (sqrDistance < plykyori * plykyori) // plykyoriの二乗を比較します
        {
            // 敵の出現
            myhako.enabled = true;
            enemymove.enabled = true;
            missile.enabled = true;
            //mymmes.enabled = true;
        }
        //Transform target3 = teki.transform.Find("tekiko");
        //float distance = Vector3.Distance(transform.position, plyer.position);
        //print(distance);
        //if (distance < plykyori)
        //{
        //    //敵のしゅつげん
        //    myhako.enabled = true;
        //    enemymove.enabled = true;
        //    //mymmes.enabled = true;


        //}
    }
}
