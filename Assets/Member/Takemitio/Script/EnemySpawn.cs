using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] objectsToSpawn; // 生成したいオブジェクトの配列
    public float interval = 2.0f;       // 生成間隔（秒）
    public float spawnDistance = 10.0f; // プレイヤーからの生成距離

    private int currentIndex = 0;       // 現在の配列インデックス
    private Transform player;           // プレイヤーのTransform

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // "Player" タグを持つオブジェクトのTransformを取得

        // 初回のオブジェクト生成を待機せずに即座に行う
        SpawnObject();
        // interval秒ごとにSpawnObjectメソッドを呼び出す
        InvokeRepeating("SpawnObject", interval, interval);
    }

    void SpawnObject()
    {
        // プレイヤーの前方に一定の距離を保ってオブジェクトを生成する
        Vector3 spawnPosition = player.position + -player.forward * spawnDistance;

        spawnPosition += new Vector3(Random.Range(-120f, 120f), Random.Range(-80f, 80f), 0f);

        // 配列の現在のインデックスに対応するオブジェクトを生成する
        Instantiate(objectsToSpawn[currentIndex], spawnPosition, transform.rotation);

        // インデックスを次に進める（ループさせる）
        currentIndex = Random.Range(0,objectsToSpawn.Length);
    }
}
