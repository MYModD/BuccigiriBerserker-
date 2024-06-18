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

        if (UnityEditor.EditorApplication.isPlaying)//エディターで起動しているか
        {
            UnityEditor.EditorApplication.isPlaying = false;//エディターのテストプレイを終了
        }
        else
        {
            Application.Quit();//ビルドされたゲームプレイを終了
        }
    }
}
