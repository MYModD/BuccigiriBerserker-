using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CuntUD : MonoBehaviour
{
    public string tagname; // �^�O�����w�肷�邽�߂̕ϐ�
    public TextMeshProUGUI countTexts; // �J�E���g��\������e�L�X�g�v�f
    private int count; // �J�E���g���鐔
    //private float timer = 0.3f; // 1�b���ƂɌ��������邽�߂̃^�C�}�[
    //private float currentTime = 0f; // ���݂̌o�ߎ���
    private int previousCount; // �O��̃J�E���g��
    private int currentCount; // ���݂̃J�E���g��

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
        // ���݂̃J�E���g�����擾
        currentCount = CountObjectsWithTag();

        // �J�E���g�����������ꍇ�̂ݍX�V����
        if (currentCount < previousCount)
        {
            previousCount = currentCount; // �O��̃J�E���g���X�V
            UpdateCountText(); // �e�L�X�g���X�V
            print("a");
        }
    }
    private int CountObjectsWithTag()
    {
        GameObject[] tagObjects = GameObject.FindGameObjectsWithTag(tagname);
        return tagObjects.Length;
        print("d");
    }
    void UpdateCountText()
    {
        print("s");
        countTexts.text = "" + count.ToString(); // �e�L�X�g���X�V����
    }
}
