using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missile_fire : MonoBehaviour
{

    [SerializeField]
    GameObject missile;

    [SerializeField]
    GameObject firepoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Vector3 missileposition = firepoint.transform.position;

            GameObject newmissile = Instantiate(missile, missileposition, missile.transform.rotation);


        }
    }


}
