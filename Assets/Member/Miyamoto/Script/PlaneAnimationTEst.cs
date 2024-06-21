using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlaneAnimationTest : MonoBehaviour
{
    [Header("������Transform")]
    public Transform[] rudders; // ������
    public Transform[] flaps; // �t���b�v
    public Transform[] elevator; // ���~��

    [Header("���͈�")]
    public Vector2 ruddersDegreeRange = new Vector2(-20, 20); // �����ǂ̉�]�͈�
    public Vector2 flapsDegreeRange = new Vector2(-20, 20); // �t���b�v�̉�]�͈�
    public Vector2 elevatorDegreeRange = new Vector2(-10, 10); // ���~�ǂ̏㉺�����̉�]�͈�
    public Vector2 elevator222DegreeRange = new Vector2(-10, 10); // ���~�ǂ̍��E�����̉�]�͈�

    [Header("���{��")]
    public float multiplyValue = 1f; // ���͂̔{��

    [Header("��ԑ��x")]
    public float lerpTRudder = 0.1f; // �����ǂ̕�ԑ��x
    public float lerpTFlaps = 0.1f; // �t���b�v�̕�ԑ��x
    public float lerpTElevators = 0.1f; // ���~�ǂ̕�ԑ��x
    public float lerpTRightLeftElevators = 0.1f; // ���~�ǁi���E�j�̕�ԑ��x

    // Start is called before the first frame update
    void Start()
    {
        // �������������K�v�Ȃ炱���ɋL�q
    }

    // Update is called once per frame
    void Update()
    {
        RotateRudder();
        RotateFlaps();
        RotateElevator();
    }

    // �����ǂ���]������
    private void RotateRudder()
    {
        float input = Input.GetAxis("Horizontal") * multiplyValue;
        input = Mathf.Clamp(input, ruddersDegreeRange.x, ruddersDegreeRange.y);
        Vector3 rotation = new Vector3(0, input, 0);
        Quaternion targetRotation = Quaternion.Euler(-rotation);
        Quaternion currentRotation = Quaternion.Lerp(rudders[0].transform.rotation, targetRotation, lerpTRudder);

        rudders[0].transform.rotation = currentRotation;
        rudders[1].transform.rotation = currentRotation;
    }

    // �t���b�v����]������
    private void RotateFlaps()
    {
        float input = Input.GetAxis("Vertical") * multiplyValue;
        input = Mathf.Clamp(input, flapsDegreeRange.x, flapsDegreeRange.y);
        Vector3 rotation = new Vector3(input, 0, 0);
        Quaternion targetRotation = Quaternion.Euler(-rotation);
        Quaternion currentRotation = Quaternion.Lerp(flaps[1].transform.rotation, targetRotation, lerpTFlaps);

        flaps[0].transform.rotation = currentRotation;
        flaps[1].transform.rotation = currentRotation;
    }

    // ���~�ǂ���]������
    private void RotateElevator()
    {
        RotateElevatorUpDown();
        RotateElevatorLeftRight();
    }

    // ���~�ǂ��㉺�ɉ�]������
    private void RotateElevatorUpDown()
    {
        float input = Input.GetAxis("Vertical") * multiplyValue;
        input = Mathf.Clamp(input, elevatorDegreeRange.x, elevatorDegreeRange.y);
        Vector3 rotation = new Vector3(input, 0, 0);
        Quaternion targetRotation = Quaternion.Euler(-rotation);
        Quaternion currentRotation = Quaternion.Lerp(elevator[0].transform.rotation, targetRotation, lerpTElevators);

        elevator[0].transform.rotation = currentRotation;
        elevator[1].transform.rotation = currentRotation;
    }

    // ���~�ǂ����E�ɉ�]������
    private void RotateElevatorLeftRight()
    {
        float input = Input.GetAxis("Horizontal") * multiplyValue;
        input = Mathf.Clamp(input, elevator222DegreeRange.x, elevator222DegreeRange.y);
        Vector3 rotation = new Vector3(input, 0, 0);
        Quaternion targetRotation1 = Quaternion.Euler(rotation);
        Quaternion targetRotation2 = Quaternion.Euler(-rotation);

        Quaternion currentRotation1 = Quaternion.Lerp(elevator[0].transform.rotation, targetRotation1, lerpTRightLeftElevators);
        Quaternion currentRotation2 = Quaternion.Lerp(elevator[1].transform.rotation, targetRotation2, lerpTRightLeftElevators);

        elevator[0].transform.rotation = currentRotation1;
        elevator[1].transform.rotation = currentRotation2;
    }
}
