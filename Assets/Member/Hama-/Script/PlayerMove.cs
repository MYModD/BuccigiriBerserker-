using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test
{

    public class PlayerMove : MonoBehaviour
    {
        //private const float threshold = 0.5f;

        private Rigidbody rb;

        private float HolizontalValue;

        private float VerticalValue;

        [SerializeField]
        float speed = 5f;
        //public float speedX ;
        //public float speedY ;

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

            //transform.Translate(speedX, speedY, 0f);

            if (HolizontalValue > 0.6f)
            {
                transform.Translate(speed * Time.deltaTime * 20, 0f, 0f);
                //speedX -= Time.deltaTime * 10f;
            }

            if (HolizontalValue < -0.6f)
            {
                transform.Translate(speed * -Time.deltaTime * 20, 0f, 0f);
                //speedX += Time.deltaTime * 10f; 
            }

            if (VerticalValue > 0.6f)
            {
                transform.Translate(0f, speed * Time.deltaTime * 20, 0f);
                //speedY += Time.deltaTime * 10f; 
            }

            if (VerticalValue < -0.6f)
            {
                transform.Translate(0f, speed * -Time.deltaTime * 20, 0f);
                //speedY -= Time.deltaTime * 10f; 
            }
        }
    }

}
