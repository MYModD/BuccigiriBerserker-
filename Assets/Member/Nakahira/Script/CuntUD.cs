using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CuntUD : MonoBehaviour
{

  

    // Misail_Hit2 �X�N���v�g���A�^�b�`����Ă���I�u�W�F�N�g�̂����ASetActive(false)�ɐݒ肳��Ă�����̂̐����J�E���g����
    private Misail_Hit2 misailHit2; // Misail_Hit2 �X�N���v�g�ւ̎Q��


    //[SerializeField] private string tagname; // �^�O�����w�肷�邽�߂̕ϐ�
    [SerializeField] private TextMeshProUGUI countTexts; // �J�E���g��\������e�L�X�g�v�f
    [SerializeField] private TextMeshProUGUI homekotoba;
    public int CountText; // ���݂̃J�E���g��
                          //private int count; // �J�E���g���鐔
                          //private int previousCount; // �O��̃J�E���g��
    private int inactiveMisailHit2Count;
    private int counthome;
    public int DestoroyEnemies;
    private int juu = 10;
    private int saisyo = 0;
    public Misail_Hit2 Enemydec;
    private int maedec;

    void Start()
    {
        //Misail_Hit2 Eneyd = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Misail_Hit2>();
        //misailHit2 = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Misail_Hit2>();
        inactiveMisailHit2Count = 0;
        //Misail_Hit2 Enemydec = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Misail_Hit2>();

       
        // �^�O���ɑΉ�����Q�[���I�u�W�F�N�g�̔z����擾
        //GameObject[] tagObjects = GameObject.FindGameObjectsWithTag(tagname);
        // Enemydec������������i��Ƃ���FindObjectOfType���g�p����j
        //Enemydec = FindObjectOfType<Misail_Hit2>();
        // �Q�[���I�u�W�F�N�g�̑������擾
        DestoroyEnemies = saisyo;

        //maedec = Enemydec.DesEne;
        //Debug.Log(Enemydec.DesEne);
        // �����̃J�E���g��ݒ肷��
        //CountText = count;
        //previousCount = CountText;
        countTexts.text = "0";
        // �e�L�X�g���X�V���ď����\����ݒ肷��
        UpdateCountText();

    }
    void Update()
    {


        //Misail_Hit2 Enemydec = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Misail_Hit2>();
        //�G���|���ꂽ��
        if (inactiveMisailHit2Count > maedec)
        {
            Debug.Log(inactiveMisailHit2Count);
            DestoroyEnemies += 1;
            counthome += 1;
            homekotoba.text = "";
            maedec = inactiveMisailHit2Count;
            UpdateCountText();
        }
        // ���݂̃J�E���g�����擾
        //CountText = CountObjectsWithTag();
        if (counthome == juu)
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
    public void UpdateCountText()
    {
        //countTexts.text = misailHit2._desEne.ToString(); // Misail_Hit2 �� DesEne ���Q�Ƃ��� UI ���X�V����
        countTexts.text = misailHit2._desEne.ToString();

    }
}
