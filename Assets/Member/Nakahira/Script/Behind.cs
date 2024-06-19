using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behind : MonoBehaviour
{
    public float plykstn;
    public Transform plyer;
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + transform.forward * moveSpeed * Time.deltaTime;
        Vector3 plyPos = plyer.position;
        float distancepl = Vector3.Distance(transform.position, plyer.position);
        if (distancepl < plykstn)
        {
            transform.position = transform.position + transform.forward * moveSpeed * Time.deltaTime;
        }
        if (distancepl > plykstn)
        {
            transform.position = transform.position - transform.forward * moveSpeed * Time.deltaTime;

        }

    }
}

