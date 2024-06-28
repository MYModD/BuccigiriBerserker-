using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToSpawn; // �����������I�u�W�F�N�g�̔z��
    [SerializeField] private float interval = 2.0f;       // �����Ԋu�i�b�j
    [SerializeField] private float spawnDistance = 10.0f; // �v���C���[����̐�������
    [SerializeField] private int maxSpawnCount = 3;       // �ő哯���X�|�[����
    private int _groupEnemycnt;
    [SerializeField] private int _totalEnemy;

    private Transform player;           // �v���C���[��Transform

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // "Player" �^�O�����I�u�W�F�N�g��Transform���擾

        // ����̃I�u�W�F�N�g������ҋ@�����ɑ����ɍs��
        SpawnObjects();
        // interval�b���Ƃ�SpawnObjects���\�b�h���Ăяo��
        InvokeRepeating("SpawnObjects", interval, interval);
    }

    void SpawnObjects()
    {
        // �����ɃX�|�[������I�u�W�F�N�g���������_���Ō��肷��
        int spawnCount = Random.Range(1, maxSpawnCount + 1);
        if(_totalEnemy <= _groupEnemycnt)
        {
            for (int i = 0; i < spawnCount; i++)
            {
                // �v���C���[�̑O���Ɉ��̋�����ۂ��ăI�u�W�F�N�g�𐶐�����
                Vector3 spawnPosition = player.position + -player.forward * spawnDistance;


                // �����ʒu�Ƀ����_���ȃI�t�Z�b�g��������i��Ƃ��āA-120�`120��X�������A-80�`80��Y�������j
                spawnPosition += new Vector3(Random.Range(-120f, 120f), Random.Range(-80f, 80f), 0f);

                _groupEnemycnt += 5;
                // �z��̒����烉���_���ɑI��ŃI�u�W�F�N�g�𐶐�����
                int randomIndex = Random.Range(0, objectsToSpawn.Length);
                Instantiate(objectsToSpawn[randomIndex], spawnPosition, transform.rotation);
            }

        }

    }
}
