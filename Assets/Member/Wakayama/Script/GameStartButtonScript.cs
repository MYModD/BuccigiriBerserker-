using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartButtonScript : MonoBehaviour
{
    private AsyncOperation GameSceneStarter;//�Q�[���V�[���̎擾
    private float SceneStopTime�@= 2f;//�Q�[���V�[������x�~�߂�܂ł̎���
    private float TrueTimeScale = 1f;//TimeScale�̐ݒ�
    public bool isGameReady = default;//�Q�[���V�[���̋N������

    // Start is called before the first frame update
    void Start()
    {
        GameSceneStarter = SceneManager.LoadSceneAsync("Enemy",LoadSceneMode.Additive);//�Q�[���V�[�����o��
        Invoke("GameSceneReadyStop",SceneStopTime);//�w�莞�Ԍo�߂�����Q�[���V�[������x�~�߂�
        
    }

    

    public void GameSceneReadyStop()
    {
        GameSceneStarter.allowSceneActivation = false;//�Q�[���V�[������x�~�߂�
        Time.timeScale = 0f;//�V�[���̃I�u�W�F�N�g�̓������~�߂�
        isGameReady = true;//�Q�[���V�[���ւ̐؂�ւ������������������Ƃ�`����
    }

    public void SceneChange()
    {
        if (isGameReady)//�Q�[���V�[���ւ̐؂�ւ��������������Ă���ꍇ
        {
            GameSceneStarter.allowSceneActivation = true;//�Q�[���V�[�����N������
            SceneManager.UnloadSceneAsync("HowtoPlayScene");//��������V�[������������
            Time.timeScale = TrueTimeScale;//�V�[���̃I�u�W�F�N�g�̓������ĊJ����
            return;
        }
    }
}
