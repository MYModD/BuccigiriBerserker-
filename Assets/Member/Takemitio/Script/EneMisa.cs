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
        //InvokeRepeating("SpawnMissile", 0f, spawnInterval * Time.deltaTime);
        InvokeRepeating("SpawnMissile", Random.Range(2,5), Random.Range(2,5));
    }

    void SpawnMissile()
    {
        print("SpawnEnemyMissile");
        // missilePrefab���C���X�^���X�����AMissile�R���|�[�l���g���擾
        GameObject newMissile = Instantiate(missilePrefab,new Vector3(transform.position.x, transform.position.y - 20, transform.position.z),Quaternion.Euler(transform.rotation.x,transform.rotation.y + 180,transform.rotation.z));
        newMissile.GetComponent<EnemyMissile>().target = defaultTarget;
    }
}