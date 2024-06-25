using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Retry_Player : MonoBehaviour
{

    public GameObject playerPrefab; // �v���C���[�̃v���n�u
    public CinemachineVirtualCameraBase newvirtualCamera; // �V����Virtual Camera�̃v���n�u
    public float spawnDistance = 2f; // �v���C���[�̌��ɐ������鋗��

    private GameObject playerInstance; // �������ꂽ�v���C���[�I�u�W�F�N�g�̃C���X�^���X
    private CinemachineVirtualCameraBase nowVirtualCamera; // ���݂�Virtual Camera

    void Start()
    {
        // �v���C���[
        playerPrefab = GameObject.Find("Player");
    }

    void Update()
    {
        // �v���C���[�����ꂽ�ꍇ
        if (playerPrefab == null)
        {
            // �V����Virtual Camera�𐶐����Đݒ肷��
            //SetupNewVirtualCamera();
            SpawnPlayer();
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
