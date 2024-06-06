using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMove : MonoBehaviour
{
    [SerializeField] GameObject target;
    public float speed;

    void Start()
    {
        speed = 0.05f;
    }

    void Update()
    {
        transform.LookAt(target.transform);
        transform.position += transform.forward * speed;
    }
}