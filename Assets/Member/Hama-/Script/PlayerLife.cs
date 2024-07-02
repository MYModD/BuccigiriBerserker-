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

        //���G���ԊJ�n
        anim.SetBool("invincible", true);   
        anim.SetBool("Normal", false);      

        yield return new WaitForSeconds(4f);

        
      
        playerLife =playerlifesub ; // �v���C���[�̃��C�t�����Z�b�g����

       
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
        // �����G�t�F�N�g�̃v���n�u���C���X�^���X�����Đ�������
        if (explosionPrefab != null)
        {
            damage = true;
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            //Destroy(explosion, 3.0f); // �����G�t�F�N�g��3�b��ɔj������i�C�ӂ̎��ԁj
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

        //���G���ԊJ�n
        anim.SetBool("invincible", true);
        anim.SetBool("Normal", false);

        yield return new WaitForSeconds(2.5f);

        anim.SetBool("invincible", false);
        anim.SetBool("Normal", true);
    }

}