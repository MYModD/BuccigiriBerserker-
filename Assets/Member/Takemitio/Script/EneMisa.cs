using UnityEngine;

public class EneMisa : MonoBehaviour
{
    public GameObject missilePrefab;  // Missile�v���n�u��ݒ肷�邽�߂̕ϐ�
    private Transform defaultTarget;  // �f�t�H���g�̃^�[�Q�b�g��ݒ肷�邽�߂̕ϐ�
    public float spawnInterval = 2f; // �~�T�C���̐����Ԋu

    void Start()
    {
        defaultTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        // spawnInterval�b���Ƃ�SpawnMissile�֐����Ăяo��
        InvokeRepeating("SpawnMissile", 0f, spawnInterval);
    }

    void SpawnMissile()
    {
        // missilePrefab���C���X�^���X�����AMissile�R���|�[�l���g���擾
        GameObject newMissile = Instantiate(missilePrefab, transform.position, transform.rotation);
        
        
        newMissile.GetComponent<EnemyMissile>().target = defaultTarget;
    }
}