using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Misail_Hit2 : MonoBehaviour
{
   
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "missile")
        {
            PooledReturn();
            
        }
        if (coll.gameObject.tag == "????")
        {
            PooledReturn();
           
        }
    }
    public void PooledReturn()
    {
        this.gameObject.SetActive(false);
       
    }
   
}
