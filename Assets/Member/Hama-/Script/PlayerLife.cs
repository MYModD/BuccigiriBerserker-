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

    public GameObject explosionPrefab; // �����G�t�F�N�g�̃v���n�u
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
            anim.SetBool("invincible", false);  // �p�����[�^�[�����C��
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


        anim.SetBool("invincible", true);   // �p�����[�^�[�����C��
        anim.SetBool("Normal", false);      // �p�����[�^�[�����C��

        yield return new WaitForSeconds(4f);

        
      
        playerLife =playerlifesub ; // �v���C���[�̃��C�t�����Z�b�g����i���ۂ̃Q�[���ɍ��킹�ēK�؂Ȓl�Ɂj

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

    void Explode()
    {
        // �����G�t�F�N�g�̃v���n�u���C���X�^���X�����Đ�������
        if (explosionPrefab != null)
        {
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            //Destroy(explosion, 3.0f); // �����G�t�F�N�g��3�b��ɔj������i�C�ӂ̎��ԁj
        }
        if (ExplodeAudioClip != null)
        {
            audioSource.PlayOneShot(ExplodeAudioClip);
        }
    }

    
}