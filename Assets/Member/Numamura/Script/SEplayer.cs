using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEplayer : MonoBehaviour
{
    public AudioClip SE;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Explode()
    {
        if (SE != null)
        {
            audioSource.PlayOneShot(SE);
        }
        // �����ɑ��̏�����ǉ�����i�Ⴆ�΁A���̍Đ��A�I�u�W�F�N�g�̔j��Ȃǁj
    }
}