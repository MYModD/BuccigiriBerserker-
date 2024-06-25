using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Retry_Player : MonoBehaviour
{

    public GameObject playerPrefab; // プレイヤーのプレハブ
    public CinemachineVirtualCameraBase newvirtualCamera; // 新しいVirtual Cameraのプレハブ
    public float spawnDistance = 2f; // プレイヤーの後ろに生成する距離

    private GameObject playerInstance; // 生成されたプレイヤーオブジェクトのインスタンス
    private CinemachineVirtualCameraBase nowVirtualCamera; // 現在のVirtual Camera

    void Start()
    {
        // プレイヤー
        playerPrefab = GameObject.Find("Player");
    }

    void Update()
    {
        // プレイヤーがやられた場合
        if (playerPrefab == null)
        {
            // 新しいVirtual Cameraを生成して設定する
            //SetupNewVirtualCamera();
            SpawnPlayer();
        }
    }

    void SpawnPlayer()
    {
        // プレイヤーを少し後ろにずらして生成する
        Vector3 spawnPosition = transform.position - transform.forward * spawnDistance;
        playerInstance = Instantiate(playerPrefab, spawnPosition, transform.rotation);

        // プレイヤーのインスタンスに対応するVirtual Cameraを設定する
        nowVirtualCamera.Follow = playerInstance.transform;
    }

    void SetupNewVirtualCamera()
    {
        // 新しいVirtual Cameraを生成する
        Vector3 spawnPosition = transform.position - transform.forward * spawnDistance;
        CinemachineVirtualCameraBase newVirtualCamera = Instantiate(newvirtualCamera, spawnPosition, transform.rotation);

        // 新しいVirtual Cameraの設定を行う（例：ターゲットの設定）
        newVirtualCamera.Follow = playerInstance.transform; // プレイヤーを追跡する設定など

        // 現在のVirtual Cameraを更新する
        nowVirtualCamera = newVirtualCamera;
    }
}
