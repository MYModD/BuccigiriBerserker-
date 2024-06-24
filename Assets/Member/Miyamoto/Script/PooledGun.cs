using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class PooledGun : MonoBehaviour
{
<<<<<<< HEAD
    [Header("classQÆ")][SerializeField] private Bullet gunPrefab;
    [Header("’eŠÛ‚Ì‘¬‚³")][SerializeField] private float muzzleVelocity = 100f;
    [Header("”­ËˆÊ’u")][SerializeField] private Transform muzzlePosition;
    [Header("ƒN[ƒ‹ƒ^ƒCƒ€")][SerializeField] private float cooldownFire;

    private IObjectPool<Bullet> objectPool;   //bulletƒNƒ‰ƒXŒ^‚Ì‚İˆµ‚¤

    [Header("Å‰‚Ì¶¬”‚É‰‚¶‚Ä")]
    [Header("missle‚Ìtimer‚ğ•Ï‚¦‚é")][SerializeField] private int defaultCapacity = 20;
    [Header("Å‘å”")][SerializeField] private int maxSize = 100;


    private float nextTimeToShoot;//‚Â‚¬‚ÌŠÔŒvZ‚·‚é‚â‚Â

=======
    [Header("ã‚¯ãƒ©ã‚¹å‚ç…§")]
    [SerializeField] private Bullet gunPrefab;
    [Header("å¼¾ã®é€Ÿåº¦")]
    [SerializeField] private float muzzleVelocity = 100f;
    [Header("ç™ºå°„ä½ç½®")]
    [SerializeField] private Transform muzzlePosition;
    [Header("ã‚¯ãƒ¼ãƒ«ãƒ€ã‚¦ãƒ³æ™‚é–“")]
    [SerializeField] private float cooldownFire;
    [Header("æ‹¡æ•£é‡ã®ç¯„å›²")]
    [Range(0, 0.1f)]
    [SerializeField] private float spreadAmount = 0.1f;

    private IObjectPool<Bullet> objectPool; // Bulletã‚¯ãƒ©ã‚¹ã ã‘ã‚’ä¿æŒ

    [Header("åˆæœŸã®å¼¾ã®æ•°ã‚’è¨­å®š")]
    [SerializeField] private int defaultCapacity = 20;
    [Header("æœ€å¤§å®¹é‡")]
    [SerializeField] private int maxSize = 100;

    private float nextTimeToShoot; // æ¬¡ã®ç™ºå°„æ™‚é–“ã‚’è¨ˆç®—ã™ã‚‹ãŸã‚ã®å¤‰æ•°
>>>>>>> origin/Marged4.4.4.4

    void Awake()
    {
        objectPool = new ObjectPool<Bullet>(

            CreateProjectile,
            OnGetFromPool,
            OnReleaseToPool,
            OnDestroyPooledObject,
            true, defaultCapacity, maxSize
            );
        //¶¬‰Šú‰» ƒRƒ“ƒXƒgƒ‰ƒNƒ^

<<<<<<< HEAD

        //Å‰‚É‘å—Ê‚É¶¬‚µ‚Äg‚¢‰ñ‚·
=======
        // åˆæœŸã«å¼¾ã‚’ç”Ÿæˆã—ã¦ãƒ—ãƒ¼ãƒ«ã«å…¥ã‚Œã‚‹
>>>>>>> origin/Marged4.4.4.4
        for (int i = 0; i < defaultCapacity; i++)
        {
            Bullet projectile = CreateProjectile();
            objectPool.Release(projectile);
        }
    }

<<<<<<< HEAD
    #region ƒIƒuƒWƒFƒNƒgƒv[ƒ‹‚Ìˆ—


    //¶¬‚ğs‚¤ŠÖ”
=======
    #region ã‚ªãƒ–ã‚¸ã‚§ã‚¯ãƒˆãƒ—ãƒ¼ãƒ«ã®é–¢æ•°

    // å¼¾ã‚’ç”Ÿæˆã™ã‚‹é–¢æ•°
>>>>>>> origin/Marged4.4.4.4
    private Bullet CreateProjectile()
    {
        Bullet bulletInstance = Instantiate(gunPrefab);
        bulletInstance.ObjectPool = objectPool;

        //bulletInstance.gameObject.SetActive(false);   ‰º‚Ì•û‚ªˆ—Œy‚¢‚Ì‚ÅƒRƒƒ“ƒg‰»

        bulletInstance.GetComponent<Bullet>().enabled = false;
        bulletInstance.GetComponent<MeshRenderer>().enabled = false;
        bulletInstance.GetComponent<SphereCollider>().enabled = false;
        bulletInstance.GetComponent<Rigidbody>().isKinematic = true;

        return bulletInstance;
    }

<<<<<<< HEAD

    // ƒv[ƒ‹‚©‚ç‘İ‚µo‚·‚Ìˆ—
=======
    // ãƒ—ãƒ¼ãƒ«ã‹ã‚‰å–å¾—ã—ãŸæ™‚ã®å‡¦ç†
>>>>>>> origin/Marged4.4.4.4
    private void OnGetFromPool(Bullet bulletObject)
    {
        //bulletObject.gameObject.SetActive(true); ‰º‚Ì•û‚ªˆ—Œy‚¢‚Ì‚ÅƒRƒƒ“ƒg‰»

        bulletObject.GetComponent<Bullet>().enabled = true;
        bulletObject.GetComponent<MeshRenderer>().enabled = true;
        bulletObject.GetComponent<SphereCollider>().enabled = true;
        bulletObject.GetComponent<Rigidbody>().isKinematic = false;

        

        Debug.Log("Bullet activated: " + bulletObject.gameObject.name);
    }

<<<<<<< HEAD

    //ƒv[ƒ‹‚É•Ô‹p‚·‚é‚Ìˆ—
=======
    // ãƒ—ãƒ¼ãƒ«ã«æˆ»ã™æ™‚ã®å‡¦ç†
>>>>>>> origin/Marged4.4.4.4
    private void OnReleaseToPool(Bullet pooledObject)
    {
        //pooledObject.gameObject.SetActive(false);‰º‚Ì•û‚ªˆ—Œy‚¢‚Ì‚ÅƒRƒƒ“ƒg‰»

        pooledObject.GetComponent<Bullet>().enabled = false;
        pooledObject.GetComponent<MeshRenderer>().enabled = false;
        pooledObject.GetComponent<SphereCollider>().enabled = false;
        pooledObject.GetComponent<Rigidbody>().isKinematic = true;

        //print("•Ô‹p");
    }

<<<<<<< HEAD
    // ƒv[ƒ‹‚Ì‹–—e—Ê‚ğ’´‚¦‚½‚Ìíœˆ—
    private void OnDestroyPooledObject(Bullet pooledObject)
    {
        Destroy(pooledObject);
        Debug.LogError("Å‘å”‚ğ’´‚¦‚½‚Ì‚Åíœ‚·‚é‚æ");
=======
    // ãƒ—ãƒ¼ãƒ«ã®ã‚ªãƒ–ã‚¸ã‚§ã‚¯ãƒˆã‚’ç ´æ£„ã™ã‚‹å‡¦ç†
    private void OnDestroyPooledObject(Bullet pooledObject)
    {
        Destroy(pooledObject);
        Debug.LogError("æœ€å¤§å®¹é‡ã‚’è¶…ãˆãŸãŸã‚ã‚ªãƒ–ã‚¸ã‚§ã‚¯ãƒˆã‚’ç ´æ£„ã—ã¾ã—ãŸ");
>>>>>>> origin/Marged4.4.4.4
    }

    #endregion


    private void FixedUpdate()
    {
        Debug.Log(Random.insideUnitCircle);

<<<<<<< HEAD

<<<<<<< HEAD

        bool testBool = Input.GetKey(KeyCode.G) || Input.GetButtonDown("submit");

        
        
       
=======
        bool testBool = Input.GetKey(KeyCode.G) || Input.GetButtonDown("Submit");
>>>>>>> origin/Marged4.4.4.4

=======
        bool testBool = Input.GetKey(KeyCode.G) || Input.GetButtonDown("Fire2");
>>>>>>> parent of d59c711 (ãªãŠã—)
        if (testBool && Time.time > nextTimeToShoot && objectPool != null)
        {
            //bullertƒNƒ‰ƒX‚ÌƒIƒuƒWƒFƒNƒgH‚ğæ“¾
            Bullet bulletObject = objectPool.Get();
<<<<<<< HEAD
            if (bulletObject == null) return;


            //SetPositionAndRotation‚Ì‚Ù‚¤‚ª‘å—Ê‚É¶¬‚µ‚½‚Æ‚«Œy‚¢‚ç‚µ‚¢Aƒfƒ‚”Å‚±‚ê‚Å‚µ‚½
            bulletObject.transform.SetPositionAndRotation(muzzlePosition.position, muzzlePosition.rotation);

            
            //var hoge = transform.forward * Quaternion
            
            
            //’eŠÛ‚É‘Oi*velocity‚ÌƒxƒNƒgƒ‹H—Í‚ğ‰Á‚¦‚é forceMode‚ğ‚±‚ê‚É‚·‚é‚ÆMassŠÖŒW‚È‚­”ò‚Ô
            bulletObject.GetComponent<Rigidbody>().AddForce(bulletObject.transform.forward * muzzleVelocity, ForceMode.Acceleration);


=======
            if (bulletObject == null)
            {
                Debug.LogError("å¼¾ãŒnullã§ã™");
                return;
            }

            // æ‹¡æ•£é‡
            Vector3 randomSpread = new Vector3(
                Random.Range(-spreadAmount, spreadAmount),
                Random.Range(-spreadAmount, spreadAmount),
                Random.Range(-spreadAmount, spreadAmount)
            );
            Vector3 shootDirection = muzzlePosition.forward + randomSpread;

            // SetPositionAndRotationã§ä½ç½®ã¨å›è»¢ã‚’è¨­å®š
            bulletObject.transform.SetPositionAndRotation(muzzlePosition.position, Quaternion.LookRotation(shootDirection));

            // forceã‚’ä½¿ã£ã¦å¼¾ã‚’ç™ºå°„
            bulletObject.GetComponent<Rigidbody>().AddForce(shootDirection.normalized * muzzleVelocity, ForceMode.Acceleration);
>>>>>>> origin/Marged4.4.4.4

            //”­Ë‚³‚ê‚½‚ç¡‚ÌŠÔ‚ÉƒN[ƒ‹ƒ_ƒEƒ“‚ğ’Ç‰Á‚·‚é Œ«‚¢ƒXƒNƒŠƒvƒg
            nextTimeToShoot = Time.time + cooldownFire;
        }



    }
}

