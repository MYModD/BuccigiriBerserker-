using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine_gun : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;

    [SerializeField]
    GameObject bulletpoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire2"))
        {
            Vector3 bulletposition = bulletpoint.transform.position;

            

            GameObject newbullet = Instantiate(bullet, bulletposition, bullet.transform.rotation);

           
        }
    }
}
