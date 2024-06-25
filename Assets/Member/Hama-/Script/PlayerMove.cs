using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test
{
    public class PlayerMove : MonoBehaviour
    {
        private Rigidbody rb;

        private float HolizontalValue;

        private float VerticalValue;

        private Vector3 _startPosition;

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

        void Start()
        {
            rb = GetComponent<Rigidbody>();
            _startPosition = transform.position;
        }

        void Update()
        {
            HolizontalValue = Input.GetAxisRaw("Horizontal");
            VerticalValue = Input.GetAxisRaw("Vertical");
        }

        private void FixedUpdate()
        {
            // �ړ��ʂ��v�Z
            Vector3 moveDirection = new Vector3(HolizontalValue, VerticalValue, 0).normalized;
            Vector3 moveAmount = moveDirection * speed * Time.fixedDeltaTime;

            // ���݂̈ʒu���擾���A�ړ��ʂ����Z
            Vector3 newPosition = rb.position + moveAmount;

            // �����ʒu����ɂ��Ĉړ��͈͂𐧌�
            float clampedX = Mathf.Clamp(newPosition.x, _startPosition.x + move_min_x, _startPosition.x + move_max_x);
            float clampedY = Mathf.Clamp(newPosition.y, _startPosition.y + move_min_y, _startPosition.y + move_max_y);

            // �������ꂽ�ʒu�ɐݒ�
            Vector3 clampedPosition = new Vector3(clampedX, clampedY, newPosition.z);
            rb.MovePosition(clampedPosition);
        }
    }
}
