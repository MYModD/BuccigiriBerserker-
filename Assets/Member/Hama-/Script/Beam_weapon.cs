using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam_weapon : MonoBehaviour
{

    [SerializeField] private ParticleSystem particle;
    [SerializeField]
    float distance = 10f;
    public BusterControl buster;
    private bool check;


    private void Start()
    {

        // �����܂��A�^�b�`����Ă��Ȃ��ꍇ�́A������ GetComponent ���g���ď���������
        if (buster == null)
        {
            buster = GetComponent<BusterControl>();
        }
        check = false;


        if (particle == null)
        {
            particle = GetComponent<ParticleSystem>();
        }

        StopParticle();




    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            particle.Play();

        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            particle.Stop();
        }

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

    private void StartBeam()
    {
        particle = GetComponent<ParticleSystem>();
        Debug.Log("START");
        check = true;
        // �p�[�e�B�N���V�X�e�����Đ���


    }

    private void EndBeam()
    {
        particle = GetComponent<ParticleSystem>();
        Debug.Log("END");
        check = false;
        // �p�[�e�B�N���V�X�e�����~����
        StopParticle();

    }

    private void StopParticle()
    {
        // �p�[�e�B�N�����Đ����ł���Β�~����
        if (particle.isPlaying)
        {
            particle.Stop();
        }
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

        particle.Play();

    }


}







