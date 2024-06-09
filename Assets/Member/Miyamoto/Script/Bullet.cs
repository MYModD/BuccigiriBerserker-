using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    [Header("重力,落ちやすさ")][SerializeField] private float gravity;
    
    [Header("消滅するまでの時間")][SerializeField] private float timer = 5f;



    new Rigidbody rigidbody;
    private IObjectPool<Bullet> objectPool;
    private float timeValue;


    public IObjectPool<Bullet> ObjectPool { set => objectPool = value; }  //外部から値を変えた場合、上のobjectpoolに代入される


    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.useGravity = false;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        rigidbody.AddForce(new Vector3(0, -gravity, 0),ForceMode.Acceleration);//弾丸のみの重力実装

        timeValue =  Mathf.Max(0, timeValue - Time.fixedDeltaTime);    //賢いタイマースクリプト

        if(timeValue == 0)
        {
            PoolReurn();
        }



    }

    private void PoolReurn()  //各情報をリセットしてオブジェクトプールに戻す処理
    {
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;  //オブジェクトをfalseにする直前までここに付け足すかも
        
        objectPool.Release(this);

    }
    private void OnEnable()
    {
        timeValue = timer;//ONになったら時間リセット
        print("生成");
    }





    private void OnCollisionEnter(Collision collision)
    {

        PoolReurn();//ぶつかったらプールに返す tagつけたいので追記する

    }
}
