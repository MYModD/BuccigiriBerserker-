using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roll_Move : MonoBehaviour
{
    public float _rotationSpeed = 360f; // ��]���x (1�b��360�x��])

    public int _numberRotations = 3; // ��]��

    private bool _isRotating = false; // ��]�����ǂ����������t���O

    private Collider objectCollider; // �I�u�W�F�N�g�̃R���C�_�[

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

       


        while (totalRotation < targetRotation)
        {
            float _rotationFrame = _rotationSpeed * Time.deltaTime;
            //transform.Rotate(Vector3.forward, _rotationFrame);
            Quaternion deltaRotation = Quaternion.AngleAxis(_rotationFrame, Vector3.forward);
            transform.rotation *= deltaRotation;
            totalRotation += _rotationFrame;
            yield return null;
        }

        //transform.Rotate(Vector3.forward, targetRotation - totalRotation);

        //objectCollider.enabled = true;

        Quaternion finalRotation = Quaternion.AngleAxis(targetRotation - totalRotation, Vector3.forward);
        transform.rotation *= finalRotation;

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
            float _rotationFrame = _rotationSpeed * Time.deltaTime;
            //transform.Rotate(Vector3.back,_rotationFrame);
            Quaternion deltaRotation = Quaternion.AngleAxis(_rotationFrame, Vector3.back);
            transform.rotation *= deltaRotation;
            totalRotation += _rotationFrame;
            yield return null;
        }

        //transform.Rotate(Vector3.back, targetRotation - totalRotation);

        // �ŏI�I�Ȕ�����
        Quaternion finalRotation = Quaternion.AngleAxis(targetRotation - totalRotation, Vector3.back);
        transform.rotation *= finalRotation;

        objectCollider.enabled = true;

        _isRotating = false;
    }
}