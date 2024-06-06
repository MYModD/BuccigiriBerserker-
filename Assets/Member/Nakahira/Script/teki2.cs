using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teki2 : MonoBehaviour
{

    public Transform target;
    public float moveSpeed;
    public float stop;
    public float mo;
    public float st;
    public Transform target2;
  
    void Update()
    {
        Vector3 targetPos = target.position;
        transform.LookAt(targetPos);
        Vector3 targetPos2 = target2.position;
        GameObject child = transform.GetChild(0).gameObject;
     

        float distance = Vector3.Distance(transform.position, target.position);
        if (distance > stop)
        {
            transform.position = transform.position + transform.forward * moveSpeed * Time.deltaTime;
        }
        else if (distance < stop)
        {
            transform.LookAt(targetPos2);
            transform.position = transform.position + transform.forward * moveSpeed * Time.deltaTime;
        }
        else if (mo == st)
        {
          
        }

    }
}
