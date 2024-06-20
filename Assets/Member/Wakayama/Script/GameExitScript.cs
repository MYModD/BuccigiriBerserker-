using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameExitScript : MonoBehaviour

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

    public void GameEnd()
    {
        if (SE != null)
        {
            audioSource.PlayOneShot(SE);
        }
        Application.Quit();//ビルドされたゲームプレイを終了
    }
}
