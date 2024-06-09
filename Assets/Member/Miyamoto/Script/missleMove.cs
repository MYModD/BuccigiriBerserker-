using UnityEngine;
using UnityEngine.UIElements;

public class Missile : MonoBehaviour
{
    [Header("�K���̏ꍇ�`�F�b�N")] 
    [SerializeField]private bool hissatsu = true;

    [Header("������₷��")]
    [Range(0f, 1f)]
    [SerializeField] private float lerpT = 0.1f;

    [Header("Gforce�̍ő�l")]
    [SerializeField] private float maxAcceleration = 10f;

    [Header("��s����")]
    [SerializeField] private float timer = 10f;


    public Transform target;
    
    public float speed;
    public float rotationSpeed;



    private new  Rigidbody rigidbody;
    private float timeValue; //���Ԍv�Z
    
    private Vector3 previousVelocity; //�O�̉����x
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (target == null) { Debug.LogError("�A�^�b�`����ĂȂ���"); return; }

        timeValue = Mathf.Max(0, timeValue - Time.fixedDeltaTime);

        if(timeValue == 0) PoolReurn();

        CalculationFlying();





    }
    


    private void CalculationFlying()
    {

        // �O�i����
        rigidbody.velocity = transform.forward * speed;

        Vector3 currentVelocity = rigidbody.velocity;
        //(���̉����x - �O�̉����x)/ ����
        Vector3 acceleration = (currentVelocity - previousVelocity) / Time.fixedDeltaTime;
        previousVelocity = currentVelocity;


        //�����x�̑傫����1G=9.81 m/s2�Ŋ���
        float gForce = acceleration.magnitude / 9.81f;
        print(gForce);

        //Gforce��10�����Ă��� ����hissatsu��false�̂Ƃ� return 
        if (gForce > 10f && !hissatsu) return;

        var diff = target.position - transform.position;

        var targetRotation = Quaternion.LookRotation(diff);



        // ���ʐ��`��Ԃ��g���ĉ�]�����X�Ƀ^�[�Q�b�g�Ɍ�����
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, lerpT);


    }



    private void PoolReurn()
    {



    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            print("�G�ƏՓ�");
            Destroy(this.gameObject);
        }
    }


    private void OnEnable()
    {
        timeValue = timer;
    }
}
