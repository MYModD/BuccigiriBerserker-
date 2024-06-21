using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartButtonScript : MonoBehaviour
{
    private AsyncOperation GameSceneStarter;//�Q�[���V�[���̎擾
    [SerializeField]private float SceneStopTime�@= default;//�Q�[���V�[������x�~�߂�܂ł̎���

    // Start is called before the first frame update
    void Start()
    {
        GameSceneStarter = SceneManager.LoadSceneAsync("Enemy");//�Q�[���V�[�����o��
        Invoke("GameSceneReadyStop",SceneStopTime);//�w�莞�Ԍo�߂�����Q�[���V�[������x�~�߂�
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameSceneReadyStop()
    {
        GameSceneStarter.allowSceneActivation = false;//�Q�[���V�[������x�~�߂�
    }

    public void SceneChange()
    {
        GameSceneStarter.allowSceneActivation = true;//�Q�[���V�[�����N������
        SceneManager.UnloadSceneAsync("HowtoPlayScene");//��������V�[������������
        return;
    }
}
