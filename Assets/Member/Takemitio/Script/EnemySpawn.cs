using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] objectsToSpawn; // �����������I�u�W�F�N�g�̔z��
    public float interval = 2.0f;       // �����Ԋu�i�b�j
    public float spawnDistance = 10.0f; // �v���C���[����̐�������

    private int currentIndex = 0;       // ���݂̔z��C���f�b�N�X
    private Transform player;           // �v���C���[��Transform

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // "Player" �^�O�����I�u�W�F�N�g��Transform���擾

        // ����̃I�u�W�F�N�g������ҋ@�����ɑ����ɍs��
        SpawnObject();
        // interval�b���Ƃ�SpawnObject���\�b�h���Ăяo��
        InvokeRepeating("SpawnObject", interval, interval);
    }

    void SpawnObject()
    {
        // �v���C���[�̑O���Ɉ��̋�����ۂ��ăI�u�W�F�N�g�𐶐�����
        Vector3 spawnPosition = player.position + -player.forward * spawnDistance;

        spawnPosition += new Vector3(Random.Range(-120f, 120f), Random.Range(-80f, 80f), 0f);

        // �z��̌��݂̃C���f�b�N�X�ɑΉ�����I�u�W�F�N�g�𐶐�����
        Instantiate(objectsToSpawn[currentIndex], spawnPosition, transform.rotation);

        // �C���f�b�N�X�����ɐi�߂�i���[�v������j
        currentIndex = Random.Range(0,objectsToSpawn.Length);
    }
}
