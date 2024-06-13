using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teki2 : MonoBehaviour
{
    [SerializeField,Range(0,500)] private float beside;
    [SerializeField, Range(-500,0)] private float besidenaga;
    [SerializeField, Range(0, 500)] private float vertical;
    [SerializeField, Range(-500,0)] private float verticalnega;
    public Transform target;
    public float moveSpeed;
    public float stop;
    public float mo;
    public float st;
    public Transform target2;
    public Transform thisobj;
    public float speed;
    private void Start()
    {
        speed = 10.0f;
    }

    void Update()
    {
        
        Vector3 targetPos = target.position;
        transform.LookAt(targetPos);
        Vector3 targetPos2 = target2.position;
        //GameObject child = transform.GetChild(0).gameObject;
        float distance = Vector3.Distance(transform.position, target.position);
        float myPos = Vector3.Distance(transform.right, thisobj.position);
        float myPosv = Vector3.Distance(transform.up, thisobj.position);
        if (myPos > beside || myPos < besidenaga || myPosv > vertical || myPosv < verticalnega)
        {
           
        }
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
