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
    //      // 最初にプレイヤーの位置と向きを取得しておく
    //      playerPosition = transform.position;
    //      playerRotation = transform.rotation;
    //  }

    //  // Update is called once per frame
    //  void Update()
    //  {
    //      if(playerlife._IsRetry == true)
    //      {
    //          Debug.Log("SSAASSAA");
    //          // プレイヤーの位置と向きを取得
    //          Vector3 playerPosition = transform.position;
    //          Quaternion playerRotation = transform.rotation;
    //          //Invoke(nameof(Retry), 3f);
    //          Retry();
    //      }
    //  }

    //void Retry()
    //  {
    //      Debug.Log("DDDFFF");
    //      Vector3 spawnPosition = playerPosition - transform.forward * spawnpos; // プレイヤーの後ろに2メートルずらす例
    //      Instantiate(player, spawnPosition, playerRotation);


    //  }

    public GameObject playerPrefab; // プレイヤーのプレハブ
    public CinemachineVirtualCameraBase newvirtualCamera; // 新しいVirtual Cameraのプレハブ
    public float spawnDistance = 2f; // プレイヤーの後ろに生成する距離

    private GameObject playerInstance; // 生成されたプレイヤーオブジェクトのインスタンス
    private CinemachineVirtualCameraBase nowVirtualCamera; // 現在のVirtual Camera

    void Start()
    {
        // プレイヤーを生成する
        SpawnPlayer();
    }

    void Update()
    {
        // プレイヤーがやられた場合
        if (playerInstance == null)
        {
            // 新しいVirtual Cameraを生成して設定する
            SetupNewVirtualCamera();
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
