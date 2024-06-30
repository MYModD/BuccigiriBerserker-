using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


  

public class SceneLoader : MonoBehaviour
{
    private AsyncOperation sceneLoadOperation;
    private bool sceneLoaded = false;

    void Start()
    {
        // �ʂ̃V�[����񓯊��Ń��[�h����
        sceneLoadOperation = SceneManager.LoadSceneAsync("Enemy");
        sceneLoadOperation.allowSceneActivation = false; // �V�[���̃A�N�e�B�x�[�V������ҋ@��Ԃɂ���
        sceneLoadOperation.completed += OnSceneLoadComplete; // �V�[���̃��[�h�������̃R�[���o�b�N��ݒ�
    }
    void Update()
    {
        Debug.Log("Loading progress: " + sceneLoadOperation.progress);
    }

    private void OnSceneLoadComplete(AsyncOperation asyncOperation)
    {
        sceneLoaded = true;
         Debug.Log("Scene loaded successfully.");
    }

    public void LoadNextScene()
    {
        if (sceneLoaded)
        {
            // ���[�h�����V�[���ɑJ�ڂ���
            sceneLoadOperation.allowSceneActivation = true;
        }
        else
        {
            Debug.LogWarning("Scene is not yet loaded. Wait for the scene to load before attempting to transition.");
            // �����œK�؂ȃG���[�����⃁�b�Z�[�W��\�����邱�Ƃ��ł��܂�
        }
    }
}
