using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisailHit : MonoBehaviour
{
    //public Transform missile;
    public Transform player;
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = player.position;
    }
    public void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "missile")
        {
          
        }
        
    }
}
