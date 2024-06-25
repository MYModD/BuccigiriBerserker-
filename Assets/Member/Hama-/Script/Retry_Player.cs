using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Retry_Player : MonoBehaviour
{
    //  private PlayerLife playerlife;

    //  private Vector3 playerPosition;

    //  private Quaternion playerRotation;

    //  [SerializeField]
    //  GameObject player;

    //  [SerializeField]
    //  float spawnpos = 2f;

    //  // Start is called before the first frame update
    //  void Start()
    //  {
    //      PlayerLife playerLife = GetComponent<PlayerLife>();
    //      // �ŏ��Ƀv���C���[�̈ʒu�ƌ������擾���Ă���
    //      playerPosition = transform.position;
    //      playerRotation = transform.rotation;
    //  }

    //  // Update is called once per frame
    //  void Update()
    //  {
    //      if(playerlife._IsRetry == true)
    //      {
    //          Debug.Log("SSAASSAA");
    //          // �v���C���[�̈ʒu�ƌ������擾
    //          Vector3 playerPosition = transform.position;
    //          Quaternion playerRotation = transform.rotation;
    //          //Invoke(nameof(Retry), 3f);
    //          Retry();
    //      }
    //  }

    //void Retry()
    //  {
    //      Debug.Log("DDDFFF");
    //      Vector3 spawnPosition = playerPosition - transform.forward * spawnpos; // �v���C���[�̌���2���[�g�����炷��
    //      Instantiate(player, spawnPosition, playerRotation);


    //  }

    public GameObject playerPrefab; // �v���C���[�̃v���n�u
    public CinemachineVirtualCameraBase newvirtualCamera; // �V����Virtual Camera�̃v���n�u
    public float spawnDistance = 2f; // �v���C���[�̌��ɐ������鋗��

    private GameObject playerInstance; // �������ꂽ�v���C���[�I�u�W�F�N�g�̃C���X�^���X
    private CinemachineVirtualCameraBase nowVirtualCamera; // ���݂�Virtual Camera

    void Start()
    {
        // �v���C���[�𐶐�����
        SpawnPlayer();
    }

    void Update()
    {
        // �v���C���[�����ꂽ�ꍇ
        if (playerInstance == null)
        {
            // �V����Virtual Camera�𐶐����Đݒ肷��
            SetupNewVirtualCamera();
        }
    }

    void SpawnPlayer()
    {
        // �v���C���[���������ɂ��炵�Đ�������
        Vector3 spawnPosition = transform.position - transform.forward * spawnDistance;
        playerInstance = Instantiate(playerPrefab, spawnPosition, transform.rotation);

        // �v���C���[�̃C���X�^���X�ɑΉ�����Virtual Camera��ݒ肷��
        nowVirtualCamera.Follow = playerInstance.transform;
    }

    void SetupNewVirtualCamera()
    {
        // �V����Virtual Camera�𐶐�����
        Vector3 spawnPosition = transform.position - transform.forward * spawnDistance;
        CinemachineVirtualCameraBase newVirtualCamera = Instantiate(newvirtualCamera, spawnPosition, transform.rotation);

        // �V����Virtual Camera�̐ݒ���s���i��F�^�[�Q�b�g�̐ݒ�j
        newVirtualCamera.Follow = playerInstance.transform; // �v���C���[��ǐՂ���ݒ�Ȃ�

        // ���݂�Virtual Camera���X�V����
        nowVirtualCamera = newVirtualCamera;
    }
}
