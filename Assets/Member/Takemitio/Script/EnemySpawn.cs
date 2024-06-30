using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToSpawn; // 生成したいオブジェクトの配列
    [SerializeField] private float interval = 2.0f;       // 生成間隔（秒）
    [SerializeField] private float spawnDistance = 10.0f; // プレイヤーからの生成距離
    [SerializeField] private int maxSpawnCount = 3;       // 最大同時スポーン数
    private int _groupEnemycnt;
    [SerializeField] private int _totalEnemy;

    private Transform player;           // プレイヤーのTransform

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // "Player" タグを持つオブジェクトのTransformを取得

        // 初回のオブジェクト生成を待機せずに即座に行う
        SpawnObjects();
        // interval秒ごとにSpawnObjectsメソッドを呼び出す
        InvokeRepeating("SpawnObjects", interval, interval);
    }

    void SpawnObjects()
    {
        // 同時にスポーンするオブジェクト数をランダムで決定する
        int spawnCount = Random.Range(1, maxSpawnCount + 1);
        if(_totalEnemy <= _groupEnemycnt)
        {
            for (int i = 0; i < spawnCount; i++)
            {
                // プレイヤーの前方に一定の距離を保ってオブジェクトを生成する
                Vector3 spawnPosition = player.position + -player.forward * spawnDistance;


                // 生成位置にランダムなオフセットを加える（例として、-120～120のX軸方向、-80～80のY軸方向）
                spawnPosition += new Vector3(Random.Range(-120f, 120f), Random.Range(-80f, 80f), 0f);

                _groupEnemycnt += 5;
                // 配列の中からランダムに選んでオブジェクトを生成する
                int randomIndex = Random.Range(0, objectsToSpawn.Length);
                Instantiate(objectsToSpawn[randomIndex], spawnPosition, transform.rotation);
            }

        }

    }
}
