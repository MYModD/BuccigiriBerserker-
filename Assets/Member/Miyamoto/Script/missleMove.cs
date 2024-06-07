using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MissleMove : MonoBehaviour
{
    
    Rigidbody Rigidbody;
    Vector3 target_Pos;
    public GameObject targetObj;
    public float raito;

    [Range(0f, 1f)]
    public float lerpfloat;


    public float speed;

    
    
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //if (Rigidbody.velocity.magnitude > 50f) return;
        Debug.Log(Rigidbody.velocity.magnitude);
        
        target_Pos = targetObj.transform.position;
        var diff = target_Pos - transform.position;
        var target_rot = Quaternion.LookRotation(diff);

        transform.rotation = Quaternion.Lerp(transform.rotation, target_rot, lerpfloat);
        
        
        /*var q = target_rot * Quaternion.Inverse(transform.rotation);
        var torque = new Vector3(q.x, q.y, q.z) * raito;

        Rigidbody.AddTorque(torque);時間があったらここをアップグレード*/


        Rigidbody.velocity = Rigidbody.rotation * new Vector3(0, 0, speed);

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("hit");
            Destroy(gameObject);
        }
        
        
        //gameObject.GetComponent<MeshRenderer>().enabled = false;
        //gameObject.GetComponent<Rigidbody>().isKinematic = true;
    }
}
