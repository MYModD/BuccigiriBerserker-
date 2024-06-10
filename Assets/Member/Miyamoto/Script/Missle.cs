using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UIElements;

public class Missile : MonoBehaviour
{
    
    [Header("目標ターゲット")]
    public Transform target;                //あとでset = value get privateに変えるかも

    [Header("必中の場合チェック")]
    [SerializeField] private bool hissatsu = true;

    [Header("あたりやすさ 0.1デフォ")]
    [Range(0f, 1f)]
    [SerializeField] private float lerpT = 0.1f;

    [Header("スピード")]
    [SerializeField] private float speed;

    [Header("飛行時間")]
    [SerializeField] private float timer = 10f;

    [Header("Gforceの最大値")]
    [SerializeField] private float maxAcceleration = 10f;

    private IObjectPool<Missile> objectPool;
    public IObjectPool<Missile> ObjectPool { set => objectPool = value; }  //外部から値を変えた場合、上のobjectpoolに代入される




    private new  Rigidbody rigidbody;
    private float timeValue; //時間計算用
    private Vector3 previousVelocity; //前の加速度
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (target == null) { Debug.LogError("アタッチされてないよ"); return; }

        timeValue = Mathf.Max(0, timeValue - Time.fixedDeltaTime);

        if(timeValue == 0) PoolReurn();//時間切れになったら返す


        CalculationFlying();





    }
    


    private void CalculationFlying()
    {

        // 前進する
        rigidbody.velocity = transform.forward * speed;

        Vector3 currentVelocity = rigidbody.velocity;
        //(今の加速度 - 前の加速度)/ 時間
        Vector3 acceleration = (currentVelocity - previousVelocity) / Time.fixedDeltaTime;
        previousVelocity = currentVelocity;


        //加速度の大きさを1G=9.81 m/s2で割る
        float gForce = acceleration.magnitude / 9.81f;
        //print(gForce);

        //GforceがmaxAcceleration超えている かつhissatsuがfalseのとき return 処理なくす
        if (gForce > maxAcceleration && !hissatsu) return;

        var diff = target.position - transform.position;

        var targetRotation = Quaternion.LookRotation(diff);



        // 球面線形補間を使って回転を徐々にターゲットに向ける
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, lerpT);


    }



    private void PoolReurn()
    {

        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;  //オブジェクトをfalseにする直前までここに付け足すかも
        transform.rotation = new Quaternion(0, 0, 0, 0);
        objectPool.Release(this);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            print("敵と衝突");
            PoolReurn();
        }
    }


    private void OnEnable()
    {
        timeValue = timer;
    }
}
