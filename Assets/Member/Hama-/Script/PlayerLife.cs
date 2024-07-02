using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField]
   public float playerLife = 5;

    private float playerlifesub;

    public bool _IsRetry = false;

    public bool damage;

    private MoveMiyamotoTest move;

    private Animator anim;

    public GameObject explosionPrefab; // 爆発エフェクトのプレハブ
    public AudioClip ExplodeAudioClip;
    public AudioSource audioSource;

    private bool explod = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        move = GetComponent<MoveMiyamotoTest>();
       
        anim.SetBool("invincible", false); 
        anim.SetBool("Normal", false);

        playerlifesub = playerLife;

    }

    void Update()
    {
        if (playerLife == 0 && explod != true)
        {
            anim.SetBool("invincible", false);
            anim.SetBool("Normal", true);
            _IsRetry = false;
            Explode();
            explod = true;
            StartCoroutine(Respawn());
        }

        if (playerLife >=5)
        {
          
            _IsRetry = true;
            explod = false;
          
        }
        

        if (Input.GetKeyDown(KeyCode.H))
        {
            //playerLife--;
            StartCoroutine(TakeDamage());

        }
    }

    IEnumerator Respawn()
    {
        move.enabled = false;

        //無敵時間開始
        anim.SetBool("invincible", true);   
        anim.SetBool("Normal", false);      

        yield return new WaitForSeconds(4f);

        
      
        playerLife =playerlifesub ; // プレイヤーのライフをリセットする

       
        anim.SetBool("invincible", false);  
        anim.SetBool("Normal", true);      
        move.enabled = true;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            //playerLife--;
            TakeDamage();
        }
    }

    void Explode()
    {
        // 爆発エフェクトのプレハブをインスタンス化して生成する
        if (explosionPrefab != null)
        {
            damage = true;
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            //Destroy(explosion, 3.0f); // 爆発エフェクトを3秒後に破棄する（任意の時間）
        }
        if (ExplodeAudioClip != null)
        {
            audioSource.PlayOneShot(ExplodeAudioClip);
        }
       
    }

    IEnumerator TakeDamage()
    {
        playerLife--;
        damage = true;

        //無敵時間開始
        anim.SetBool("invincible", true);
        anim.SetBool("Normal", false);

        yield return new WaitForSeconds(2.5f);

        anim.SetBool("invincible", false);
        anim.SetBool("Normal", true);
    }

}