using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetOn : MonoBehaviour
{
    //public Transform plyerp;
  
    public Transform teki;
    public float tekikyuri;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject child = transform.GetChild(0).gameObject;
        Vector3 targetPos = teki.position;
        
        Setonp();
    }
    public void Setonp()
    {
        float distance = Vector3.Distance(transform.position, teki.position); 
        if (distance == tekikyuri)
        {
            
        }
    }
}
