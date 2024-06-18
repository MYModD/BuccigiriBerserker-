using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teki : MonoBehaviour
{
    private GameObject target;
    public float speed;
    public Transform targetp;
    public float moveSpeed;
    public float stopDistance;
    void Start()
    {
        
        speed = 6f;
        target = GameObject.FindWithTag("Player");
    }

void Update()
{
    Vector3 targetPos = targetp.position;
        float distance = Vector3.Distance(transform.position, targetp.position);
        transform.LookAt(target.transform);
    transform.position += transform.forward * speed * Time.deltaTime;
}
    //protected void OnTriggerEnter(Collider c)
    //{
    //    if (c.gameObject.tag == "Player")
    //    {
    //        target.OnEnterFollowTarget();
    //    }
    //}

    //protected void OnTriggerExit(Collider c)
    //{
    //    if (c.gameObject.tag == "Player")
    //    {
    //        target.OnExitFollowTarget(c.transform);
    //    }
    //}
}
