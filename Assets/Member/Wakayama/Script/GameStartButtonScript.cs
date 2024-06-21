using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartButtonScript : MonoBehaviour
{
    AsyncOperation GameSceneStarter;//�Q�[���V�[���̎擾

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
