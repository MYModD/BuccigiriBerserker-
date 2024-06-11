using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float speed_z;
   // public Quaternion PlayerRot;
    // Start is called before the first frame update
    void Start()
    {
        speed_z = 500f;
    }
   
    // Update is called once per frame
    void Update()
    {
      // float Horizontal = Input.GetAxis("Horizontal");
       float Vertical = Input.GetAxis("Vertical");
       // PlayerRot = transform.rotation;
       Vector3 forward = Vector3.forward;
        transform.position += new Vector3(0, -Vertical * 180 * Time.deltaTime ,0);
        transform.position += transform.TransformDirection(Vector3.forward) * speed_z * Time.deltaTime;
        //transform.Rotate(Vector3.up, Horizontal * 135 * Time.deltaTime) ;

        


    }
}
