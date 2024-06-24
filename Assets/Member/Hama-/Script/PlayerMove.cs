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

        private float rotationSpeed = 45;
        private float rotationx = 0f;
        private float rotationz = 0f;          // zŽ²‚Ì‰ñ“]Šp“x
        private float resettime = 30f;
        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody>();

        }

        // Update is called once per frame




        // Update is called once per frame
        void Update()
        {

            HolizontalValue = Input.GetAxisRaw("Horizontal");

            VerticalValue = Input.GetAxisRaw("Vertical");

            Vector3 playerpos = transform.position;

            playerpos.x = Mathf.Clamp(playerpos.x, move_min_x, move_max_x);
            playerpos.y = Mathf.Clamp(playerpos.y, move_min_y, move_max_y);
            transform.position = playerpos;

            Roll_Move roll_Move = GetComponent<Roll_Move>();

            if (roll_Move._isRotating == false)
            {
                float rotationChangez = HolizontalValue * rotationSpeed * Time.deltaTime * 5;

                rotationz += rotationChangez;

                rotationz = Mathf.Clamp(rotationz, -rotationSpeed, rotationSpeed);

                float rotationChangex = VerticalValue * -rotationSpeed * Time.deltaTime * 5;

                rotationx += rotationChangex;

                rotationx = Mathf.Clamp(rotationx, -rotationSpeed, rotationSpeed);

                if (HolizontalValue == 0 && VerticalValue == 0 && (rotationx != 0 || rotationz != 0))
                {
                    // Reduce rotationx and rotationz towards 0
                    float resetAmount = resettime * Time.deltaTime * 5;

                    if (rotationx != 0)
                    {
                        rotationx = Mathf.MoveTowards(rotationx, 0, resetAmount);
                    }

                    if (rotationz != 0)
                    {
                        rotationz = Mathf.MoveTowards(rotationz, 0, resetAmount);
                    }
                }

                transform.rotation = Quaternion.Euler(rotationx, 180, rotationz);
            }
        }



        private void FixedUpdate()
        {
            HolizontalValue = Input.GetAxisRaw("Horizontal");

            VerticalValue = Input.GetAxisRaw("Vertical");

            transform.Translate(Vector3.back * speed * Time.deltaTime);

            if (HolizontalValue > 0.3f)
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);

            }

            if (HolizontalValue < -0.3f)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);

            }

            if (VerticalValue > 0.3f)
            {
                transform.Translate(Vector3.down * speed * Time.deltaTime);

            }

            if (VerticalValue < -0.3f)
            {
                transform.Translate(Vector3.up * speed * Time.deltaTime);

            }

        }

    }
}
