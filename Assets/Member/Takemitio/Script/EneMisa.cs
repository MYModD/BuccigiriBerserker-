using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EneMisa : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float interval = 5f; // インスタンス化間隔
    GameObject missile;

    void Start()
    {
        missile = GameObject.FindGameObjectWithTag("missile");
        // interval秒ごとにSpawnObject関数を呼び出す
        InvokeRepeating("SpawnObject", 0f, interval);
    }

    void SpawnObject()
    {
        // objectToSpawnをインスタンス化する処理
        Instantiate(objectToSpawn, transform.position, transform.rotation);
        missile.GetComponent<Missile>().target = GameObject.FindGameObjectWithTag("player").transform;
    }
}

