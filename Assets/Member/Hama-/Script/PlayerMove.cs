using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float threshold = 0.5f;

    private Rigidbody rb;

    private float HolizontalValue;

    private float VerticalValue;

    public float speed = 15f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(HolizontalValue);
        //Debug.Log(VerticalValue);
        // ‘Oi‚ÍŽ©“®


        //ù‰ñ


    }

    private void FixedUpdate()
    {
        HolizontalValue = Input.GetAxisRaw("Horizontal");

        VerticalValue = Input.GetAxisRaw("Vertical");

        if (HolizontalValue > 0)
        {

           transform.Translate(-speed  , 0f, -speed *5);
        }

        if (HolizontalValue < 0)
        {
            transform.Translate(speed , 0f, -speed *5);
        }

        if (VerticalValue > 0)
        {
            transform.Translate(0, speed , -speed *5);
        }

        if (VerticalValue < 0)
        {
            transform.Translate(0, -speed, -speed *5);
        }
    }
}
