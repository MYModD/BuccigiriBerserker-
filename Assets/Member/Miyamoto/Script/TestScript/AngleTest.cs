using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleTest : MonoBehaviour
{
    public Transform _transfrom;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var diff = (_transfrom.position - transform.position).normalized;
        float angle = Vector3.Angle(transform.forward, diff);
        Debug.Log(angle);

    }
}
