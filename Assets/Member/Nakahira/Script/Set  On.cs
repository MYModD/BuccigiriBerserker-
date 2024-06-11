using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetOn : MonoBehaviour
{
    
    public BoxCollider tekihako;
    public MeshRenderer tekimmes;
    public Transform teki;
    public float tekikyuri;
    // Start is called before the first frame update
    void Start()
    {
        tekimmes.enabled = false;
        tekihako.enabled = false;
        GameObject.FindWithTag("teki");
    }

    // Update is called once per frame
    void Update()
    {
      ///*  GameObject child = transform.GetChild(0).gameObjec*/t;
        Vector3 targetPos = teki.position;
        
        Setonp();
    }
    public void Setonp()
    {
        //Transform target3 = teki.transform.Find("tekiko");
        float distance = Vector3.Distance(transform.position, teki.position); 
        if (distance < tekikyuri)
        {
            tekihako.enabled = true;
            tekimmes.enabled = true;
        }
    }
}
