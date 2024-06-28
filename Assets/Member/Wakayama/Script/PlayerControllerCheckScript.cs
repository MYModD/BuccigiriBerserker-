using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerCheckScript : MonoBehaviour
{
    private float GetHorizontal = Input.GetAxisRaw("Horizontal");//左右移動の取得
    private float GetVertical = Input.GetAxisRaw("Vertical");//上下移動の取得
    bool GetTrriger = Input.GetButton("Submit");//トリガー（機銃、ビーム）取得
    bool GetLeftButton = Input.GetButton("Left_Roll");//左回転ボタンの取得
    bool GetDownButton = Input.GetButton("Fire1");//ミサイルボタンの取得
    bool GetRightButton = Input.GetButton("Right_Roll");//右回転ボタンの取得

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetHorizontal != 0)
        {
            Debug.Log("Horizontal:" + GetHorizontal);
        }
        if (GetVertical != 0)
        {
            Debug.Log("Vertical:" + GetVertical);
        }
        if (GetTrriger)
        {
            Debug.Log("Trriger");
        }
        if (GetLeftButton)
        {
            Debug.Log("LeftButton");
        }
        if (GetRightButton)
        {
            Debug.Log("RightButton");
        }
        if (GetDownButton)
        {
            Debug.Log("GetDownButton");
        }
    }
}
