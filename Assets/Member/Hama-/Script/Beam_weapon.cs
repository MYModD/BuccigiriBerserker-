using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam_weapon : MonoBehaviour
{
    [SerializeField]
    ParticleSystem longparticleSystem;
    [SerializeField]
    float distance = 10f;
    public BusterControl buster;
    private bool check;
    private float time;

    private void Start()
    {

        // �����܂��A�^�b�`����Ă��Ȃ��ꍇ�́A������ GetComponent ���g���ď���������
        if (buster == null)
        {
            buster = GetComponent<BusterControl>();
        }
        check = false;
        if (longparticleSystem == null)
        {
            longparticleSystem = GetComponent<ParticleSystem>();
        }

        longparticleSystem.Stop();
    }

    private void Update()
    {
        if (buster._Beamshot)
        {
            StartBeam();
        }

        if (check)
        {
            Beam();
        }

        if (check && !buster._Beamshot)
        {
            EndBeam();
        }
    }

    void StartBeam()
    {

        check = true;
        time = 0f;
        // �p�[�e�B�N���V�X�e�����Đ�����

        longparticleSystem.Play();

    }

    void EndBeam()
    {
        check = false;
        // �p�[�e�B�N���V�X�e�����~����
        longparticleSystem.Stop();

    }

    void Beam()
    {
        var scale = transform.lossyScale.x * 2f;

        // �{�b�N�X�̃T�C�Y���`����ϐ�
        Vector3 boxSize = new Vector3(6f, 6f, 2f);

        // ���C�L���X�g�̌��ʂ��i�[����ϐ�
        RaycastHit[] hits;

        // BoxCastAll���g�p���Ă��ׂẴq�b�g���擾����
        hits = Physics.BoxCastAll(transform.position, boxSize, transform.forward, transform.rotation, distance);

        // �q�b�g�������ׂẴI�u�W�F�N�g�ɑ΂��ď������s��
        foreach (RaycastHit hit in hits)
        {
            Debug.Log("HIT");
        }

    }
}







