using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UItext : MonoBehaviour
{
    public float missileCou;
    public Text uitext;

    void Start()
    {
        missileCou = 50;
        UpdateUI(); // UI���X�V���ď����ݒ莞�Ԃ�\��
    }

    void Update()
    {
        

        // UI���X�V����
        UpdateUI();
    }

    void UpdateUI()
    {
        // UI�e�L�X�g�Ɏc�莞�Ԃ�\������
        if (uitext != null)
        {
            
                uitext.text = "�~" + missileCou;
            
            
        }
    }
}


