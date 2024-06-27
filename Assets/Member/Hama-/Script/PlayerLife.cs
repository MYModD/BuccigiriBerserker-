using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField]
   public float playerLife = 5;

    private float playerlifesub;

    public bool _IsRetry = false;

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
            anim.SetBool("invincible", false);  // パラメーター名を修正
            anim.SetBool("Normal", true);
            _IsRetry = false;
            Explode();
            explod = true;
            StartCoroutine(Respawn());
        }

        if (playerLife > 0)
        {
          
            _IsRetry = true;
            explod = false;
          
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerLife--;
        }
    }

    IEnumerator Respawn()
    {
        move.enabled = false;


        anim.SetBool("invincible", true);   // パラメーター名を修正
        anim.SetBool("Normal", false);      // パラメーター名を修正

        yield return new WaitForSeconds(4f);

        
      
        playerLife =playerlifesub ; // プレイヤーのライフをリセットする（実際のゲームに合わせて適切な値に）

        // アニメーションのリセットなどもここで行う
        anim.SetBool("invincible", false);  // パラメーター名を修正
        anim.SetBool("Normal", true);       // パラメーター名を修正
        move.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            playerLife--;
        }
    }

    void Explode()
    {
        // 爆発エフェクトのプレハブをインスタンス化して生成する
        if (explosionPrefab != null)
        {
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            //Destroy(explosion, 3.0f); // 爆発エフェクトを3秒後に破棄する（任意の時間）
        }
        if (ExplodeAudioClip != null)
        {
            audioSource.PlayOneShot(ExplodeAudioClip);
        }
    }

    
}