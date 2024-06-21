using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalSE : MonoBehaviour
{
    public AudioClip SE;
    AudioSource audioSource;
    private bool playedSE = false;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Debug.Log(horizontal);

        if (horizontal != 0 && !playedSE)
        {
            horiSE();
            playedSE = true;
        }

        if(horizontal == 0)
        {
            playedSE = false;
        }
    }

    public void horiSE()
    {
        if (SE != null)
        {
            audioSource.PlayOneShot(SE);
        }
        // ここに他の処理を追加する（例えば、音の再生、オブジェクトの破壊など）
    }
}
