using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missleMove : MonoBehaviour
{
    Rigidbody Rigidbody;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody.velocity = new Vector3(0,0,1)* 10f;
    }
}
