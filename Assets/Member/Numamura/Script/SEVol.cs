using UnityEngine;

public class SEVol : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        // オブジェクトにアタッチされているAudioSourceコンポーネントを取得
        audioSource = GetComponent<AudioSource>();

        // ボリュームを0にする
        SetVolume(0f);

        // 4秒後にボリュームを1にする
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
