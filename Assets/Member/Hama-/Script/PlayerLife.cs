using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField]
    float playerLife = 5;
   

    public bool _IsRetry = false;

    private MoveMiyamotoTest move;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        move = GetComponent<MoveMiyamotoTest>();
       
        anim.SetBool("invincible", false); 
        anim.SetBool("Normal", false);
    }

    void Update()
    {
        if (playerLife == 0)
        {
            anim.SetBool("invincible", false);  // パラメーター名を修正
            anim.SetBool("Normal", true);
            _IsRetry = false;
            StartCoroutine(Respawn());
        }

        if (playerLife > 0)
        {
          
            _IsRetry = true;
          
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

        
      
        playerLife = 5; // プレイヤーのライフをリセットする（実際のゲームに合わせて適切な値に）

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
}
