using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameExitScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameEnd()
    {

        if (UnityEditor.EditorApplication.isPlaying)//�G�f�B�^�[�ŋN�����Ă��邩
        {
            UnityEditor.EditorApplication.isPlaying = false;//�G�f�B�^�[�̃e�X�g�v���C���I��
        }
        else
        {
            Application.Quit();//�r���h���ꂽ�Q�[���v���C���I��
        }
    }
}
