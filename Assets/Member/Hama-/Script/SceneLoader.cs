using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


  

public class SceneLoader : MonoBehaviour
{
  

    public void OnLoadSceneButtonClick()
    {
            // ���̃V�[���֑J�ڂ���
            SceneManager.LoadScene("Enemy", LoadSceneMode.Single);
      
    }
}
