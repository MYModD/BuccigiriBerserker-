using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboCount : MonoBehaviour
{
   
    public Text ComboCountText; // UI�e�L�X�g�I�u�W�F�N�g
    public int ComboValue;
    private bool _ComboCheck = default;

    public bool _toScore = default;
    public LifebarManager lifebarmanager;
    void Start()
    {

        ComboValue = 0;
        ComboCountText = GetComponent<Text>();
        _toScore = false;
        UpdateUI(); // UI���X�V���ď����ݒ莞�Ԃ�\��
    }

    void Update()
    {
        _ComboCheck = lifebarmanager._ComboReset;

        if(Input.GetKeyDown(KeyCode.Y))
        {
            ComboValue++;
            _toScore = true;
        }

        if(_ComboCheck == true)
        {
            ComboValue = 0;
            lifebarmanager._ComboReset = false;
        }

        // UI���X�V����
        UpdateUI();
    }

    void UpdateUI()
    {
        // UI�e�L�X�g�Ɏc�莞�Ԃ�\������
        if (ComboCountText != null)
        {
            
                ComboCountText.text = ComboValue.ToString() + "COMBO";
            
            
        }
    }
}

