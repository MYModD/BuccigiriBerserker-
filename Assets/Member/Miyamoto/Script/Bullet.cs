using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    [Header("�d��,�����₷��")][SerializeField] private float gravity;
    
    [Header("���ł���܂ł̎���")][SerializeField] private float timer = 5f;



    new Rigidbody rigidbody;
    private IObjectPool<Bullet> objectPool;
    private float timeValue;


    public IObjectPool<Bullet> ObjectPool { set => objectPool = value; }  //�O������l��ς����ꍇ�A���objectpool�ɑ�������


    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.useGravity = false;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        rigidbody.AddForce(new Vector3(0, -gravity, 0),ForceMode.Acceleration);//�e�ۂ݂̂̏d�͎���

        timeValue =  Mathf.Max(0, timeValue - Time.fixedDeltaTime);    //�����^�C�}�[�X�N���v�g

        if(timeValue == 0)
        {
            PoolReurn();
        }



    }

    private void PoolReurn()  //�e�������Z�b�g���ăI�u�W�F�N�g�v�[���ɖ߂�����
    {
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;  //�I�u�W�F�N�g��false�ɂ��钼�O�܂ł����ɕt����������
        
        objectPool.Release(this);

    }
    private void OnEnable()
    {
        timeValue = timer;//ON�ɂȂ����玞�ԃ��Z�b�g
        print("����");
    }





    private void OnCollisionEnter(Collision collision)
    {

        PoolReurn();//�Ԃ�������v�[���ɕԂ� tag�������̂ŒǋL����

    }
}
