using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


  

public class SceneLoader : MonoBehaviour
{
  

    public void OnLoadSceneButtonClick()
    {
            // 次のシーンへ遷移する
            SceneManager.LoadScene("Enemy", LoadSceneMode.Single);
      
    }
}
