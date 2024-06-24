using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Rendering;

public class FireMissle : MonoBehaviour
{
<<<<<<< HEAD
    private IObjectPool<Missile> objectPool;

    [Header("�^�[�Q�b�g�ڕW")]
    public List<Transform> targetObjectList ;

    public LockOnManager lockOnManager;//����������

    public Fire1SE fire1SE;

    [Header("���ˈʒu")]
    [SerializeField] private Transform muzzlePosition;
    [Header("�N�[���^�C��")]
    [SerializeField] private float cooldownFire;

   


    private float nextTimeToShoot; // ���̎��Ԍv�Z������
=======
    [Header("ターゲット位置")]
    public List<Transform> targetObjectList;

    [Header("lockOnManager参照")]
    public LockOnManager lockOnManager;

    [Header("発射音クラス参照")]
    public Fire1SE fire1SE;

    [Header("発射位置")]
    [SerializeField] private Transform muzzlePosition;
    [Header("クールダウン時間")]
    [SerializeField] private float cooldownFire;

    private IObjectPool<Missile> objectPool;

    private float nextTimeToShoot; // 次の発射時間を計算するための変数
>>>>>>> origin/Marged4.4.4.4

    // Start is called before the first frame update
    void Start()
    {
<<<<<<< HEAD
        PooledMissile pooledMissile = GetComponent<PooledMissile>();//FireMissle��PooledMissile�������I�u�W�F�N�g�ɂȂ��ƃ_������
=======
        PooledMissile pooledMissile = GetComponent<PooledMissile>(); // FireMissleはPooledMissileを含むオブジェクトにアタッチされている必要がある
>>>>>>> origin/Marged4.4.4.4
        objectPool = pooledMissile.objectPool;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        targetObjectList = lockOnManager.targetsInCone;

<<<<<<< HEAD
       



        bool testBool = Input.GetKey(KeyCode.Space) || Input.GetButtonDown("Submit");//����������Â炷����̂ł��ƂŒ����܂�

        //bool testBool = Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire2");//����������Â炷����̂ł��ƂŒ����܂�

=======
        bool testBool = Input.GetKey(KeyCode.Space) || Input.GetButtonDown("Submit"); // スペースキーが押されたかどうかをチェック
>>>>>>> origin/Marged4.4.4.4

        Debug.Log(testBool);

        if (testBool && Time.time > nextTimeToShoot && objectPool != null)
        {
            foreach (Transform target in lockOnManager.targetsInCone)
            {
<<<<<<< HEAD
                // Missile�N���X�̃I�u�W�F�N�g���擾
                Missile missileObject = objectPool.Get();
                
                if (missileObject == null) Debug.Log("�I�u�W�F�N�g���Ȃ���");
=======
                // Missileクラスのオブジェクトを取得
                Missile missileObject = objectPool.Get();
>>>>>>> origin/Marged4.4.4.4

                if (missileObject == null) Debug.Log("オブジェクトが取得できませんでした");

<<<<<<< HEAD
                missileObject.target = target;//�Ƃ肠��������� 

                // SetPositionAndRotation�̂ق�����ʂɐ��������Ƃ��y��
=======
                missileObject.target = target; // 取得したミサイルのターゲットを設定

                // SetPositionAndRotationで位置と回転を設定
>>>>>>> origin/Marged4.4.4.4
                missileObject.transform.SetPositionAndRotation(muzzlePosition.position, muzzlePosition.rotation);

                Debug.LogWarning($"{missileObject.name}{missileObject.transform.position}");

<<<<<<< HEAD
                // ���˂��ꂽ�獡�̎��ԂɃN�[���_�E����ǉ�����
=======
                // 次に発射できる時間を計算
>>>>>>> origin/Marged4.4.4.4
                nextTimeToShoot = Time.time + cooldownFire;

                fire1SE.fire1SE(); // 発射音を再生

                lockOnManager.targetsInCone.Clear();
                Debug.LogWarning(lockOnManager.targetsInCone[0]);
            }
        }
    }
}
