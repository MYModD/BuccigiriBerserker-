using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerCheckScript : MonoBehaviour
{
    private float GetHorizontal = Input.GetAxisRaw("Horizontal");//���E�ړ��̎擾
    private float GetVertical = Input.GetAxisRaw("Vertical");//�㉺�ړ��̎擾
    bool GetTrriger = Input.GetButton("Submit");//�g���K�[�i�@�e�A�r�[���j�擾
    bool GetLeftButton = Input.GetButton("Left_Roll");//����]�{�^���̎擾
    bool GetDownButton = Input.GetButton("Fire1");//�~�T�C���{�^���̎擾
    bool GetRightButton = Input.GetButton("Right_Roll");//�E��]�{�^���̎擾

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
