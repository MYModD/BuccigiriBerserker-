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

    private bool buttonEnabled = false; // �{�^�����������Ԃ��ǂ����̃t���O

    void Start()
    {
        hpcanvas.enabled = false;
        player = GameObject.FindWithTag("Player"); // Player�I�u�W�F�N�g�̎擾
        warp = GameObject.FindWithTag("Warp"); // Warp�I�u�W�F�N�g�̎擾
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
                player.transform.position = warp.transform.position; // �v���C���[�̈ʒu�����[�v�ʒu�Ɉړ�
            }
            else
            {
                Debug.LogWarning("Player�܂���Warp��������܂���B");
            }

            if (controll != null)
            {
                Destroy(controll.gameObject); // �R���g���[��Canvas��j��
            }
            else
            {
                Debug.LogWarning("Controll Canvas��������܂���B");
            }

           
        

    }

}
