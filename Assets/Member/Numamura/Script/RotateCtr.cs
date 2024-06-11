using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCtr : MonoBehaviour
{
    
        public float _maxRotation = 60f; // �ő��]�p�x
        public float _rotationSpeed = 5f; // ��]���x

        void Update()
        {
            float Horizontal = Input.GetAxis("Horizontal");

            // Horizontal�̒l��-60����60�͈̔͂Ƀ}�b�s���O
            float PlayerRot = Mathf.Clamp(Horizontal * _rotationSpeed, -_maxRotation, _maxRotation);

            // y���̉�]��K�p
            transform.rotation = Quaternion.Euler(0f, PlayerRot * 20, 0f);
            //transform.Rotate(Vector3.up, mappedRotation * 135 * Time.deltaTime);

    }
    
}

