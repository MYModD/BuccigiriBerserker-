using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLockimage : MonoBehaviour
{
    public EnemyLock _enemyLock;

    public PlayerLockon _playerLockon;

    List<GameObject> _enemyList;
    // Start is called before the first frame update
    void Start()
    {
        List<GameObject> _enemyList = _playerLockon._hits;
        _enemyLock = GetComponent<EnemyLock>();
    }

    // Update is called once per frame
    void Update()
    {
        //ìÆÇ¢ÇƒÇ»Ç¢Å´
       //if (_enemyLock._isLock == true &&_enemyLock)
       // {
       //     //Debug.Log("LOCK ON!!");
       // }
    }
}
