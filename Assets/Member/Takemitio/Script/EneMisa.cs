using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EneMisa : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float interval = 5f; // �C���X�^���X���Ԋu
    GameObject missile;

    void Start()
    {
        missile = GameObject.FindGameObjectWithTag("missile");
        // interval�b���Ƃ�SpawnObject�֐����Ăяo��
        InvokeRepeating("SpawnObject", 0f, interval);
    }

    void SpawnObject()
    {
        // objectToSpawn���C���X�^���X�����鏈��
        Instantiate(objectToSpawn, transform.position, transform.rotation);
        missile.GetComponent<Missile>().target = GameObject.FindGameObjectWithTag("player").transform;
    }
}

