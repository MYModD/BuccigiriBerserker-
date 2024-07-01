using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


  

public class SceneLoader : MonoBehaviour
{
  

    public void OnLoadSceneButtonClick()
    {
            // Ÿ‚ÌƒV[ƒ“‚Ö‘JˆÚ‚·‚é
            SceneManager.LoadScene("Enemy", LoadSceneMode.Single);
      
    }
}
