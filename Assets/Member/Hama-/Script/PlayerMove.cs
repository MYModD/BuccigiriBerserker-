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
            // 移動量を計算
            Vector3 moveDirection = new Vector3(HolizontalValue, VerticalValue, 0).normalized;
            Vector3 moveAmount = moveDirection * speed * Time.fixedDeltaTime;

            // 現在の位置を取得し、移動量を加算
            Vector3 newPosition = rb.position + moveAmount;

            // 初期位置を基準にして移動範囲を制限
            float clampedX = Mathf.Clamp(newPosition.x, _startPosition.x + move_min_x, _startPosition.x + move_max_x);
            float clampedY = Mathf.Clamp(newPosition.y, _startPosition.y + move_min_y, _startPosition.y + move_max_y);

            // 制限された位置に設定
            Vector3 clampedPosition = new Vector3(clampedX, clampedY, newPosition.z);
            rb.MovePosition(clampedPosition);
        }
    }
}
