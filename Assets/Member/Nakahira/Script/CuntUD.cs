using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CuntUD : MonoBehaviour
{
   
   [SerializeField] private string tagname; // �^�O�����w�肷�邽�߂̕ϐ�
    [SerializeField] private TextMeshProUGUI countTexts; // �J�E���g��\������e�L�X�g�v�f
    [SerializeField] private TextMeshProUGUI homekotoba;
    public int CountText; // ���݂̃J�E���g��
    //private int count; // �J�E���g���鐔
    //private int previousCount; // �O��̃J�E���g��
    private int counthome;
    public int DestoroyEnemies;
    private int juu = 10;
    private int saisyo = 0;
    Misail_Hit2 Enemydec;
    private int maedec;
    void Start()
    {

        // �^�O���ɑΉ�����Q�[���I�u�W�F�N�g�̔z����擾
        //GameObject[] tagObjects = GameObject.FindGameObjectsWithTag(tagname);

        // �Q�[���I�u�W�F�N�g�̑������擾
        DestoroyEnemies = saisyo;

        maedec = Enemydec.DesEne;

        // �����̃J�E���g��ݒ肷��
        //CountText = count;
        //previousCount = CountText;

        // �e�L�X�g���X�V���ď����\����ݒ肷��
        UpdateCountText();

    }
    void Update()
    {
        //�G���|���ꂽ��
        if(Enemydec.DesEne> maedec)
        {
            DestoroyEnemies += 1;
            counthome += 1;
            homekotoba.text = "";
            maedec = Enemydec.DesEne;
            UpdateCountText();
        }
        // ���݂̃J�E���g�����擾
        //CountText = CountObjectsWithTag();
        if(counthome == juu)
        {
            homekotoba.text = "Excellent!";
            counthome = 0;
        }
        //// �J�E���g�����������ꍇ�̂ݍX�V����
        //if (CountText < previousCount)
        //{
        //    counthome += 1;
        //    homekotoba.text = "";
        //    DestoroyEnemies += 1;
        //    previousCount = CountText; // �O��̃J�E���g���X�V
        //    UpdateCountText(); // �e�L�X�g���X�V
           
        //}
    }

    //private int CountObjectsWithTag()
    //{
    //    GameObject[] tagObjects = GameObject.FindGameObjectsWithTag(tagname);
    //    return tagObjects.Length;
    //}
    void UpdateCountText()
    {
        countTexts.text = "" + DestoroyEnemies; // ���݂̃J�E���g�Ńe�L�X�g���X�V����
        
    }
}
