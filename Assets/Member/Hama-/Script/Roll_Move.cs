using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roll_Move : MonoBehaviour
{
    public float _rotationSpeed = 360f; // 回転速度 (1秒で360度回転)
    public int _numberRotations = 3; // 回転回数
    private bool _isRotating = false; // 回転中かどうかを示すフラグ
    private Collider objectCollider; // オブジェクトのコライダー

    // Start is called before the first frame update
    void Start()
    {
        objectCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetButtonDown("Right_Roll") && !_isRotating)
        {
            StartCoroutine(RotateObject_Right());
        }

        if (Input.GetButtonDown("Left_Roll") && !_isRotating)
        {
            StartCoroutine(RotateObject_Left());
        }

        //float _moveX = Input.GetAxis("Horizontal") * Time.deltaTime;
        //float _moveY = Input.GetAxis("Vertical") * Time.deltaTime;

        //transform.Translate(new Vector3(_moveX, _moveY, 0));
    }

    private IEnumerator RotateObject_Right()
    {
        _isRotating = true;
        objectCollider.enabled = false;

        float totalRotation = 0f;
        float targetRotation = 360f * _numberRotations;

        while(totalRotation < targetRotation)
        {
            float rotationFrame = _rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.forward, rotationFrame);

            totalRotation += rotationFrame;
            yield return null;
        }

        transform.Rotate(Vector3.forward, targetRotation - totalRotation);

        objectCollider.enabled = true;

        _isRotating = false;
    }

    private IEnumerator RotateObject_Left()
    {
        _isRotating = true;
        objectCollider.enabled = false;

        float totalRotation = 0f;
        float targetRotation = 360f * _numberRotations;

        while (totalRotation < targetRotation)
        {
            float rotationFrame = _rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.back, rotationFrame);
            totalRotation += rotationFrame;
            yield return null;
        }

        transform.Rotate(Vector3.back, targetRotation - totalRotation);

        objectCollider.enabled = true;

        _isRotating = false;
    }
}
