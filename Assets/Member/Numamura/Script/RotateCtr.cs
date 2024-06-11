using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCtr : MonoBehaviour
{
    
        public float maxRotation = 60f; // 最大回転角度
        public float rotationSpeed = 5f; // 回転速度

        void Update()
        {
            float Horizontal = Input.GetAxis("Horizontal");

            // Horizontalの値を-60から60の範囲にマッピング
            float PlayerRot = Mathf.Clamp(Horizontal * rotationSpeed, -maxRotation, maxRotation);

            // y軸の回転を適用
            transform.rotation = Quaternion.Euler(0f, PlayerRot * 20, 0f);
            //transform.Rotate(Vector3.up, mappedRotation * 135 * Time.deltaTime);

    }
    
}

