using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CanvasExit : MonoBehaviour
{
    public Canvas hpcanvas;
    public Canvas controll;
    private GameObject player;
    private GameObject warp;
    private float time;

    private bool buttonEnabled = false; // ボタンが押せる状態かどうかのフラグ

    void Start()
    {
        hpcanvas.enabled = false;
        player = GameObject.FindWithTag("Player"); // Playerオブジェクトの取得
        warp = GameObject.FindWithTag("Warp"); // Warpオブジェクトの取得
        time = 0;
    


    }

    public void Update()
    {
        time += Time.deltaTime;

        if (time >= 5)
        {
            DisableCanvasOnClick();
        }


    }

    public void DisableCanvasOnClick()
    {
     
        
            hpcanvas.enabled = true;

            if (player != null && warp != null)
            {
                player.transform.position = warp.transform.position; // プレイヤーの位置をワープ位置に移動
            }
            else
            {
                Debug.LogWarning("PlayerまたはWarpが見つかりません。");
            }

            if (controll != null)
            {
                Destroy(controll.gameObject); // コントロールCanvasを破棄
            }
            else
            {
                Debug.LogWarning("Controll Canvasが見つかりません。");
            }

           
        

    }

}
