using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UIElements;

public class Missile : MonoBehaviour
{
    
    [Header("�ڕW�^�[�Q�b�g")]
    public Transform target;                //���Ƃ�set = value get private�ɕς��邩��

    [Header("�K���̏ꍇ�`�F�b�N")]
    [SerializeField] private bool hissatsu = true;

    [Header("������₷�� 0.1�f�t�H")]
    [Range(0f, 1f)]
    [SerializeField] private float lerpT = 0.1f;

    [Header("�X�s�[�h")]
    [SerializeField] private float speed;

    [Header("��s����")]
    [SerializeField] private float timer = 10f;

    [Header("Gforce�̍ő�l")]
    [SerializeField] private float maxAcceleration = 10f;

    private IObjectPool<Missile> objectPool;
    public IObjectPool<Missile> ObjectPool { set => objectPool = value; }  //�O������l��ς����ꍇ�A���objectpool�ɑ�������




    private new  Rigidbody rigidbody;
    private float timeValue; //���Ԍv�Z�p
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
        //print(gForce);

        //Gforce��maxAcceleration�����Ă��� ����hissatsu��false�̂Ƃ� return 
        if (gForce > maxAcceleration && !hissatsu) return;

        var diff = target.position - transform.position;

        var targetRotation = Quaternion.LookRotation(diff);



        // ���ʐ��`��Ԃ��g���ĉ�]�����X�Ƀ^�[�Q�b�g�Ɍ�����
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, lerpT);


    }



    private void PoolReurn()
    {

        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;  //�I�u�W�F�N�g��false�ɂ��钼�O�܂ł����ɕt����������
        transform.rotation = new Quaternion(0, 0, 0, 0);
        objectPool.Release(this);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            print("�G�ƏՓ�");
            PoolReurn();
        }
    }


    private void OnEnable()
    {
        timeValue = timer;
    }
}