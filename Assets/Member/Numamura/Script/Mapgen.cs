using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Mapgen : MonoBehaviour
{   
    public GameObject Stage; // 生成するプレハブのオブジェクト
    public Transform spawnPoint; // 生成する位置
    float zPos;
    float genPos;
    // Start is called before the first frame update
    void Start()
    {
        

        // Cubeオブジェクトのz座標を取得
        
        genPos = -2000;



    }


    // Update is called once per frame
    void Update()
    {
        Transform cubeTransform = gameObject.transform;
        zPos = cubeTransform.position.z;
        //if(Input.GetMouseButtonDown(1))
        //{
        //SpawnStage();
        //}
        if (zPos > genPos)
        {
            SpawnStage();
        }
        Debug.Log(zPos);
        Debug.Log(genPos);
    } 
    public void SpawnStage()
        {
            // 指定された位置にプレハブのオブジェクトを生成する
            Instantiate(Stage, spawnPoint.position, spawnPoint.rotation);
            spawnPoint.position = new Vector3(spawnPoint.position.x, spawnPoint.position.y, spawnPoint.position.z + 1000);
            genPos += 1000;
        }
}
