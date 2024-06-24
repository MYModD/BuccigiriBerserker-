using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachingunSE : MonoBehaviour

{
    public AudioClip soundEffect;  // 効果音のAudioClipを設定するための変数
    private AudioSource audioSource;
    private bool isPlaying = false;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>(); // AudioSourceを追加
        audioSource.clip = soundEffect;
        audioSource.loop = true;  // ループ再生を有効にする
    }

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if (!isPlaying)
            {
                audioSource.Play();  // 効果音を再生
                isPlaying = true;
            }

            // ピッチをランダムに変更
            audioSource.pitch = Random.Range(0.6f, 1.3f);
        }
        else
        {
            if (isPlaying)
            {
                audioSource.Stop();  // 効果音を停止
                isPlaying = false;
            }
        }
    }
}
