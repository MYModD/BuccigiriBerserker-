using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowtoPlayStartScript : MonoBehaviour
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

    public void SceneChange()
    {
        if (SE != null)
        {
            audioSource.PlayOneShot(SE);
        }
        SceneManager.LoadScene("HowToPlayScene");//ëÄçÏê‡ñæâÊñ Ç÷à⁄ìÆ
        return;
    }
}
