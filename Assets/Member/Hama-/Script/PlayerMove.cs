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

        private float rotationSpeed = 45f;
        private float rotationx = 0f;
        private float rotationz = 0f;          // z���̉�]�p�x
        private float resetTime = 30f;
        private float rotaiony = 180f;
        private Roll_Move roll_move;
        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody>();
            roll_move = GetComponent<Roll_Move>(); // �����ŏC��
        }

        // Update is called once per frame




        // Update is called once per frame
        void Update()
        {


            if (roll_move._isRotating == false)
            {
                float horizontalInput = Input.GetAxis("Horizontal");
                float verticalInput = Input.GetAxis("Vertical");

                // Z���̉�]
                float rotationChangez = horizontalInput * rotationSpeed * Time.deltaTime * 5;
                rotationz += rotationChangez;
                rotationz = Mathf.Clamp(rotationz, -rotationSpeed, rotationSpeed);

                // X���̉�]
                float rotationChangex = verticalInput * -rotationSpeed * Time.deltaTime * 5;
                rotationx += rotationChangex;
                rotationx = Mathf.Clamp(rotationx, -rotationSpeed, rotationSpeed);

                // ���͂��Ȃ�����]���c���Ă���ꍇ�A���Z�b�g
                if (horizontalInput == 0 && verticalInput == 0 && (rotationx != 0 || rotationz != 0))
                {
                    float resetAmount = resetTime * Time.deltaTime * 5;
                    if (rotationx != 0)
                    {
                        rotationx = Mathf.MoveTowards(rotationx, 0f, resetAmount);
                    }
                    if (rotationz != 0)
                    {
                        rotationz = Mathf.MoveTowards(rotationz, 0f, resetAmount);
                    }
                }

                // �v���C���[�̉�]��K�p
                transform.rotation = Quaternion.Euler(rotationx, rotaiony, rotationz);
            }

        }





        private void FixedUpdate()
        {
            HolizontalValue = Input.GetAxisRaw("Horizontal");

            VerticalValue = Input.GetAxisRaw("Vertical");

            // �v���C���[�̑O�i�����x�N�g�����v�Z
            Vector3 moveDirection = Vector3.forward;

            // �v���C���[�̈ړ����������E����я㉺�̓��͂Ɋ�Â��Ē������܂�
            moveDirection += Vector3.right * HolizontalValue;

            moveDirection += Vector3.down * VerticalValue;

            // Rigidbody �ɗ͂������Ĉړ������܂�
            rb.velocity = moveDirection.normalized * speed;

            // Rigidbody�ɑ��x��^���Ĉړ�������
            rb.velocity = moveDirection * speed;
        }
    }
}




