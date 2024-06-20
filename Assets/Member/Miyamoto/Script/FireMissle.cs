using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Rendering;


public class FireMissle : MonoBehaviour
{
    private IObjectPool<Missile> objectPool;

    [Header("�^�[�Q�b�g�ڕW")]
    public List<Transform> targetObjectList ;

    public LockOnManager lockOnManager;//����������

    [Header("���ˈʒu")]
    [SerializeField] private Transform muzzlePosition;
    [Header("�N�[���^�C��")]
    [SerializeField] private float cooldownFire;

   


    private float nextTimeToShoot; // ���̎��Ԍv�Z������

    // Start is called before the first frame update
    void Start()
    {
        PooledMissile pooledMissile = GetComponent<PooledMissile>();//FireMissle��PooledMissile�������I�u�W�F�N�g�ɂȂ��ƃ_������
        objectPool = pooledMissile.objectPool;

       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        targetObjectList = lockOnManager.targetsInCone;

       


        bool testBool = Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire2");//����������Â炷����̂ł��ƂŒ����܂�

        Debug.Log(testBool);

        if (testBool && Time.time > nextTimeToShoot && objectPool != null)
        {
            foreach (Transform target in lockOnManager.targetsInCone)
            {
                // Missile�N���X�̃I�u�W�F�N�g���擾
                Missile missileObject = objectPool.Get();
                
                if (missileObject == null) Debug.Log("�I�u�W�F�N�g���Ȃ���");


                missileObject.target = target;//�Ƃ肠��������� 

                // SetPositionAndRotation�̂ق�����ʂɐ��������Ƃ��y��
                missileObject.transform.SetPositionAndRotation(muzzlePosition.position, muzzlePosition.rotation);

                Debug.LogWarning($"{missileObject.name}{missileObject.transform.position}");

                // ���˂��ꂽ�獡�̎��ԂɃN�[���_�E����ǉ�����
                nextTimeToShoot = Time.time + cooldownFire;



                lockOnManager.targetsInCone.Clear();
                Debug.LogWarning(lockOnManager.targetsInCone[0]);
            }

        }
    }

    
}
