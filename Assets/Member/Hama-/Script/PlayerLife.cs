using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField]
    float playerLife = 5;
    [SerializeField]
    float spawnSpeed = 50.0f;

    public bool _IsRetry = false;

    private MoveMiyamotoTest move;

    private Animator anim;
    private Vector3 originalPosition;

    void Start()
    {
        anim = GetComponent<Animator>();
        move = GetComponent<MoveMiyamotoTest>();
        originalPosition = transform.position;
    }

    void Update()
    {
        if (playerLife == 0)
        {
            _IsRetry = true;
            // originalPosition = transform.position;  // ���̍s�͕s�v�ł��iStart()�Ŋ��ɐݒ�ς݁j
            StartCoroutine(Respawn());
        }

        if (playerLife > 0)
        {
            anim.SetBool("invincible", false);  // �p�����[�^�[�����C��
            anim.SetBool("Normal", true);       // �p�����[�^�[�����C��
            _IsRetry = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerLife--;
        }
    }

    IEnumerator Respawn()
    {
        move.enabled = false;
        // �v���C���[�����ɓ��������i��Ƃ���spawnSpeed * 5�b����ށj
        float moveDistance = spawnSpeed * 5 * Time.deltaTime;

        // ��ފJ�n
        while (transform.position.z > originalPosition.z - moveDistance)
        {
            transform.Translate(Vector3.forward * spawnSpeed * Time.deltaTime);  // ���ɓ��������߂�back���g�p
            yield return null;
        }

        anim.SetBool("invincible", true);   // �p�����[�^�[�����C��
        anim.SetBool("Normal", false);      // �p�����[�^�[�����C��

        yield return new WaitForSeconds(3f);

        // ��ތ�̃A�j���[�V�����̌�ɕK�v�ȏ������L�q����
        // �Ⴆ�΁A�ʒu�̃��Z�b�g�⑼�̏������s��
        transform.position = originalPosition; // �ʒu�����ɖ߂��i���ۂ̃Q�[���ɍ��킹�ēK�؂Ȉʒu�Ɂj
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
