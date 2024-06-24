using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEVol2 : MonoBehaviour
{
    public AudioSource audioSource;
    private float initialVolume;
    private float targetVolume = 1.0f;
    private float fadeDuration = 4.0f;
    // Start is called before the first frame update
    void Start()
    {
        if(audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
        if(audioSource != null)
        {
            initialVolume = audioSource.volume;
            audioSource.volume = 0.0f;
            Invoke("FadeInVolume", fadeDuration);
        }
        else
        {

        }
    }

    void FadeInVolume()
    {
        audioSource.volume = targetVolume;

    }
}
