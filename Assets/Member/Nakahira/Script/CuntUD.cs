using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CuntUD : MonoBehaviour
{
    public string tagname; // �^�O�����w�肷�邽�߂̕ϐ�
    public TextMeshProUGUI countTexts; // �J�E���g��\������e�L�X�g�v�f
    private int count; // �J�E���g���鐔
    void Start()
    {
        // �^�O���ɑΉ�����Q�[���I�u�W�F�N�g�̔z����擾
        GameObject[] tagObjects = GameObject.FindGameObjectsWithTag(tagname);

        // �Q�[���I�u�W�F�N�g�̑������擾
        count = tagObjects.Length;

        // ������\������e�L�X�g���X�V����
        UpdateCountText();
    }
    void Update()
    {
        //Vector3 targetPos = player.position;
    }
    void UpdateCountText()
    {
        countTexts.text = "" + count.ToString(); // �e�L�X�g���X�V����
    }
}
