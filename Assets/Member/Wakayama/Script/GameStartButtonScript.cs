using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartButtonScript : MonoBehaviour
{
    AsyncOperation GameSceneStarter;//ÉQÅ[ÉÄÉVÅ[ÉìÇÃéÊìæ

    // Start is called before the first frame update
    void Start()
    {
        GameSceneStarter = SceneManager.LoadSceneAsync("Enemy");

        GameSceneStarter.allowSceneActivation = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SceneChange()
    {
        GameSceneStarter.allowSceneActivation = true;
        SceneManager.UnloadSceneAsync("HowtoPlayScene");
        return;
    }
}
