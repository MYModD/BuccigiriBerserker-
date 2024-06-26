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
            anim.SetBool("invincible", false);  // �p�����[�^�[�����C��
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


        anim.SetBool("invincible", true);   // �p�����[�^�[�����C��
        anim.SetBool("Normal", false);      // �p�����[�^�[�����C��

        yield return new WaitForSeconds(4f);

        
      
        playerLife = 5; // �v���C���[�̃��C�t�����Z�b�g����i���ۂ̃Q�[���ɍ��킹�ēK�؂Ȓl�Ɂj

        // �A�j���[�V�����̃��Z�b�g�Ȃǂ������ōs��
        anim.SetBool("invincible", false);  // �p�����[�^�[�����C��
        anim.SetBool("Normal", true);       // �p�����[�^�[�����C��
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
