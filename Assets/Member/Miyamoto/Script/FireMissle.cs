using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Rendering;

public class FireMissle : MonoBehaviour
{
<<<<<<< HEAD
    private IObjectPool<Missile> objectPool;

    [Header("ƒ^[ƒQƒbƒg–Ú•W")]
    public List<Transform> targetObjectList ;

    public LockOnManager lockOnManager;//‚Â‚¬‚±‚±’¼‚·

    public Fire1SE fire1SE;

    [Header("”­ËˆÊ’u")]
    [SerializeField] private Transform muzzlePosition;
    [Header("ƒN[ƒ‹ƒ^ƒCƒ€")]
    [SerializeField] private float cooldownFire;

   


    private float nextTimeToShoot; // Ÿ‚ÌŠÔŒvZ‚·‚é‚â‚Â
=======
    [Header("ã‚¿ãƒ¼ã‚²ãƒƒãƒˆä½ç½®")]
    public List<Transform> targetObjectList;

    [Header("lockOnManagerå‚ç…§")]
    public LockOnManager lockOnManager;

    [Header("ç™ºå°„éŸ³ã‚¯ãƒ©ã‚¹å‚ç…§")]
    public Fire1SE fire1SE;

    [Header("ç™ºå°„ä½ç½®")]
    [SerializeField] private Transform muzzlePosition;
    [Header("ã‚¯ãƒ¼ãƒ«ãƒ€ã‚¦ãƒ³æ™‚é–“")]
    [SerializeField] private float cooldownFire;

    private IObjectPool<Missile> objectPool;

    private float nextTimeToShoot; // æ¬¡ã®ç™ºå°„æ™‚é–“ã‚’è¨ˆç®—ã™ã‚‹ãŸã‚ã®å¤‰æ•°
>>>>>>> origin/Marged4.4.4.4

    // Start is called before the first frame update
    void Start()
    {
<<<<<<< HEAD
        PooledMissile pooledMissile = GetComponent<PooledMissile>();//FireMissle‚ÆPooledMissile‚ª“¯‚¶ƒIƒuƒWƒFƒNƒg‚É‚È‚¢‚Æƒ_ƒ‚¾‚æ
=======
        PooledMissile pooledMissile = GetComponent<PooledMissile>(); // FireMissleã¯PooledMissileã‚’å«ã‚€ã‚ªãƒ–ã‚¸ã‚§ã‚¯ãƒˆã«ã‚¢ã‚¿ãƒƒãƒã•ã‚Œã¦ã„ã‚‹å¿…è¦ãŒã‚ã‚‹
>>>>>>> origin/Marged4.4.4.4
        objectPool = pooledMissile.objectPool;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        targetObjectList = lockOnManager.targetsInCone;

<<<<<<< HEAD
       



        bool testBool = Input.GetKey(KeyCode.Space) || Input.GetButtonDown("Submit");//‚±‚±•ª‚©‚è‚Ã‚ç‚·‚¬‚é‚Ì‚Å‚ ‚Æ‚Å’¼‚µ‚Ü‚·

        //bool testBool = Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire2");//‚±‚±•ª‚©‚è‚Ã‚ç‚·‚¬‚é‚Ì‚Å‚ ‚Æ‚Å’¼‚µ‚Ü‚·

=======
        bool testBool = Input.GetKey(KeyCode.Space) || Input.GetButtonDown("Submit"); // ã‚¹ãƒšãƒ¼ã‚¹ã‚­ãƒ¼ãŒæŠ¼ã•ã‚ŒãŸã‹ã©ã†ã‹ã‚’ãƒã‚§ãƒƒã‚¯
>>>>>>> origin/Marged4.4.4.4

        Debug.Log(testBool);

        if (testBool && Time.time > nextTimeToShoot && objectPool != null)
        {
            foreach (Transform target in lockOnManager.targetsInCone)
            {
<<<<<<< HEAD
                // MissileƒNƒ‰ƒX‚ÌƒIƒuƒWƒFƒNƒg‚ğæ“¾
                Missile missileObject = objectPool.Get();
                
                if (missileObject == null) Debug.Log("ƒIƒuƒWƒFƒNƒg‚ª‚È‚¢‚æ");
=======
                // Missileã‚¯ãƒ©ã‚¹ã®ã‚ªãƒ–ã‚¸ã‚§ã‚¯ãƒˆã‚’å–å¾—
                Missile missileObject = objectPool.Get();
>>>>>>> origin/Marged4.4.4.4

                if (missileObject == null) Debug.Log("ã‚ªãƒ–ã‚¸ã‚§ã‚¯ãƒˆãŒå–å¾—ã§ãã¾ã›ã‚“ã§ã—ãŸ");

<<<<<<< HEAD
                missileObject.target = target;//‚Æ‚è‚ ‚¦‚¸ˆê‚Â‚©‚ç 

                // SetPositionAndRotation‚Ì‚Ù‚¤‚ª‘å—Ê‚É¶¬‚µ‚½‚Æ‚«Œy‚¢
=======
                missileObject.target = target; // å–å¾—ã—ãŸãƒŸã‚µã‚¤ãƒ«ã®ã‚¿ãƒ¼ã‚²ãƒƒãƒˆã‚’è¨­å®š

                // SetPositionAndRotationã§ä½ç½®ã¨å›è»¢ã‚’è¨­å®š
>>>>>>> origin/Marged4.4.4.4
                missileObject.transform.SetPositionAndRotation(muzzlePosition.position, muzzlePosition.rotation);

                Debug.LogWarning($"{missileObject.name}{missileObject.transform.position}");

<<<<<<< HEAD
                // ”­Ë‚³‚ê‚½‚ç¡‚ÌŠÔ‚ÉƒN[ƒ‹ƒ_ƒEƒ“‚ğ’Ç‰Á‚·‚é
=======
                // æ¬¡ã«ç™ºå°„ã§ãã‚‹æ™‚é–“ã‚’è¨ˆç®—
>>>>>>> origin/Marged4.4.4.4
                nextTimeToShoot = Time.time + cooldownFire;

                fire1SE.fire1SE(); // ç™ºå°„éŸ³ã‚’å†ç”Ÿ

                lockOnManager.targetsInCone.Clear();
                Debug.LogWarning(lockOnManager.targetsInCone[0]);
            }
        }
    }
}
