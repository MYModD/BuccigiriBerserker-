using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyStartScript : MonoBehaviour
{

    public void SceneChange()
    {
        SceneManager.LoadScene("Enemy");//操作説明画面へ移動
        
    }
}
