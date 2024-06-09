using UnityEngine;
using UnityEngine.UIElements;

public class Missile : MonoBehaviour
{
    [Header("必中の場合チェック")] 
    [SerializeField]private bool hissatsu = true;

    [Header("あたりやすさ")]
    [Range(0f, 1f)]
    [SerializeField] private float lerpT = 0.1f;

    [Header("Gforceの最大値")]
    [SerializeField] private float maxAcceleration = 10f;

    [Header("飛行時間")]
    [SerializeField] private float timer = 10f;


    public Transform target;
    
    public float speed;
    public float rotationSpeed;



    private new  Rigidbody rigidbody;
    private float timeValue; //時間計算
    
    private Vector3 previousVelocity; //前の加速度
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (target == null) { Debug.LogError("アタッチされてないよ"); return; }

        timeValue = Mathf.Max(0, timeValue - Time.fixedDeltaTime);

        if(timeValue == 0) PoolReurn();

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
        print(gForce);

        //Gforceが10超えている かつhissatsuがfalseのとき return 
        if (gForce > 10f && !hissatsu) return;

        var diff = target.position - transform.position;

        var targetRotation = Quaternion.LookRotation(diff);



        // 球面線形補間を使って回転を徐々にターゲットに向ける
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, lerpT);


    }



    private void PoolReurn()
    {



    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            print("敵と衝突");
            Destroy(this.gameObject);
        }
    }


    private void OnEnable()
    {
        timeValue = timer;
    }
}
