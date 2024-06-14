using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roll_Move : MonoBehaviour
{
    private float _speed = 10f;

    private float _rolling = 20f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {




        if (Input.GetButtonDown("Lift_Roll"))
        {

            this.gameObject.GetComponent<CapsuleCollider>().enabled = true;
            this.transform.Rotate(0, 0, 360 * _rolling);

        }

        if (Input.GetButtonDown("Right_Roll"))
        {

            this.gameObject.GetComponent<CapsuleCollider>().enabled = true;
            this.transform.Rotate(0, 0, 360 * _rolling);

        }

    }
}
