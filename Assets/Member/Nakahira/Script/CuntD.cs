using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CuntD : MonoBehaviour
{
   
    //[SerializeField] private string tagname; // �^�O�����w�肷�邽�߂̕ϐ�
    [SerializeField] private TextMeshProUGUI currentCount; // �J�E���g��\������e�L�X�g�v�f
    [SerializeField] public int Initial_Value;
    
    void Start()
    {
        
        //GameObject[] tagObjects = GameObject.FindGameObjectsWithTag(tagname);

        // �Q�[���I�u�W�F�N�g�̑������擾
        int count =Initial_Value;

        // ������\������e�L�X�g���X�V����
        currentCount.text = "/ " + Initial_Value.ToString();
    }


    // Update is called once per frame
    void Update()
    {
       
    }
}
