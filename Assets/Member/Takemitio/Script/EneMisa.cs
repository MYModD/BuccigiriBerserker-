using UnityEngine;

public class EneMisa : MonoBehaviour
{
    public GameObject missilePrefab;  // Missileプレハブを設定するための変数
    private Transform defaultTarget;  // デフォルトのターゲットを設定するための変数
    public float spawnInterval = 2f; // ミサイルの生成間隔

    void Start()
    {
        defaultTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        // spawnInterval秒ごとにSpawnMissile関数を呼び出す
        //InvokeRepeating("SpawnMissile", 0f, spawnInterval * Time.deltaTime);
        InvokeRepeating("SpawnMissile", Random.Range(10,15), Random.Range(10,20));
    }

    void SpawnMissile()
    {
        // missilePrefabをインスタンス化し、Missileコンポーネントを取得
        GameObject newMissile = Instantiate(missilePrefab, transform.position, transform.rotation);
        newMissile.GetComponent<EnemyMissile>().target = defaultTarget;
    }
}