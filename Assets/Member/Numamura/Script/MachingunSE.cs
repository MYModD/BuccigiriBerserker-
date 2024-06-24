using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachingunSE : MonoBehaviour

{
    public AudioClip soundEffect;  // ���ʉ���AudioClip��ݒ肷�邽�߂̕ϐ�
    private AudioSource audioSource;
    private bool isPlaying = false;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>(); // AudioSource��ǉ�
        audioSource.clip = soundEffect;
        audioSource.loop = true;  // ���[�v�Đ���L���ɂ���
    }

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if (!isPlaying)
            {
                audioSource.Play();  // ���ʉ����Đ�
                isPlaying = true;
            }

            // �s�b�`�������_���ɕύX
            audioSource.pitch = Random.Range(0.6f, 1.3f);
        }
        else
        {
            if (isPlaying)
            {
                audioSource.Stop();  // ���ʉ����~
                isPlaying = false;
            }
        }
    }
}
