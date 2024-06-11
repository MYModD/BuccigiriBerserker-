using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Mapgen : MonoBehaviour
{   
    public GameObject _Stage; // 生成するプレハブのオブジェクト
    public Transform _spawnPoint; // 生成する位置
    float _zPos;
    float _genPos;
    // Start is called before the first frame update
    void Start()
    {
        

        // Cubeオブジェクトのz座標を取得
        
        _genPos = -2000;



    }


    // Update is called once per frame
    void Update()
    {
        Transform cubeTransform = gameObject.transform;
        _zPos = cubeTransform.position.z;
        //if(Input.GetMouseButtonDown(1))
        //{
        //SpawnStage();
        //}
        if (_zPos > _genPos)
        {
            SpawnStage();
        }
        Debug.Log(_zPos);
        Debug.Log(_genPos);
    } 
    public void SpawnStage()
        {
            // 指定された位置にプレハブのオブジェクトを生成する
            Instantiate(_Stage, _spawnPoint.position, _spawnPoint.rotation);
            _spawnPoint.position = new Vector3(_spawnPoint.position.x, _spawnPoint.position.y, _spawnPoint.position.z + 1000);
            _genPos += 1000;
        }
}
