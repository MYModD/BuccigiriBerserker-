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

        private Vector3 Player_pos;

        private new Rigidbody rigidbody;

        [SerializeField]
        float speed = 5f;
        [SerializeField]
        float move_max_x;
        [SerializeField]
        float move_min_x;
        [SerializeField]
        float move_max_y;
        [SerializeField]
        float move_min_y;

        //[SerializeField] float rotationSpeed = 100f;
        //[SerializeField] float rotationAngle = 45f;
        //public float speedX ;
        //public float speedY ;

        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody>();
           
        }

        // Update is called once per frame




        // Update is called once per frame
        void Update()
        {
           //ˆÚ“®§ŒÀ

            Vector3 playerpos = transform.position;

            playerpos.x = Mathf.Clamp(playerpos.x, move_min_x, move_max_x);
            playerpos.y = Mathf.Clamp(playerpos.y, move_min_y, move_max_y);
            transform.position = playerpos;

           
            
        }

        private void FixedUpdate()
        {
            HolizontalValue = Input.GetAxisRaw("Horizontal");

            VerticalValue = Input.GetAxisRaw("Vertical");

            transform.Translate(Vector3.back);

            if (HolizontalValue > 0.6f)
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
               
            }

            if (HolizontalValue < -0.6f)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
                
            }

            if (VerticalValue > 0.6f)
            {
                transform.Translate(Vector3.down * speed * Time.deltaTime);
               
            }

            if (VerticalValue < -0.6f)
            {
                transform.Translate(Vector3.up * speed * Time.deltaTime);
               
            }

        }
       
    }
}
