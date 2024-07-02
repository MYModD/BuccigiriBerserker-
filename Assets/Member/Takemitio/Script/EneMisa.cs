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
        InvokeRepeating("SpawnMissile", Random.Range(2,5), Random.Range(2,5));
    }

    void SpawnMissile()
    {
        print("SpawnEnemyMissile");
        // missilePrefabをインスタンス化し、Missileコンポーネントを取得
        GameObject newMissile = Instantiate(missilePrefab,new Vector3(transform.position.x, transform.position.y - 20, transform.position.z),Quaternion.Euler(transform.rotation.x,transform.rotation.y + 180,transform.rotation.z));
        newMissile.GetComponent<EnemyMissile>().target = defaultTarget;
    }
}