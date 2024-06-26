using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CuntUD : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI countTexts; // ���݂̔j�󂵂��G�̐���\������e�L�X�g�v�f
    [SerializeField] private TextMeshProUGUI falseObjectCountText; // �t�H�[���X�ȃI�u�W�F�N�g�̐���\������e�L�X�g�v�f
    [SerializeField] private TextMeshProUGUI homekotoba; // �G�N�Z�����g�̕\��

    private int inactiveMisailHit2Count; // �t�H�[���X�� Misail_Hit2 �R���|�[�l���g�̐�
    public int DestoroyEnemies; // �j�󂵂��G�̐�
    private int counthome; // �J�E���^
    private int juu = 10; // �G�N�Z�����g�̕\���̂��߂�臒l
    private int saisyo = 0; // �j�󂵂��G�̏����l
    private int maedec = 0; // �O��̔�A�N�e�B�u�� Misail_Hit2 �R���|�[�l���g�̐�

    void Start()
    {
        // ����������
        inactiveMisailHit2Count = 0;
        DestoroyEnemies = saisyo;
        countTexts.text = DestoroyEnemies.ToString();
        falseObjectCountText.text = inactiveMisailHit2Count.ToString();
        homekotoba.text = "";
    }

    void Update()
    {
        // ���݂̔�A�N�e�B�u�� Misail_Hit2 �R���|�[�l���g�̐����J�E���g
        Misail_Hit2[] allMisailHit2 = FindObjectsOfType<Misail_Hit2>();
        int currentInactiveCount = 0;

        foreach (Misail_Hit2 script in allMisailHit2)
        {
            if (!script.gameObject.activeSelf)
            {
                currentInactiveCount++;
            }
        }

        // ��A�N�e�B�u�� Misail_Hit2 �R���|�[�l���g�̐����������ꍇ
        if (currentInactiveCount > maedec)
        {
            DestoroyEnemies++; // �j�󂵂��G�̐��𑝂₷
            counthome++; // �J�E���^�𑝂₷
            homekotoba.text = ""; // �G�N�Z�����g�̕\�������Z�b�g
            maedec = currentInactiveCount; // �O��̔�A�N�e�B�u�� Misail_Hit2 �R���|�[�l���g�̐����X�V
            UpdateCountText(); // UI ���X�V
        }

        // �G�N�Z�����g�̕\��
        if (counthome == juu)
        {
            homekotoba.text = "Excellent!";
            counthome = 0;
        }
    }

    void UpdateCountText()
    {
        countTexts.text = DestoroyEnemies.ToString(); // �j�󂵂��G�̐���\��
        falseObjectCountText.text = maedec.ToString(); // ��A�N�e�B�u�� Misail_Hit2 �R���|�[�l���g�̐���\��
    }


    //[SerializeField] private TextMeshProUGUI countTexts;
    //[SerializeField] private TextMeshProUGUI homekotoba;

    //public int DestoroyEnemies;
    //private int counthome;
    //private int juu = 10;
    //private int saisyo = 0;
    //private int maedec = 0; // maedec ��������

    //void Start()
    //{
    //    Misail_Hit2[] allMisailHit2 = FindObjectsOfType<Misail_Hit2>();
    //    int inactiveMisailHit2Count = 0;

    //    // ��A�N�e�B�u�� Misail_Hit2 �R���|�[�l���g���J�E���g
    //    foreach (Misail_Hit2 script in allMisailHit2)
    //    {
    //        if (!script.gameObject.activeSelf)
    //        {
    //            inactiveMisailHit2Count++;
    //        }
    //    }

    //    Debug.Log("��A�N�e�B�u�� Misail_Hit2 �R���|�[�l���g�����I�u�W�F�N�g�̐�: " + inactiveMisailHit2Count);

    //    // �Q�[���I�u�W�F�N�g�̑������擾
    //    DestoroyEnemies = saisyo;

    //    countTexts.text = "0";
    //    UpdateCountText(); // �e�L�X�g�������\��

    //    // ������ maedec ��ݒ�
    //    maedec = inactiveMisailHit2Count;
    //}

    //void Update()
    //{
    //    Misail_Hit2[] allMisailHit2 = FindObjectsOfType<Misail_Hit2>();
    //    int inactiveMisailHit2Count = 0;

    //    // ��A�N�e�B�u�� Misail_Hit2 �R���|�[�l���g���J�E���g
    //    foreach (Misail_Hit2 script in allMisailHit2)
    //    {
    //        if (!script.gameObject.activeSelf)
    //        {
    //            inactiveMisailHit2Count++;
    //        }
    //    }

    //    Debug.Log("��A�N�e�B�u�� Misail_Hit2 �R���|�[�l���g�����I�u�W�F�N�g�̐�: " + inactiveMisailHit2Count);

    //    // �G���|���ꂽ���̏���
    //    if (inactiveMisailHit2Count > maedec)
    //    {
    //        DestoroyEnemies += 1;
    //        counthome += 1;
    //        homekotoba.text = "";
    //        maedec = inactiveMisailHit2Count;
    //        UpdateCountText();
    //    }

    //    // Excellent! �̕\��
    //    if (counthome == juu)
    //    {
    //        homekotoba.text = "Excellent!";
    //        counthome = 0;
    //    }
    //}

    //void UpdateCountText()
    //{
    //    countTexts.text = DestoroyEnemies.ToString(); // ���݂̃J�E���g�Ńe�L�X�g���X�V����
    //}





    // Misail_Hit2[] allMisailHit2;
    // // Misail_Hit2 �X�N���v�g���A�^�b�`����Ă���I�u�W�F�N�g�̂����ASetActive(false)�ɐݒ肳��Ă�����̂̐����J�E���g����



    //public int inactiveMisailHit2Coun;



    ////[SerializeField] private string tagname; // �^�O�����w�肷�邽�߂̕ϐ�
    //[SerializeField] private TextMeshProUGUI countTexts; // �J�E���g��\������e�L�X�g�v�f
    // [SerializeField] private TextMeshProUGUI homekotoba;
    // public int CountText; // ���݂̃J�E���g��
    // //private int count; // �J�E���g���鐔
    // //private int previousCount; // �O��̃J�E���g��
    // private int counthome;
    // public int DestoroyEnemies;
    // private int juu = 10;
    // private int saisyo = 0;
    // public Misail_Hit2 Enemydec;
    // private int maedec;
    // void Start()
    // {

    //     Misail_Hit2[] allMisailHit2 = FindObjectsOfType<Misail_Hit2>();
    //     int inactiveMisailHit2Count = 0;
    //     //Misail_Hit2 Enemydec = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Misail_Hit2>();


    //     // �^�O���ɑΉ�����Q�[���I�u�W�F�N�g�̔z����擾
    //     //GameObject[] tagObjects = GameObject.FindGameObjectsWithTag(tagname);
    //     // Enemydec������������i��Ƃ���FindObjectOfType���g�p����j
    //     //Enemydec = FindObjectOfType<Misail_Hit2>();
    //     // �Q�[���I�u�W�F�N�g�̑������擾
    //     DestoroyEnemies = saisyo;

    //     //maedec = Enemydec.DesEne;
    //     //Debug.Log(Enemydec.DesEne);
    //     // �����̃J�E���g��ݒ肷��
    //     //CountText = count;
    //     //previousCount = CountText;
    //     countTexts.text = "0";
    //     // �e�L�X�g���X�V���ď����\����ݒ肷��
    //     UpdateCountText();

    // }
    // void Update()
    // {
    //     Misail_Hit2[] allMisailHit2 = FindObjectsOfType<Misail_Hit2>();
    //     foreach (Misail_Hit2 script in allMisailHit2)
    //     {
    //         if (!script.gameObject.activeSelf)
    //         {
    //             maedec = inactiveMisailHit2Count;
    //             inactiveMisailHit2Count++;
    //         }
    //     }

    //     Debug.Log("��A�N�e�B�u�� Misail_Hit2 �R���|�[�l���g�����I�u�W�F�N�g�̐�: " + inactiveMisailHit2Count);
    //     //�G���|���ꂽ��
    //     if (inactiveMisailHit2Count > maedec)
    //     {
    //         Debug.Log("��A�N�e�B�u�� Misail_Hit2 �R���|�[�l���g�����I�u�W�F�N�g�̐�: " + inactiveMisailHit2Count);
    //         DestoroyEnemies += 1;
    //         counthome += 1;
    //         homekotoba.text = "";
    //         maedec = inactiveMisailHit2Count;
    //         UpdateCountText();
    //     }
    //     // ���݂̃J�E���g�����擾
    //     //CountText = CountObjectsWithTag();
    //     if (counthome == juu)
    //     {
    //         homekotoba.text = "Excellent!";
    //         counthome = 0;
    //     }
    //     //// �J�E���g�����������ꍇ�̂ݍX�V����
    //     //if (CountText < previousCount)
    //     //{
    //     //    counthome += 1;
    //     //    homekotoba.text = "";
    //     //    DestoroyEnemies += 1;
    //     //    previousCount = CountText; // �O��̃J�E���g���X�V
    //     //    UpdateCountText(); // �e�L�X�g���X�V

    //     //}
    // }

    // //private int CountObjectsWithTag()
    // //{
    // //    GameObject[] tagObjects = GameObject.FindGameObjectsWithTag(tagname);
    // //    return tagObjects.Length;
    // //}
    // void UpdateCountText()
    // {
    //     countTexts.text = "" + DestoroyEnemies.ToString(); // ���݂̃J�E���g�Ńe�L�X�g���X�V����

    // }
}
