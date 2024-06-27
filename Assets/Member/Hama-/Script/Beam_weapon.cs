using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam_weapon : MonoBehaviour
{
    [SerializeField]
    ParticleSystem longparticleSystem;
    [SerializeField]
    float distance = 10f;
    private BusterControl buster;
    private bool check;
    private float time;

    private void Start()
    {
        buster = GetComponent<BusterControl>();
        check = false;
        longparticleSystem.Stop();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartBeam();
        }

        if (check)
        {
            Beam();
            time += Time.deltaTime;
            if (time >= 5f)
            {
                EndBeam();
            }
        }
    }

    void StartBeam()
    {
        check = true;
        time = 0f;
        longparticleSystem.Play();
    }

    void EndBeam()
    {
        check = false;
        longparticleSystem.Stop();
    }

    void Beam()
    {
        var scale = transform.lossyScale.x * 2f;

        // ���C�L���X�g�̌��ʂ��i�[����ϐ�
        RaycastHit[] hits;

        // BoxCastAll���g�p���Ă��ׂẴq�b�g���擾����
        hits = Physics.BoxCastAll(transform.position, Vector3.one * scale, transform.forward, transform.rotation, distance);

        // �q�b�g�������ׂẴI�u�W�F�N�g�ɑ΂��ď������s��
        foreach (RaycastHit hit in hits)
        {
            Debug.Log("HIT");
        }

    }
}







