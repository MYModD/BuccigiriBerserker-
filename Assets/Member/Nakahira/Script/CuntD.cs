using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CuntD : MonoBehaviour
{
   
    public string tagname; // �^�O�����w�肷�邽�߂̕ϐ�
    public TextMeshProUGUI countText; // �J�E���g��\������e�L�X�g�v�f

    
    void Start()
    {
        
        GameObject[] tagObjects = GameObject.FindGameObjectsWithTag(tagname);

        // �Q�[���I�u�W�F�N�g�̑������擾
        int count = tagObjects.Length;

        // ������\������e�L�X�g���X�V����
        countText.text = "/ " + count.ToString();
    }


    // Update is called once per frame
    void Update()
    {
       
    }
}
