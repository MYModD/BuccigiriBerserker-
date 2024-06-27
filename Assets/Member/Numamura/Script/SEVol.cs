using UnityEngine;

public class SEVol : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        // �I�u�W�F�N�g�ɃA�^�b�`����Ă���AudioSource�R���|�[�l���g���擾
        audioSource = GetComponent<AudioSource>();

        // �{�����[����0�ɂ���
        SetVolume(0f);

        // 4�b��Ƀ{�����[����1�ɂ���
        Invoke("RestoreVolume", 4f);
    }

    void SetVolume(float volume)
    {
        if (audioSource != null)
        {
            audioSource.volume = volume;
        }
    }

    void RestoreVolume()
    {
        SetVolume(1f);
    }
}
